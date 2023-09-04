//HintName: LocalPlayer.cs
using Godot;
using GodotBridge;

namespace GDScript.Bridge;

[GlobalClass]
public partial class LocalPlayer : GdScriptBridge
{
    public LocalPlayer(GodotObject gdObject) : base(gdObject) {}

    void ready_to_play() => GdObject.Call("ready_to_play");
}