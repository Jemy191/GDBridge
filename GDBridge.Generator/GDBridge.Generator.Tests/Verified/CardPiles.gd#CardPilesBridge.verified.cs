//HintName: CardPilesBridge.cs
using GDBridge;
using Godot;

[GlobalClass]
public partial class CardPilesBridge : GDScriptBridge
{
    public const string ClassName = "CardPilesBridge";
    public CardPilesBridge(GodotObject gdObject) : base(gdObject) {}
}