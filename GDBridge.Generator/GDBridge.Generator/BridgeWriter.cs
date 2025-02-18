using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;
using GDParser;
using Microsoft.CodeAnalysis.CSharp;
using SourceGeneratorUtils;

namespace GDBridge.Generator;

class BridgeWriter
{
    readonly ICollection<AvailableType> availableTypes;
    readonly SourceWriter source;
    readonly Configuration configuration;
    public BridgeWriter(ICollection<AvailableType> availableTypes, SourceWriter source, Configuration configuration)
    {
        this.availableTypes = availableTypes;
        this.source = source;
        this.configuration = configuration;
    }

    public SourceWriter Properties(ReadOnlyCollection<GdVariable> properties)
    {
        foreach (var property in properties)
        {
            if (property.Name.StartsWith("_"))
                continue;

            var pascalizedName = Pascalize(property.Name);

            source.WriteLine($"public {property.Type.ToCSharpTypeString(availableTypes)} {pascalizedName}")
                .OpenBlock()
                .WriteLine(
                    $"""
                     get => GdObject.Get(PropertyName.{pascalizedName}){GetTypeCast(property.Type)};
                     set => GdObject.Set(PropertyName.{pascalizedName}, Godot.Variant.From(value));
                     """)
                .CloseBlock()
                .WriteEmptyLines(1);
        }
        return source;
    }

    public SourceWriter PropertyNameInnerClass(ReadOnlyCollection<GdVariable> properties)
    {
        source.WriteLine("""/// <inheritdoc cref="global::Godot.GodotObject.PropertyName"/>""")
            .WriteLine("""public new class PropertyName : global::Godot.GodotObject.PropertyName""")
            .OpenBlock();

        for (int i = 0; i < properties.Count(); ++i) {
            var property = properties.ElementAt(i);
            if (i > 0) source.WriteEmptyLines(1);
            source.WriteLine("//").WriteLine("// Summary:")
                .WriteLine($"""//     Cached name for the '{property.Name}' property.""")
                .WriteLine($"""public static readonly StringName {Pascalize(property.Name)} = "{property.Name}";""");
        }
        source.CloseBlock();

        return source;
    }

    public SourceWriter Methods(IEnumerable<GdFunction> methods, ReadOnlyCollection<GdVariable> variables)
    {
        var scriptFunctions = new List<GdFunction>();

        // Iterate over functions with default parameters omitted
        foreach (var method in methods)
        {
            // Filter out functions which start with an underscore to avoid native function overrides
            if (method.Name.StartsWith("_"))
            {
                continue;
            }

            var defaultParams = method.Parameters.Where(p => p.Name.Contains('=')).ToList();
            if (!defaultParams.Any())
            {
                scriptFunctions.Add(method);
                continue;
            }
            var nonDefaults = method.Parameters.Where(p => !defaultParams.Contains(p)).ToList();

            // Add a new function for each parameter signature
            for (var i = 0; i <= defaultParams.Count; i++)
            {
                var @params = new List<GdVariable>(nonDefaults);
                @params.AddRange(defaultParams.Take(i));
                scriptFunctions.Add(new GdFunction(method.Name, new ReadOnlyCollection<GdVariable>(@params),
                    method.ReturnType));
            }
        }

        foreach (var function in scriptFunctions)
        {
            var returnString = function.ReturnType.ToCSharpTypeString(availableTypes);
            
            var funcName = Pascalize(function.Name);

            var funcNameStart = function.Name.Substring(0, 4);
            var funcNameEnd = function.Name.Substring(4);
            if (!configuration.UsePascalCase && variables.Any(v => v.Name == funcNameEnd) && funcNameStart is "get_" or "set_")
                funcName += "_compat";
            
            var parameters = InParameters(function.Parameters);
            var gdParameters = CallParameters(function.Parameters);
            var typeCast = GetTypeCast(function.ReturnType);
            
            source.WriteLine($"""public {returnString} {funcName}({parameters}) => GdObject.Call(MethodName.{funcName}{gdParameters}){typeCast};""");
            source.WriteEmptyLines(1);
        }

        return source;
    }

