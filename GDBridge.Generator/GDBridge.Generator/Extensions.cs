using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using GDParser;
using SourceGeneratorUtils;

namespace GDBridge.Generator;

static class Extensions
{
    public static SourceWriter Variables(this SourceWriter source, ReadOnlyCollection<GdVariable> variables)
    {
        foreach (var variable in variables)
        {
            if (variable.Name.StartsWith("_"))
                continue;

            source.WriteLine($"{variable.Type.ToCSharpTypeString()} {variable.Name}")
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

    public static SourceWriter Functions(this SourceWriter source, IEnumerable<GdFunction> functions)
    {
        foreach (var function in functions)
        {
            if (function.Name.StartsWith("_"))
                continue;

            source.WriteEmptyLines(1)
                .WriteLine($"""{function.ReturnType.ToCSharpTypeString()} {function.Name}({InParameters(function.Parameters)}) => GdObject.Call("{function.Name}"{CallParameters(function.Parameters)}){GetTypeCast(function.ReturnType)};""");
        }

        return source;
    }
    static string InParameters(IEnumerable<GdVariable> parameters) => string.Join(", ", parameters.Select(InParameter));
    static string InParameter(GdVariable parameter) => $"{parameter.Type.ToCSharpTypeString()} {parameter.Name}";

    static string CallParameters(IEnumerable<GdVariable> parameters)
    {
        var variables = parameters.ToList();
        if (!variables.Any())
            return "";
        return $", {string.Join(", ", variables.Select(p => p.Name))}";
    }
    
    static string GetTypeCast(GdType type)
    {
        if (type.BuiltInType is GdBuiltInType.Variant or GdBuiltInType.@void)
            return "";
        
        return $".As<{type.ToCSharpTypeString()}>()";
    }
}