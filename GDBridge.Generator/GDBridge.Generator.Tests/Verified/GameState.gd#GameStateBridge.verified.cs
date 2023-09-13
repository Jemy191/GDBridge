//HintName: GameStateBridge.cs
using Godot;
using GDBridge;

[GlobalClass]
public partial class GameStateBridge : GDScriptBridge
{
    public const string ClassName = "GameStateBridge";
    public GameStateBridge(GodotObject gdObject) : base(gdObject) {}
}