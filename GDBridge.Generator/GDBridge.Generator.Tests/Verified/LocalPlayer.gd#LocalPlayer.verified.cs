//HintName: LocalPlayer.cs
using Godot;
using GdBridge;

namespace GDScript.Bridge;

[GlobalClass]
public partial class LocalPlayer : GdScriptBridge
{
    public const string ClassName = "LocalPlayer";
    public LocalPlayer(GodotObject gdObject) : base(gdObject) {}

    void ready_to_play() => GdObject.Call("ready_to_play");
}