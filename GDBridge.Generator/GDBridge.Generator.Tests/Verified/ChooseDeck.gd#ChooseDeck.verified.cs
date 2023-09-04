//HintName: ChooseDeck.cs
using Godot;
using GodotBridge;

namespace GDScript.Bridge;

[GlobalClass]
public partial class ChooseDeck : GdScriptBridge
{
    PackedScene deckEntryScene
    {
        get => GdObject.Get("deckEntryScene");
        set => GdObject.Set("deckEntryScene", value);
    }

    PackedScene deckBuilderScene
    {
        get => GdObject.Get("deckBuilderScene");
        set => GdObject.Set("deckBuilderScene", value);
    }

    public ChooseDeck(GodotObject gdObject) : base(gdObject) {}

    Variant setup(Array decks) => GdObject.Call("setup", decks);

    int choose_deck() => GdObject.Call("choose_deck");

    void new_deck() => GdObject.Call("new_deck");
}