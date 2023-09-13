//HintName: TypedArrayBridge.cs
using Godot;
using GDBridge;

[GlobalClass]
public partial class TypedArrayBridge : GDScriptBridge
{
    public const string ClassName = "TypedArrayBridge";
    public Godot.Collections.Array array_test
    {
        get => GdObject.Get("array_test").As<Godot.Collections.Array>();
        set => GdObject.Set("array_test", value);
    }

    public Godot.Collections.Array<Variant> array_variant
    {
        get => GdObject.Get("array_variant").As<Godot.Collections.Array<Variant>>();
        set => GdObject.Set("array_variant", value);
    }

    public Godot.Collections.Array<AABB> array_aabb
    {
        get => GdObject.Get("array_aabb").As<Godot.Collections.Array<AABB>>();
        set => GdObject.Set("array_aabb", value);
    }

    public Godot.Collections.Array<Basis> array_basis
    {
        get => GdObject.Get("array_basis").As<Godot.Collections.Array<Basis>>();
        set => GdObject.Set("array_basis", value);
    }

    public Godot.Collections.Array<bool> array_bool
    {
        get => GdObject.Get("array_bool").As<Godot.Collections.Array<bool>>();
        set => GdObject.Set("array_bool", value);
    }

    public Godot.Collections.Array<Godot.Callable> array_callable
    {
        get => GdObject.Get("array_callable").As<Godot.Collections.Array<Godot.Callable>>();
        set => GdObject.Set("array_callable", value);
    }

    public Godot.Collections.Array<Color> array_color
    {
        get => GdObject.Get("array_color").As<Godot.Collections.Array<Color>>();
        set => GdObject.Set("array_color", value);
    }

    public Godot.Collections.Array<Godot.Collections.Dictionary> array_dictionary
    {
        get => GdObject.Get("array_dictionary").As<Godot.Collections.Array<Godot.Collections.Dictionary>>();
        set => GdObject.Set("array_dictionary", value);
    }

    public Godot.Collections.Array<double> array_float
    {
        get => GdObject.Get("array_float").As<Godot.Collections.Array<double>>();
        set => GdObject.Set("array_float", value);
    }

    public Godot.Collections.Array<long> array_int
    {
        get => GdObject.Get("array_int").As<Godot.Collections.Array<long>>();
        set => GdObject.Set("array_int", value);
    }

    public Godot.Collections.Array<NodePath> array_nodepath
    {
        get => GdObject.Get("array_nodepath").As<Godot.Collections.Array<NodePath>>();
        set => GdObject.Set("array_nodepath", value);
    }

    public Godot.Collections.Array<Godot.GodotObject> array_object
    {
        get => GdObject.Get("array_object").As<Godot.Collections.Array<Godot.GodotObject>>();
        set => GdObject.Set("array_object", value);
    }

    public Godot.Collections.Array<byte[]> array_packedbytearray
    {
        get => GdObject.Get("array_packedbytearray").As<Godot.Collections.Array<byte[]>>();
        set => GdObject.Set("array_packedbytearray", value);
    }

    public Godot.Collections.Array<Godot.Color[]> array_packedcolorarray
    {
        get => GdObject.Get("array_packedcolorarray").As<Godot.Collections.Array<Godot.Color[]>>();
        set => GdObject.Set("array_packedcolorarray", value);
    }

    public Godot.Collections.Array<float[]> array_packedfloat32array
    {
        get => GdObject.Get("array_packedfloat32array").As<Godot.Collections.Array<float[]>>();
        set => GdObject.Set("array_packedfloat32array", value);
    }

    public Godot.Collections.Array<double[]> array_packedfloat64array
    {
        get => GdObject.Get("array_packedfloat64array").As<Godot.Collections.Array<double[]>>();
        set => GdObject.Set("array_packedfloat64array", value);
    }

    public Godot.Collections.Array<int[]> array_packedint32array
    {
        get => GdObject.Get("array_packedint32array").As<Godot.Collections.Array<int[]>>();
        set => GdObject.Set("array_packedint32array", value);
    }

    public Godot.Collections.Array<long[]> array_packedint64array
    {
        get => GdObject.Get("array_packedint64array").As<Godot.Collections.Array<long[]>>();
        set => GdObject.Set("array_packedint64array", value);
    }

    public Godot.Collections.Array<string[]> array_packedstringarray
    {
        get => GdObject.Get("array_packedstringarray").As<Godot.Collections.Array<string[]>>();
        set => GdObject.Set("array_packedstringarray", value);
    }

