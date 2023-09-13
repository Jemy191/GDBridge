using System.Collections.Generic;
using GDParser;

namespace GDBridge.Generator;

static class Extensions
{
    public static string ToCSharpTypeString(this GdType type, ICollection<string> availableTypes) => (type.BuiltInType switch
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
        _ when type.IsBuiltIn => type.BuiltInType.ToString(),
        _ when availableTypes.Contains(type.TypeString!) => type.TypeString!,
        _ => "Variant"
    });
    
    static string GetGDArrayString(GdType type, ICollection<string> availableTypes)
    {
        if (type is { IsTypedArray: true, ArrayType.IsBuiltIn: true } || availableTypes.Contains(type.ArrayType?.TypeString!))
            return $"Godot.Collections.Array<{type.ArrayType!.ToCSharpTypeString(availableTypes)}>";
        return "Godot.Collections.Array";
    }
}