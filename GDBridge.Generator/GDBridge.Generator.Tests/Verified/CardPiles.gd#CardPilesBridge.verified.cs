//HintName: CardPilesBridge.cs
using Godot;
using GDBridge;

[GlobalClass]
public partial class CardPilesBridge : GDScriptBridge
{
    public const string ClassName = "CardPilesBridge";
    public CardPilesBridge(GodotObject gdObject) : base(gdObject) {}
}