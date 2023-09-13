//HintName: ChooseDeckBridge.cs
using Godot;
using GDBridge;

[GlobalClass]
public partial class ChooseDeckBridge : GDScriptBridge
{
    public const string ClassName = "ChooseDeckBridge";
    public PackedScene deckEntryScene
    {
        get => GdObject.Get("deckEntryScene").As<PackedScene>();
        set => GdObject.Set("deckEntryScene", value);
    }

    public PackedScene deckBuilderScene
    {
        get => GdObject.Get("deckBuilderScene").As<PackedScene>();
        set => GdObject.Set("deckBuilderScene", value);
    }

    public ChooseDeckBridge(GodotObject gdObject) : base(gdObject) {}

    public Variant setup(Godot.Collections.Array decks) => GdObject.Call("setup", decks);

    public long choose_deck() => GdObject.Call("choose_deck").As<long>();

    public void new_deck() => GdObject.Call("new_deck");
}