//HintName: ConfigurableScene.cs
using Godot;
using GodotBridge;

namespace GDScript.Bridge;

[GlobalClass]
public partial class ConfigurableScene : GdScriptBridge
{
    public ConfigurableScene(GodotObject gdObject) : base(gdObject) {}
}