//HintName: ConfigurableSceneBridge.cs
using GDBridge;
using Godot;

public partial class ConfigurableSceneBridge : GDScriptBridge
{
    public const string GDClassName = "ConfigurableScene";
    public ConfigurableSceneBridge(GodotObject gdObject) : base(gdObject) {}
}