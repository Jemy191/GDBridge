using System.Collections.Generic;
using GDParser;
using System.Linq;

namespace GDBridge.Generator;

static class Extensions
{
    public static string ToCSharpTypeString(this GdType type, ICollection<AvailableType> availableTypes) => (type.BuiltInType switch
    {
        GdBuiltInType.@int => "long",
        GdBuiltInType.@float => "double",
        GdBuiltInType.String => "string",
        GdBuiltInType.Object => "Godot.GodotObject",
        GdBuiltInType.Callable => "Godot.Callable",
        GdBuiltInType.Signal => "Godot.Signal",
        GdBuiltInType.Dictionary => "Godot.Collections.Dictionary",
        GdBuiltInType.Array => GetGDArrayString(type, availableTypes),
        GdBuiltInType.PackedByteArray => "byte[]",
        GdBuiltInType.PackedInt32Array => "int[]",
        GdBuiltInType.PackedInt64Array => "long[]",
        GdBuiltInType.PackedFloat32Array => "float[]",
        GdBuiltInType.PackedFloat64Array => "double[]",
        GdBuiltInType.PackedStringArray => "string[]",
        GdBuiltInType.PackedVector2Array => "Godot.Vector2[]",
        GdBuiltInType.PackedVector3Array => "Godot.Vector3[]",
        GdBuiltInType.PackedColorArray => "Godot.Color[]",
        _ when type.IsBuiltIn => $"{type.BuiltInType.ToString()}",
        _  => GetTypeName(type, availableTypes)
    });
    static string GetTypeName(GdType type, ICollection<AvailableType> availableTypes)
    {
        var csharpType = availableTypes.FirstOrDefault(t => t.Name == type.TypeString!);
        if(csharpType is null)
            return "Godot.Variant";
        
        return $"{csharpType.Namespace}.{csharpType.Name}";
    }

    static string GetGDArrayString(GdType type, ICollection<AvailableType> availableTypes)
    {
        if (type is { IsTypedArray: true, ArrayType.IsBuiltIn: true } || availableTypes.Any(t => t.Name == type.ArrayType?.TypeString!))
            return $"Godot.Collections.Array<{type.ArrayType!.ToCSharpTypeString(availableTypes)}>";
        return "Godot.Collections.Array";
    }
}