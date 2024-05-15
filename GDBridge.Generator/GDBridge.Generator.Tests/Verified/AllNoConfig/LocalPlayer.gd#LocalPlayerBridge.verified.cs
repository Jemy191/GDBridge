//HintName: LocalPlayerBridge.cs
using GDBridge;
using Godot;

public partial class LocalPlayerBridge : GDScriptBridge
{
    public const string GDClassName = "LocalPlayer";
    public LocalPlayerBridge(GodotObject gdObject) : base(gdObject) {}

    public void ready_to_play() => GdObject.Call("ready_to_play");
}