//HintName: ConfigurableSceneBridge.cs
using Godot;
using GDBridge;

[GlobalClass]
public partial class ConfigurableSceneBridge : GDScriptBridge
{
    public const string ClassName = "ConfigurableSceneBridge";
    public ConfigurableSceneBridge(GodotObject gdObject) : base(gdObject) {}
}