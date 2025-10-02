//HintName: CardBridge.cs
using GDBridge;
using Godot;

public partial class CardBridge : GDScriptBridge
{
    public const string GDClassName = "Card";
    public Godot.Label name_label
    {
        get => GdObject.Get("name_label").As<Godot.Label>();
        set => GdObject.Set("name_label", Godot.Variant.From(value));
    }

    public Godot.Label cost_label
    {
        get => GdObject.Get("cost_label").As<Godot.Label>();
        set => GdObject.Set("cost_label", Godot.Variant.From(value));
    }

    public CardBridge(GodotObject gdObject) : base(gdObject) {}

    public Variant setup(string name, string cost) => GdObject.Call("setup", name, cost);
}