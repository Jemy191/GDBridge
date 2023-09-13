//HintName: LocalPlayer.cs
using Godot;
using GDBridge;

[GlobalClass]
public partial class LocalPlayerBridge : GDScriptBridge
{
    public const string ClassName = "LocalPlayerBridge";
    public LocalPlayerBridge(GodotObject gdObject) : base(gdObject) {}

    public void ready_to_play() => GdObject.Call("ready_to_play");
}