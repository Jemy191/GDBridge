//HintName: Hand.cs
using Godot;
using GodotBridge;

namespace GDScript.Bridge;

[GlobalClass]
public partial class Hand : GdScriptBridge
{
    PackedScene card_scene
    {
        get => GdObject.Get("card_scene");
        set => GdObject.Set("card_scene", value);
    }

    Node card_container
    {
        get => GdObject.Get("card_container");
        set => GdObject.Set("card_container", value);
    }

    public Hand(GodotObject gdObject) : base(gdObject) {}
}