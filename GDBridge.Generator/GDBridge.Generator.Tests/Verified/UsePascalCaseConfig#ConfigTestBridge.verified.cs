//HintName: ConfigTestBridge.cs
using GDBridge;
using Godot;

[GlobalClass]
public partial class ConfigTestBridge : GDScriptBridge
{
    public const string GDClassName = "ConfigTest";
    public Variant SnakeCaseVariable;
    {
        get => GdObject.Get("snake_case_variable;");
        set => GdObject.Set("snake_case_variable;", value);
    }

    public ConfigTestBridge(GodotObject gdObject) : base(gdObject) {}

    public Variant SnakeCaseFunction() => GdObject.Call("snake_case_function");
}