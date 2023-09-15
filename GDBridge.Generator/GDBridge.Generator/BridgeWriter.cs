using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;
using GDParser;
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

    public SourceWriter Variables(ReadOnlyCollection<GdVariable> variables)
    {
        foreach (var variable in variables)
        {
            if (variable.Name.StartsWith("_"))
                continue;

            source.WriteLine($"public {variable.Type.ToCSharpTypeString(availableTypes)} {Pascalize(variable.Name)}")
                .OpenBlock()
                .WriteLine(
                    $"""
                     get => GdObject.Get("{variable.Name}"){GetTypeCast(variable.Type)};
                     set => GdObject.Set("{variable.Name}", value);
                     """)
                .CloseBlock()
                .WriteEmptyLines(1);
        }

        return source;
    }

    public SourceWriter Functions(IEnumerable<GdFunction> functions)
    {
        foreach (var function in functions)
        {
            if (function.Name.StartsWith("_"))
                continue;
            
            source.WriteEmptyLines(1)
                .WriteLine($"""public {function.ReturnType.ToCSharpTypeString(availableTypes)} {Pascalize(function.Name)}({InParameters(function.Parameters)}) => GdObject.Call("{function.Name}"{CallParameters(function.Parameters)}){GetTypeCast(function.ReturnType)};""");
        }

        return source;
    }
    string InParameters(IEnumerable<GdVariable> parameters) => string.Join(", ", parameters.Select(InParameter));
    string InParameter(GdVariable parameter) => $"{parameter.Type.ToCSharpTypeString(availableTypes)} {Pascalize(parameter.Name)}";
    string Pascalize(string text) => configuration.UsePascalCase ? Regex.Replace(text, "(?:^|_| +)(.)", match => match.Groups[1].Value.ToUpper()) : text;

    string CallParameters(IEnumerable<GdVariable> parameters)
    {
        parameters = parameters.ToList();
        if (!parameters.Any())
            return "";
        return $", {string.Join(", ", parameters.Select(p => Pascalize(p.Name)))}";
    }
    
    string GetTypeCast(GdType type)
    {
        var typeString = type.ToCSharpTypeString(availableTypes);
        if (typeString is "Variant" or "void")
            return "";
        
        return $".As<{typeString}>()";
    }


}