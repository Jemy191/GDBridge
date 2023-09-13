//HintName: DeckEntry.cs
using Godot;
using GdBridge;

namespace GDScript.Bridge;

[GlobalClass]
public partial class DeckEntry : GdScriptBridge
{
    public const string ClassName = "DeckEntry";
    long deckId
    {
        get => GdObject.Get("deckId").As<long>();
        set => GdObject.Set("deckId", value);
    }

    ChooseDeck chooseDeck
    {
        get => GdObject.Get("chooseDeck").As<ChooseDeck>();
        set => GdObject.Set("chooseDeck", value);
    }

    public DeckEntry(GodotObject gdObject) : base(gdObject) {}

    Variant setup(string deckName, long deckId, ChooseDeck chooseDeck) => GdObject.Call("setup", deckName, deckId, chooseDeck);
}