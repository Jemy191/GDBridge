//HintName: ChooseDeck.cs
using Godot;
using GdBridge;

namespace GDScript.Bridge;

[GlobalClass]
public partial class ChooseDeck : GdScriptBridge
{
    PackedScene deckEntryScene
    {
        get => GdObject.Get("deckEntryScene").As<PackedScene>();
        set => GdObject.Set("deckEntryScene", value);
    }

    PackedScene deckBuilderScene
    {
        get => GdObject.Get("deckBuilderScene").As<PackedScene>();
        set => GdObject.Set("deckBuilderScene", value);
    }

    public ChooseDeck(GodotObject gdObject) : base(gdObject) {}

    Variant setup(Godot.Collections.Array<DeckData> decks) => GdObject.Call("setup", decks);

    long choose_deck() => GdObject.Call("choose_deck").As<long>();

    void new_deck() => GdObject.Call("new_deck");
}