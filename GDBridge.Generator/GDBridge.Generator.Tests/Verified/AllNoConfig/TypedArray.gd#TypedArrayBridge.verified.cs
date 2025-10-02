//HintName: TypedArrayBridge.cs
using GDBridge;
using Godot;

public partial class TypedArrayBridge : GDScriptBridge
{
    public const string GDClassName = "TypedArray";
    public Godot.Collections.Array array_test
    {
        get => GdObject.Get("array_test").As<Godot.Collections.Array>();
        set => GdObject.Set("array_test", Godot.Variant.From(value));
    }

    public Godot.Collections.Array<Variant> array_variant
    {
        get => GdObject.Get("array_variant").As<Godot.Collections.Array<Variant>>();
        set => GdObject.Set("array_variant", Godot.Variant.From(value));
    }

    public Godot.Collections.Array<Godot.Aabb> array_aabb
    {
        get => GdObject.Get("array_aabb").As<Godot.Collections.Array<Godot.Aabb>>();
        set => GdObject.Set("array_aabb", Godot.Variant.From(value));
    }

    public Godot.Collections.Array<Godot.Basis> array_basis
    {
        get => GdObject.Get("array_basis").As<Godot.Collections.Array<Godot.Basis>>();
        set => GdObject.Set("array_basis", Godot.Variant.From(value));
    }

    public Godot.Collections.Array<bool> array_bool
    {
        get => GdObject.Get("array_bool").As<Godot.Collections.Array<bool>>();
        set => GdObject.Set("array_bool", Godot.Variant.From(value));
    }

    public Godot.Collections.Array<Godot.Callable> array_callable
    {
        get => GdObject.Get("array_callable").As<Godot.Collections.Array<Godot.Callable>>();
        set => GdObject.Set("array_callable", Godot.Variant.From(value));
    }

    public Godot.Collections.Array<Godot.Color> array_color
    {
        get => GdObject.Get("array_color").As<Godot.Collections.Array<Godot.Color>>();
        set => GdObject.Set("array_color", Godot.Variant.From(value));
    }

    public Godot.Collections.Array<Godot.Collections.Dictionary> array_dictionary
    {
        get => GdObject.Get("array_dictionary").As<Godot.Collections.Array<Godot.Collections.Dictionary>>();
        set => GdObject.Set("array_dictionary", Godot.Variant.From(value));
    }

    public Godot.Collections.Array<double> array_float
    {
        get => GdObject.Get("array_float").As<Godot.Collections.Array<double>>();
        set => GdObject.Set("array_float", Godot.Variant.From(value));
    }

    public Godot.Collections.Array<long> array_int
    {
        get => GdObject.Get("array_int").As<Godot.Collections.Array<long>>();
        set => GdObject.Set("array_int", Godot.Variant.From(value));
    }

    public Godot.Collections.Array<Godot.NodePath> array_nodepath
    {
        get => GdObject.Get("array_nodepath").As<Godot.Collections.Array<Godot.NodePath>>();
        set => GdObject.Set("array_nodepath", Godot.Variant.From(value));
    }

    public Godot.Collections.Array<Godot.GodotObject> array_object
    {
        get => GdObject.Get("array_object").As<Godot.Collections.Array<Godot.GodotObject>>();
        set => GdObject.Set("array_object", Godot.Variant.From(value));
    }

    public Godot.Collections.Array<byte[]> array_packedbytearray
    {
        get => GdObject.Get("array_packedbytearray").As<Godot.Collections.Array<byte[]>>();
        set => GdObject.Set("array_packedbytearray", Godot.Variant.From(value));
    }

    public Godot.Collections.Array<Godot.Color[]> array_packedcolorarray
    {
        get => GdObject.Get("array_packedcolorarray").As<Godot.Collections.Array<Godot.Color[]>>();
        set => GdObject.Set("array_packedcolorarray", Godot.Variant.From(value));
    }

    public Godot.Collections.Array<float[]> array_packedfloat32array
    {
        get => GdObject.Get("array_packedfloat32array").As<Godot.Collections.Array<float[]>>();
        set => GdObject.Set("array_packedfloat32array", Godot.Variant.From(value));
    }

    public Godot.Collections.Array<double[]> array_packedfloat64array
    {
        get => GdObject.Get("array_packedfloat64array").As<Godot.Collections.Array<double[]>>();
        set => GdObject.Set("array_packedfloat64array", Godot.Variant.From(value));
    }

    public Godot.Collections.Array<int[]> array_packedint32array
    {
        get => GdObject.Get("array_packedint32array").As<Godot.Collections.Array<int[]>>();
        set => GdObject.Set("array_packedint32array", Godot.Variant.From(value));
    }

    public Godot.Collections.Array<long[]> array_packedint64array
    {
        get => GdObject.Get("array_packedint64array").As<Godot.Collections.Array<long[]>>();
        set => GdObject.Set("array_packedint64array", Godot.Variant.From(value));
    }

    public Godot.Collections.Array<string[]> array_packedstringarray
    {
        get => GdObject.Get("array_packedstringarray").As<Godot.Collections.Array<string[]>>();
        set => GdObject.Set("array_packedstringarray", Godot.Variant.From(value));
    }

