//HintName: GameStateBridge.cs
using GDBridge;
using Godot;

public partial class GameStateBridge : GDScriptBridge
{
    public const string GDClassName = "GameState";
    public GameStateBridge(GodotObject gdObject) : base(gdObject) {}

    /// <inheritdoc cref="global::Godot.GodotObject.SignalName"/>
    public new class SignalName : global::Godot.GodotObject.SignalName
    {
    }
}