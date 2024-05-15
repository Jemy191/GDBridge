using System;
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
        var scriptFunctions = new List<GdFunction>();

        // Iterate over functions with default parameters omitted
        foreach (var function in functions)
        {
            // Filter out functions which start with an underscore to avoid native function overrides
            if (function.Name.StartsWith("_"))
            {
                continue;
            }

            var defaultParams = function.Parameters.Where(p => p.Name.Contains('=')).ToList();
            if (!defaultParams.Any())
            {
                scriptFunctions.Add(function);
                continue;
            }
            var nonDefaults = function.Parameters.Where(p => !defaultParams.Contains(p)).ToList();

            // Add a new function for each parameter signature
            for (var i = 0; i <= defaultParams.Count; i++)
            {
                var @params = new List<GdVariable>(nonDefaults);
                @params.AddRange(defaultParams.Take(i));
                scriptFunctions.Add(new GdFunction(function.Name, new ReadOnlyCollection<GdVariable>(@params),
                    function.ReturnType));
            }
        }

        foreach (var function in scriptFunctions)
        {
            source.WriteEmptyLines(1)
                .WriteLine(
                    $"""public {function.ReturnType.ToCSharpTypeString(availableTypes)} {Pascalize(function.Name)}({InParameters(function.Parameters)}) => GdObject.Call("{function.Name}"{CallParameters(function.Parameters)}){GetTypeCast(function.ReturnType)};""");
        }

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
        parameters = parameters.ToList();
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