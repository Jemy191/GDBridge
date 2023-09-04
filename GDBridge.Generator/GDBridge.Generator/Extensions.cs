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

            source.WriteLine($"{variable.Type} {variable.Name}")
                .OpenBlock()
                .WriteLine(
                    $"""
                     get => GdObject.Get("{variable.Name}");
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
                .WriteLine($"""{function.ReturnType} {function.Name}({InParameters(function.Parameters)}) => GdObject.Call("{function.Name}"{CallParameters(function.Parameters)});""");
        }

        return source;
    }
    public static string InParameters(IEnumerable<GdVariable> parameters) => string.Join(", ", parameters.Select(InParameter));
    public static string InParameter(GdVariable parameter) => $"{parameter.Type} {parameter.Name}";

    public static string CallParameters(IEnumerable<GdVariable> parameters)
    {
        var variables = parameters.ToList();
        if (!variables.Any())
            return "";
        return $", {string.Join(", ", variables.Select(p => p.Name))}";
    }
}