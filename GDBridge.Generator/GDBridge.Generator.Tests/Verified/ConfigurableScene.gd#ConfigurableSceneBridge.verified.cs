//HintName: ConfigurableSceneBridge.cs
using GDBridge;
using Godot;

[GlobalClass]
public partial class ConfigurableSceneBridge : GDScriptBridge
{
    public const string ClassName = "ConfigurableSceneBridge";
    public ConfigurableSceneBridge(GodotObject gdObject) : base(gdObject) {}
}