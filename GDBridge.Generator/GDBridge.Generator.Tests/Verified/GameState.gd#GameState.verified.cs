//HintName: GameState.cs
using Godot;
using GdBridge;

namespace GDScript.Bridge;

[GlobalClass]
public partial class GameState : GdScriptBridge
{
    public GameState(GodotObject gdObject) : base(gdObject) {}
}