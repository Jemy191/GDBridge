//HintName: GameStateBridge.cs
using GDBridge;
using Godot;

[GlobalClass]
public partial class GameStateBridge : GDScriptBridge
{
    public const string GDClassName = "GameState";
    public GameStateBridge(GodotObject gdObject) : base(gdObject) {}
}