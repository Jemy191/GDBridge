//HintName: DeckEntryBridge.cs
using GDBridge;
using Godot;

public partial class DeckEntryBridge : GDScriptBridge
{
    public const string GDClassName = "DeckEntry";
    public long deckId
    {
        get => GdObject.Get("deckId").As<long>();
        set => GdObject.Set("deckId", value);
    }

    public Godot.Variant chooseDeck
    {
        get => GdObject.Get("chooseDeck").As<Godot.Variant>();
        set => GdObject.Set("chooseDeck", value);
    }

    public DeckEntryBridge(GodotObject gdObject) : base(gdObject) {}

    public Variant setup(string deckName, long deckId, Godot.Variant chooseDeck) => GdObject.Call("setup", deckName, deckId, chooseDeck);
}