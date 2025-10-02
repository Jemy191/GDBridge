//HintName: BuiltInTypeBridge.cs
using GDBridge;
using Godot;

public partial class BuiltInTypeBridge : GDScriptBridge
{
    public const string GDClassName = "BuiltInType";
    public Variant var_variant
    {
        get => GdObject.Get("var_variant");
        set => GdObject.Set("var_variant", Godot.Variant.From(value));
    }

    public Godot.Aabb var_aabb
    {
        get => GdObject.Get("var_aabb").As<Godot.Aabb>();
        set => GdObject.Set("var_aabb", Godot.Variant.From(value));
    }

    public Godot.Collections.Array var_array
    {
        get => GdObject.Get("var_array").As<Godot.Collections.Array>();
        set => GdObject.Set("var_array", Godot.Variant.From(value));
    }

    public Godot.Basis var_basis
    {
        get => GdObject.Get("var_basis").As<Godot.Basis>();
        set => GdObject.Set("var_basis", Godot.Variant.From(value));
    }

    public bool var_bool
    {
        get => GdObject.Get("var_bool").As<bool>();
        set => GdObject.Set("var_bool", Godot.Variant.From(value));
    }

    public Godot.Callable var_callable
    {
        get => GdObject.Get("var_callable").As<Godot.Callable>();
        set => GdObject.Set("var_callable", Godot.Variant.From(value));
    }

    public Godot.Color var_color
    {
        get => GdObject.Get("var_color").As<Godot.Color>();
        set => GdObject.Set("var_color", Godot.Variant.From(value));
    }

    public Godot.Collections.Dictionary var_dictionary
    {
        get => GdObject.Get("var_dictionary").As<Godot.Collections.Dictionary>();
        set => GdObject.Set("var_dictionary", Godot.Variant.From(value));
    }

    public double var_float
    {
        get => GdObject.Get("var_float").As<double>();
        set => GdObject.Set("var_float", Godot.Variant.From(value));
    }

    public long var_int
    {
        get => GdObject.Get("var_int").As<long>();
        set => GdObject.Set("var_int", Godot.Variant.From(value));
    }

    public Godot.NodePath var_nodepath
    {
        get => GdObject.Get("var_nodepath").As<Godot.NodePath>();
        set => GdObject.Set("var_nodepath", Godot.Variant.From(value));
    }

    public Godot.GodotObject var_object
    {
        get => GdObject.Get("var_object").As<Godot.GodotObject>();
        set => GdObject.Set("var_object", Godot.Variant.From(value));
    }

    public byte[] var_packedbytearray
    {
        get => GdObject.Get("var_packedbytearray").As<byte[]>();
        set => GdObject.Set("var_packedbytearray", Godot.Variant.From(value));
    }

    public Godot.Color[] var_packedcolorarray
    {
        get => GdObject.Get("var_packedcolorarray").As<Godot.Color[]>();
        set => GdObject.Set("var_packedcolorarray", Godot.Variant.From(value));
    }

    public float[] var_packedfloat32array
    {
        get => GdObject.Get("var_packedfloat32array").As<float[]>();
        set => GdObject.Set("var_packedfloat32array", Godot.Variant.From(value));
    }

    public double[] var_packedfloat64array
    {
        get => GdObject.Get("var_packedfloat64array").As<double[]>();
        set => GdObject.Set("var_packedfloat64array", Godot.Variant.From(value));
    }

    public int[] var_packedint32array
    {
        get => GdObject.Get("var_packedint32array").As<int[]>();
        set => GdObject.Set("var_packedint32array", Godot.Variant.From(value));
    }

    public long[] var_packedint64array
    {
        get => GdObject.Get("var_packedint64array").As<long[]>();
        set => GdObject.Set("var_packedint64array", Godot.Variant.From(value));
    }

    public string[] var_packedstringarray
    {
        get => GdObject.Get("var_packedstringarray").As<string[]>();
        set => GdObject.Set("var_packedstringarray", Godot.Variant.From(value));
    }