    public Godot.Collections.Array<Godot.Vector2[]> array_packedvector2array
    {
        get => GdObject.Get("array_packedvector2array").As<Godot.Collections.Array<Godot.Vector2[]>>();
        set => GdObject.Set("array_packedvector2array", Godot.Variant.From(value));
    }

    public Godot.Collections.Array<Godot.Vector3[]> array_packedvector3array
    {
        get => GdObject.Get("array_packedvector3array").As<Godot.Collections.Array<Godot.Vector3[]>>();
        set => GdObject.Set("array_packedvector3array", Godot.Variant.From(value));
    }

    public Godot.Collections.Array<Godot.Plane> array_plane
    {
        get => GdObject.Get("array_plane").As<Godot.Collections.Array<Godot.Plane>>();
        set => GdObject.Set("array_plane", Godot.Variant.From(value));
    }

    public Godot.Collections.Array<Godot.Projection> array_projection
    {
        get => GdObject.Get("array_projection").As<Godot.Collections.Array<Godot.Projection>>();
        set => GdObject.Set("array_projection", Godot.Variant.From(value));
    }

    public Godot.Collections.Array<Godot.Quaternion> array_quaternion
    {
        get => GdObject.Get("array_quaternion").As<Godot.Collections.Array<Godot.Quaternion>>();
        set => GdObject.Set("array_quaternion", Godot.Variant.From(value));
    }

    public Godot.Collections.Array<Godot.Rect2> array_rect2
    {
        get => GdObject.Get("array_rect2").As<Godot.Collections.Array<Godot.Rect2>>();
        set => GdObject.Set("array_rect2", Godot.Variant.From(value));
    }

    public Godot.Collections.Array<Godot.Rect2I> array_rect2i
    {
        get => GdObject.Get("array_rect2i").As<Godot.Collections.Array<Godot.Rect2I>>();
        set => GdObject.Set("array_rect2i", Godot.Variant.From(value));
    }

    public Godot.Collections.Array<Godot.Rid> array_rid
    {
        get => GdObject.Get("array_rid").As<Godot.Collections.Array<Godot.Rid>>();
        set => GdObject.Set("array_rid", Godot.Variant.From(value));
    }

    public Godot.Collections.Array<Godot.Signal> array_signal
    {
        get => GdObject.Get("array_signal").As<Godot.Collections.Array<Godot.Signal>>();
        set => GdObject.Set("array_signal", Godot.Variant.From(value));
    }

    public Godot.Collections.Array<string> array_string
    {
        get => GdObject.Get("array_string").As<Godot.Collections.Array<string>>();
        set => GdObject.Set("array_string", Godot.Variant.From(value));
    }

    public Godot.Collections.Array<Godot.StringName> array_stringname
    {
        get => GdObject.Get("array_stringname").As<Godot.Collections.Array<Godot.StringName>>();
        set => GdObject.Set("array_stringname", Godot.Variant.From(value));
    }

    public Godot.Collections.Array<Godot.Transform2D> array_transform2d
    {
        get => GdObject.Get("array_transform2d").As<Godot.Collections.Array<Godot.Transform2D>>();
        set => GdObject.Set("array_transform2d", Godot.Variant.From(value));
    }

    public Godot.Collections.Array<Godot.Transform3D> array_transform3d
    {
        get => GdObject.Get("array_transform3d").As<Godot.Collections.Array<Godot.Transform3D>>();
        set => GdObject.Set("array_transform3d", Godot.Variant.From(value));
    }

    public Godot.Collections.Array<Godot.Vector2> array_vector2
    {
        get => GdObject.Get("array_vector2").As<Godot.Collections.Array<Godot.Vector2>>();
        set => GdObject.Set("array_vector2", Godot.Variant.From(value));
    }

    public Godot.Collections.Array<Godot.Vector2I> array_vector2i
    {
        get => GdObject.Get("array_vector2i").As<Godot.Collections.Array<Godot.Vector2I>>();
        set => GdObject.Set("array_vector2i", Godot.Variant.From(value));
    }

    public Godot.Collections.Array<Godot.Vector3> array_vector3
    {
        get => GdObject.Get("array_vector3").As<Godot.Collections.Array<Godot.Vector3>>();
        set => GdObject.Set("array_vector3", Godot.Variant.From(value));
    }

    public Godot.Collections.Array<Godot.Vector3I> array_vector3i
    {
        get => GdObject.Get("array_vector3i").As<Godot.Collections.Array<Godot.Vector3I>>();
        set => GdObject.Set("array_vector3i", Godot.Variant.From(value));
    }

    public Godot.Collections.Array<Godot.Vector4> array_vector4
    {
        get => GdObject.Get("array_vector4").As<Godot.Collections.Array<Godot.Vector4>>();
        set => GdObject.Set("array_vector4", Godot.Variant.From(value));
    }

    public Godot.Collections.Array<Godot.Vector4I> array_vector4i
    {
        get => GdObject.Get("array_vector4i").As<Godot.Collections.Array<Godot.Vector4I>>();
        set => GdObject.Set("array_vector4i", Godot.Variant.From(value));
    }

    public TypedArrayBridge(GodotObject gdObject) : base(gdObject) {}
}