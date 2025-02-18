//HintName: DeckEntryBridge.cs
using GDBridge;
using Godot;

public partial class DeckEntryBridge : GDScriptBridge
{
    public const string GDClassName = "DeckEntry";
    public long deckId
    {
        get => GdObject.Get("deckId").As<long>();
        set => GdObject.Set("deckId", Godot.Variant.From(value));
    }

    public Godot.Variant chooseDeck
    {
        get => GdObject.Get("chooseDeck").As<Godot.Variant>();
        set => GdObject.Set("chooseDeck", Godot.Variant.From(value));
    }

    public DeckEntryBridge(GodotObject gdObject) : base(gdObject) {}

    public Variant setup(string deckName, long deckId, Godot.Variant chooseDeck) => GdObject.Call("setup", deckName, deckId, chooseDeck);

    /// <inheritdoc cref="global::Godot.GodotObject.SignalName"/>
    public new class SignalName : global::Godot.GodotObject.SignalName
    {
    }
}