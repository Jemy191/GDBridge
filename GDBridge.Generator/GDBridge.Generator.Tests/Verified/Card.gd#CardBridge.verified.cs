//HintName: CardBridge.cs
using Godot;
using GDBridge;

[GlobalClass]
public partial class CardBridge : GDScriptBridge
{
    public const string ClassName = "CardBridge";
    public Label name_label
    {
        get => GdObject.Get("name_label").As<Label>();
        set => GdObject.Set("name_label", value);
    }

    public Label cost_label
    {
        get => GdObject.Get("cost_label").As<Label>();
        set => GdObject.Set("cost_label", value);
    }

    public CardBridge(GodotObject gdObject) : base(gdObject) {}

    public Variant setup(string name, string cost) => GdObject.Call("setup", name, cost);
}