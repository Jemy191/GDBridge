//HintName: BattlefieldBridge.cs
using GDBridge;
using Godot;

[GlobalClass]
public partial class BattlefieldBridge : GDScriptBridge
{
    public const string GDClassName = "Battlefield";
    public BattlefieldBridge(GodotObject gdObject) : base(gdObject) {}
}