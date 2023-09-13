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

            source.WriteLine($"public {variable.Type.ToCSharpTypeString()} {variable.Name}")
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
                .WriteLine($"""public {function.ReturnType.ToCSharpTypeString()} {function.Name}({InParameters(function.Parameters)}) => GdObject.Call("{function.Name}"{CallParameters(function.Parameters)}){GetTypeCast(function.ReturnType)};""");
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

    static string ToCSharpTypeString(this GdType type) => type.BuiltInType switch
    {
        GdBuiltInType.@bool => "bool",
        GdBuiltInType.@int => "long",
        GdBuiltInType.@float => "double",
        GdBuiltInType.String => "string",
        GdBuiltInType.Object => "Godot.GodotObject",
        GdBuiltInType.Callable => "Godot.Callable",
        GdBuiltInType.Signal => "Godot.Signal",
        GdBuiltInType.Dictionary => "Godot.Collections.Dictionary",
        GdBuiltInType.Array => GetGDArrayString(type),
        GdBuiltInType.PackedByteArray => "byte[]",
        GdBuiltInType.PackedInt32Array => "int[]",
        GdBuiltInType.PackedInt64Array => "long[]",
        GdBuiltInType.PackedFloat32Array => "float[]",
        GdBuiltInType.PackedFloat64Array => "double[]",
        GdBuiltInType.PackedStringArray => "string[]",
        GdBuiltInType.PackedVector2Array => "Godot.Vector2[]",
        GdBuiltInType.PackedVector3Array => "Godot.Vector3[]",
        GdBuiltInType.PackedColorArray => "Godot.Color[]",
        _ => type.TypeString ?? type.BuiltInType.ToString()
    };

    static string GetGDArrayString(GdType type)
    {
        if (type is { IsTypedArray: true, ArrayType.IsBuiltIn: true })
            return $"Godot.Collections.Array<{type.ArrayType.ToCSharpTypeString()}>";
        return "Godot.Collections.Array";
    }
}