    public Godot.Collections.Array<Godot.Vector2[]> array_packedvector2array
    {
        get => GdObject.Get("array_packedvector2array").As<Godot.Collections.Array<Godot.Vector2[]>>();
        set => GdObject.Set("array_packedvector2array", value);
    }

    public Godot.Collections.Array<Godot.Vector3[]> array_packedvector3array
    {
        get => GdObject.Get("array_packedvector3array").As<Godot.Collections.Array<Godot.Vector3[]>>();
        set => GdObject.Set("array_packedvector3array", value);
    }

    public Godot.Collections.Array<Plane> array_plane
    {
        get => GdObject.Get("array_plane").As<Godot.Collections.Array<Plane>>();
        set => GdObject.Set("array_plane", value);
    }

    public Godot.Collections.Array<Projection> array_projection
    {
        get => GdObject.Get("array_projection").As<Godot.Collections.Array<Projection>>();
        set => GdObject.Set("array_projection", value);
    }

    public Godot.Collections.Array<Quaternion> array_quaternion
    {
        get => GdObject.Get("array_quaternion").As<Godot.Collections.Array<Quaternion>>();
        set => GdObject.Set("array_quaternion", value);
    }

    public Godot.Collections.Array<Rect2> array_rect2
    {
        get => GdObject.Get("array_rect2").As<Godot.Collections.Array<Rect2>>();
        set => GdObject.Set("array_rect2", value);
    }

    public Godot.Collections.Array<Rect2i> array_rect2i
    {
        get => GdObject.Get("array_rect2i").As<Godot.Collections.Array<Rect2i>>();
        set => GdObject.Set("array_rect2i", value);
    }

    public Godot.Collections.Array<RID> array_rid
    {
        get => GdObject.Get("array_rid").As<Godot.Collections.Array<RID>>();
        set => GdObject.Set("array_rid", value);
    }

    public Godot.Collections.Array<Godot.Signal> array_signal
    {
        get => GdObject.Get("array_signal").As<Godot.Collections.Array<Godot.Signal>>();
        set => GdObject.Set("array_signal", value);
    }

    public Godot.Collections.Array<string> array_string
    {
        get => GdObject.Get("array_string").As<Godot.Collections.Array<string>>();
        set => GdObject.Set("array_string", value);
    }

    public Godot.Collections.Array<StringName> array_stringname
    {
        get => GdObject.Get("array_stringname").As<Godot.Collections.Array<StringName>>();
        set => GdObject.Set("array_stringname", value);
    }

    public Godot.Collections.Array<Transform2D> array_transform2d
    {
        get => GdObject.Get("array_transform2d").As<Godot.Collections.Array<Transform2D>>();
        set => GdObject.Set("array_transform2d", value);
    }

    public Godot.Collections.Array<Transform3D> array_transform3d
    {
        get => GdObject.Get("array_transform3d").As<Godot.Collections.Array<Transform3D>>();
        set => GdObject.Set("array_transform3d", value);
    }

    public Godot.Collections.Array<Vector2> array_vector2
    {
        get => GdObject.Get("array_vector2").As<Godot.Collections.Array<Vector2>>();
        set => GdObject.Set("array_vector2", value);
    }

    public Godot.Collections.Array<Vector2i> array_vector2i
    {
        get => GdObject.Get("array_vector2i").As<Godot.Collections.Array<Vector2i>>();
        set => GdObject.Set("array_vector2i", value);
    }

    public Godot.Collections.Array<Vector3> array_vector3
    {
        get => GdObject.Get("array_vector3").As<Godot.Collections.Array<Vector3>>();
        set => GdObject.Set("array_vector3", value);
    }

    public Godot.Collections.Array<Vector3i> array_vector3i
    {
        get => GdObject.Get("array_vector3i").As<Godot.Collections.Array<Vector3i>>();
        set => GdObject.Set("array_vector3i", value);
    }

    public Godot.Collections.Array<Vector4> array_vector4
    {
        get => GdObject.Get("array_vector4").As<Godot.Collections.Array<Vector4>>();
        set => GdObject.Set("array_vector4", value);
    }

    public Godot.Collections.Array<Vector4i> array_vector4i
    {
        get => GdObject.Get("array_vector4i").As<Godot.Collections.Array<Vector4i>>();
        set => GdObject.Set("array_vector4i", value);
    }

    public TypedArrayBridge(GodotObject gdObject) : base(gdObject) {}
}