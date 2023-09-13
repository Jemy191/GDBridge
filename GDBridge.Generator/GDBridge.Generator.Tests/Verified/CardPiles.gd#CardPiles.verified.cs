//HintName: CardPiles.cs
using Godot;
using GdBridge;

namespace GDScript.Bridge;

[GlobalClass]
public partial class CardPiles : GdScriptBridge
{
    public const string ClassName = "CardPiles";
    public CardPiles(GodotObject gdObject) : base(gdObject) {}
}