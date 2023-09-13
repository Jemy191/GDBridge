//HintName: GameState.cs
using Godot;
using GdBridge;

namespace GDScript.Bridge;

[GlobalClass]
public partial class GameState : GdScriptBridge
{
    public const string ClassName = "GameState";
    public GameState(GodotObject gdObject) : base(gdObject) {}
}