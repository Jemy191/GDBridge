//HintName: CardPilesBridge.cs
using GDBridge;
using Godot;

public partial class CardPilesBridge : GDScriptBridge
{
    public const string GDClassName = "CardPiles";
    public CardPilesBridge(GodotObject gdObject) : base(gdObject) {}

    /// <inheritdoc cref="global::Godot.GodotObject.SignalName"/>
    public new class SignalName : global::Godot.GodotObject.SignalName
    {
    }
}