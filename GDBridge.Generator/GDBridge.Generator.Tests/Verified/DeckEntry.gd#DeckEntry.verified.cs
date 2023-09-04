//HintName: DeckEntry.cs
using Godot;
using GodotBridge;

namespace GDScript.Bridge;

[GlobalClass]
public partial class DeckEntry : GdScriptBridge
{
    int deckId
    {
        get => GdObject.Get("deckId");
        set => GdObject.Set("deckId", value);
    }

    ChooseDeck chooseDeck
    {
        get => GdObject.Get("chooseDeck");
        set => GdObject.Set("chooseDeck", value);
    }

    public DeckEntry(GodotObject gdObject) : base(gdObject) {}

    Variant setup(String deckName, int deckId, ChooseDeck chooseDeck) => GdObject.Call("setup", deckName, deckId, chooseDeck);
}