    public Godot.Vector2[] var_packedvector2array
    {
        get => GdObject.Get("var_packedvector2array").As<Godot.Vector2[]>();
        set => GdObject.Set("var_packedvector2array", Godot.Variant.From(value));
    }

    public Godot.Vector3[] var_packedvector3array
    {
        get => GdObject.Get("var_packedvector3array").As<Godot.Vector3[]>();
        set => GdObject.Set("var_packedvector3array", Godot.Variant.From(value));
    }

    public Godot.Plane var_plane
    {
        get => GdObject.Get("var_plane").As<Godot.Plane>();
        set => GdObject.Set("var_plane", Godot.Variant.From(value));
    }

    public Godot.Projection var_projection
    {
        get => GdObject.Get("var_projection").As<Godot.Projection>();
        set => GdObject.Set("var_projection", Godot.Variant.From(value));
    }

    public Godot.Quaternion var_quaternion
    {
        get => GdObject.Get("var_quaternion").As<Godot.Quaternion>();
        set => GdObject.Set("var_quaternion", Godot.Variant.From(value));
    }

    public Godot.Rect2 var_rect2
    {
        get => GdObject.Get("var_rect2").As<Godot.Rect2>();
        set => GdObject.Set("var_rect2", Godot.Variant.From(value));
    }

    public Godot.Rect2I var_rect2i
    {
        get => GdObject.Get("var_rect2i").As<Godot.Rect2I>();
        set => GdObject.Set("var_rect2i", Godot.Variant.From(value));
    }

    public Godot.Rid var_rid
    {
        get => GdObject.Get("var_rid").As<Godot.Rid>();
        set => GdObject.Set("var_rid", Godot.Variant.From(value));
    }

    public Godot.Signal var_signal
    {
        get => GdObject.Get("var_signal").As<Godot.Signal>();
        set => GdObject.Set("var_signal", Godot.Variant.From(value));
    }

    public string var_string
    {
        get => GdObject.Get("var_string").As<string>();
        set => GdObject.Set("var_string", Godot.Variant.From(value));
    }

    public Godot.StringName var_stringname
    {
        get => GdObject.Get("var_stringname").As<Godot.StringName>();
        set => GdObject.Set("var_stringname", Godot.Variant.From(value));
    }

    public Godot.Transform2D var_transform2d
    {
        get => GdObject.Get("var_transform2d").As<Godot.Transform2D>();
        set => GdObject.Set("var_transform2d", Godot.Variant.From(value));
    }

    public Godot.Transform3D var_transform3d
    {
        get => GdObject.Get("var_transform3d").As<Godot.Transform3D>();
        set => GdObject.Set("var_transform3d", Godot.Variant.From(value));
    }

    public Godot.Vector2 var_vector2
    {
        get => GdObject.Get("var_vector2").As<Godot.Vector2>();
        set => GdObject.Set("var_vector2", Godot.Variant.From(value));
    }

    public Godot.Vector2I var_vector2i
    {
        get => GdObject.Get("var_vector2i").As<Godot.Vector2I>();
        set => GdObject.Set("var_vector2i", Godot.Variant.From(value));
    }

    public Godot.Vector3 var_vector3
    {
        get => GdObject.Get("var_vector3").As<Godot.Vector3>();
        set => GdObject.Set("var_vector3", Godot.Variant.From(value));
    }

    public Godot.Vector3I var_vector3i
    {
        get => GdObject.Get("var_vector3i").As<Godot.Vector3I>();
        set => GdObject.Set("var_vector3i", Godot.Variant.From(value));
    }

    public Godot.Vector4 var_vector4
    {
        get => GdObject.Get("var_vector4").As<Godot.Vector4>();
        set => GdObject.Set("var_vector4", Godot.Variant.From(value));
    }

    public Godot.Vector4I var_vector4i
    {
        get => GdObject.Get("var_vector4i").As<Godot.Vector4I>();
        set => GdObject.Set("var_vector4i", Godot.Variant.From(value));
    }

    public BuiltInTypeBridge(GodotObject gdObject) : base(gdObject) {}
}