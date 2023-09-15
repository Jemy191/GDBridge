//HintName: ChooseDeckBridge.cs
using GDBridge;
using Godot;

[GlobalClass]
public partial class ChooseDeckBridge : GDScriptBridge
{
    public const string GDClassName = "ChooseDeck";
    public Godot.PackedScene deckEntryScene
    {
        get => GdObject.Get("deckEntryScene").As<Godot.PackedScene>();
        set => GdObject.Set("deckEntryScene", value);
    }

    public Godot.PackedScene deckBuilderScene
    {
        get => GdObject.Get("deckBuilderScene").As<Godot.PackedScene>();
        set => GdObject.Set("deckBuilderScene", value);
    }

    public ChooseDeckBridge(GodotObject gdObject) : base(gdObject) {}

    public Variant setup(Godot.Collections.Array<CardGame.Core.Data.DeckData> decks) => GdObject.Call("setup", decks);

    public long choose_deck() => GdObject.Call("choose_deck").As<long>();

    public void new_deck() => GdObject.Call("new_deck");
}