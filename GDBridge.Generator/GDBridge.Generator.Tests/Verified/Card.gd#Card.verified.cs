//HintName: Card.cs
using Godot;
using GodotBridge;

namespace GDScript.Bridge;

[GlobalClass]
public partial class Card : GdScriptBridge
{
    Label name_label
    {
        get => GdObject.Get("name_label");
        set => GdObject.Set("name_label", value);
    }

    Label cost_label
    {
        get => GdObject.Get("cost_label");
        set => GdObject.Set("cost_label", value);
    }

    public Card(GodotObject gdObject) : base(gdObject) {}

    Variant setup(String name, String cost) => GdObject.Call("setup", name, cost);
}