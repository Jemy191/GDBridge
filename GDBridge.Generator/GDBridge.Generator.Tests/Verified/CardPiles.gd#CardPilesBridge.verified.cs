//HintName: CardPilesBridge.cs
using GDBridge;
using Godot;

[GlobalClass]
public partial class CardPilesBridge : GDScriptBridge
{
    public const string GDClassName = "CardPiles";
    public CardPilesBridge(GodotObject gdObject) : base(gdObject) {}
}