    public SourceWriter MethodNameInnerClass(IEnumerable<GdFunction> methods)
    {
        source.WriteLine("""/// <inheritdoc cref="global::Godot.GodotObject.MethodName"/>""")
            .WriteLine("""public new class MethodName : global::Godot.GodotObject.MethodName""")
            .OpenBlock();

        for (int i = 0; i < methods.Count(); ++i) {
            var method = methods.ElementAt(i);
            if (i > 0) source.WriteEmptyLines(1);
            source.WriteLine("//").WriteLine("// Summary:")
                .WriteLine($"""//     Cached name for the '{method.Name}' method.""")
                .WriteLine($"""public static readonly StringName {Pascalize(method.Name)} = "{method.Name}";""");
        }
        source.CloseBlock();

        return source;
    }

    public SourceWriter Signals(IEnumerable<GdSignal> signals)
    {
        // Signal events
        foreach (var signal in signals) {
            var signalName = Pascalize(signal.Name);
            source
                .WriteLine($"""public event System.Action{(signal.Parameters.Any() ? $"<{string.Join(", ", signal.Parameters.Select(p => $"{p.Type.ToCSharpTypeString(availableTypes)}"))}>": "")} {signalName}""")
                .OpenBlock()
                .WriteLine("add").OpenBlock().WriteLine($"""Connect(SignalName.{signalName}, global::Godot.Callable.From(value));""").CloseBlock()
                .WriteLine("remove").OpenBlock().WriteLine($"""Disconnect(SignalName.{signalName}, global::Godot.Callable.From(value));""").CloseBlock()
                .CloseBlock()
                .WriteEmptyLines(1);
        }

        return source;
    }

    public SourceWriter SignalNameInnerClass(IEnumerable<GdSignal> signals)
    {
        source.WriteLine("""/// <inheritdoc cref="global::Godot.GodotObject.SignalName"/>""")
            .WriteLine("""public new class SignalName : global::Godot.GodotObject.SignalName""")
            .OpenBlock();

        for (int i = 0; i < signals.Count(); ++i) {
            var signal = signals.ElementAt(i);
            if (i > 0) source.WriteEmptyLines(1);
            source.WriteLine("//").WriteLine("// Summary:")
                .WriteLine($"""//     Cached name for the '{signal.Name}' signal.""")
                .WriteLine($"""public static readonly StringName {Pascalize(signal.Name)} = "{signal.Name}";""");
        }
        source.CloseBlock();

        return source;
    }

    string InParameters(IEnumerable<GdVariable> parameters) => string.Join(", ", parameters.Select(InParameter));
    string InParameter(GdVariable parameter) => $"{parameter.Type.ToCSharpTypeString(availableTypes)} {Pascalize(SanitizeParameter(parameter.Name))}";
    string Pascalize(string text) => configuration.UsePascalCase ? Regex.Replace(text, "(?:^|_| +)(.)", match => match.Groups[1].Value.ToUpper()) : text;

    string SanitizeParameter(string parameter)
    {
        // Return parameter if it's already valid
        if (SyntaxFacts.GetKeywordKind(parameter) == SyntaxKind.None && SyntaxFacts.IsValidIdentifier(parameter))
        {
            return parameter;
        }

        // Remove default parameter values
        var param = parameter;
        if (parameter.Contains('='))
        {
            param = parameter.Substring(0, parameter.IndexOf('=')).Trim();
        }

        // Validate it's not a reserved keyword
        return SyntaxFacts.GetKeywordKind(param) == SyntaxKind.None && SyntaxFacts.IsValidIdentifier(param) ? param : $"@{param}";
    }

    string CallParameters(IEnumerable<GdVariable> parameters)
    {
        if (!parameters.Any())
            return "";
        return $", {string.Join(", ", parameters.Select(p => Pascalize(SanitizeParameter(p.Name))))}";
    }

    string GetTypeCast(GdType type)
    {
        var typeString = type.ToCSharpTypeString(availableTypes);
        if (typeString is "Variant" or "void")
            return "";

        return $".As<{typeString}>()";
    }
}