using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using GDParser;
using SourceGeneratorUtils;

namespace GDBridge.Generator;

class BridgeWriter
{
    readonly ICollection<string> availableTypes;
    readonly SourceWriter source;
    public BridgeWriter(ICollection<string> availableTypes, SourceWriter source)
    {
        this.availableTypes = availableTypes;
        this.source = source;
    }

    public SourceWriter Variables(ReadOnlyCollection<GdVariable> variables)
    {
        foreach (var variable in variables)
        {
            if (variable.Name.StartsWith("_"))
                continue;

            source.WriteLine($"public {variable.Type.ToCSharpTypeString(availableTypes)} {variable.Name}")
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
                .WriteLine($"""public {function.ReturnType.ToCSharpTypeString(availableTypes)} {function.Name}({InParameters(function.Parameters)}) => GdObject.Call("{function.Name}"{CallParameters(function.Parameters)}){GetTypeCast(function.ReturnType)};""");
        }

        return source;
    }
    string InParameters(IEnumerable<GdVariable> parameters) => string.Join(", ", parameters.Select(InParameter));
    string InParameter(GdVariable parameter) => $"{parameter.Type.ToCSharpTypeString(availableTypes)} {parameter.Name}";

    string CallParameters(IEnumerable<GdVariable> parameters)
    {
        var variables = parameters.ToList();
        if (!variables.Any())
            return "";
        return $", {string.Join(", ", variables.Select(p => p.Name))}";
    }
    
    string GetTypeCast(GdType type)
    {
        var typeString = type.ToCSharpTypeString(availableTypes);
        if (typeString is "Variant" or "void")
            return "";
        
        return $".As<{typeString}>()";
    }


}