//HintName: DeckEntryBridge.cs
using Godot;
using GDBridge;

[GlobalClass]
public partial class DeckEntryBridge : GDScriptBridge
{
    public const string ClassName = "DeckEntryBridge";
    public long deckId
    {
        get => GdObject.Get("deckId").As<long>();
        set => GdObject.Set("deckId", value);
    }

    public Variant chooseDeck
    {
        get => GdObject.Get("chooseDeck");
        set => GdObject.Set("chooseDeck", value);
    }

    public DeckEntryBridge(GodotObject gdObject) : base(gdObject) {}

    public Variant setup(string deckName, long deckId, Variant chooseDeck) => GdObject.Call("setup", deckName, deckId, chooseDeck);
}