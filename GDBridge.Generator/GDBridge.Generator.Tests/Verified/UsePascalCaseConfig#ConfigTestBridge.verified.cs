//HintName: ConfigTestBridge.cs
using GDBridge;
using Godot;

public partial class ConfigTestBridge : GDScriptBridge
{
    public const string GDClassName = "ConfigTest";
    public Variant SnakeCaseVariable
    {
        get => GdObject.Get("snake_case_variable");
        set => GdObject.Set("snake_case_variable", Godot.Variant.From(value));
    }

    public Variant PropertyVar
    {
        get => GdObject.Get("property_var");
        set => GdObject.Set("property_var", Godot.Variant.From(value));
    }

    public ConfigTestBridge(GodotObject gdObject) : base(gdObject) {}

    public Variant SnakeCaseFunction() => GdObject.Call("snake_case_function");

    public Variant GetPropertyVar() => GdObject.Call("get_property_var");
}