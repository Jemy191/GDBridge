//HintName: Hand.cs
using Godot;
using GdBridge;

namespace GDScript.Bridge;

[GlobalClass]
public partial class Hand : GdScriptBridge
{
    public const string ClassName = "Hand";
    PackedScene card_scene
    {
        get => GdObject.Get("card_scene").As<PackedScene>();
        set => GdObject.Set("card_scene", value);
    }

    Node card_container
    {
        get => GdObject.Get("card_container").As<Node>();
        set => GdObject.Set("card_container", value);
    }

    public Hand(GodotObject gdObject) : base(gdObject) {}
}