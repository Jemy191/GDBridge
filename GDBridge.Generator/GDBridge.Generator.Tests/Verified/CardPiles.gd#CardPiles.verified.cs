//HintName: CardPiles.cs
using Godot;
using GodotBridge;

namespace GDScript.Bridge;

[GlobalClass]
public partial class CardPiles : GdScriptBridge
{
    public CardPiles(GodotObject gdObject) : base(gdObject) {}
}