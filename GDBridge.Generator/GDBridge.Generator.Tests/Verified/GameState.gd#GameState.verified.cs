//HintName: GameState.cs
using Godot;
using GodotBridge;

namespace GDScript.Bridge;

[GlobalClass]
public partial class GameState : GdScriptBridge
{
    public GameState(GodotObject gdObject) : base(gdObject) {}
}