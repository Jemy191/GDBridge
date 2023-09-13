//HintName: Battlefield.cs
using Godot;
using GDBridge;

[GlobalClass]
public partial class BattlefieldBridge : GDScriptBridge
{
    public const string ClassName = "BattlefieldBridge";
    public BattlefieldBridge(GodotObject gdObject) : base(gdObject) {}
}