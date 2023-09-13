//HintName: ConfigurableScene.cs
using Godot;
using GdBridge;

namespace GDScript.Bridge;

[GlobalClass]
public partial class ConfigurableScene : GdScriptBridge
{
    public const string ClassName = "ConfigurableScene";
    public ConfigurableScene(GodotObject gdObject) : base(gdObject) {}
}