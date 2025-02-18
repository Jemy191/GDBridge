//HintName: ChooseDeckBridge.cs
using GDBridge;
using Godot;

public partial class ChooseDeckBridge : GDScriptBridge
{
    public const string GDClassName = "ChooseDeck";
    public Godot.PackedScene deckEntryScene
    {
        get => GdObject.Get("deckEntryScene").As<Godot.PackedScene>();
        set => GdObject.Set("deckEntryScene", Godot.Variant.From(value));
    }

    public Godot.PackedScene deckBuilderScene
    {
        get => GdObject.Get("deckBuilderScene").As<Godot.PackedScene>();
        set => GdObject.Set("deckBuilderScene", Godot.Variant.From(value));
    }

    public ChooseDeckBridge(GodotObject gdObject) : base(gdObject) {}

    public Variant setup(Godot.Collections.Array<CardGame.Core.Data.DeckData> decks) => GdObject.Call("setup", decks);

    public long choose_deck() => GdObject.Call("choose_deck").As<long>();

    public void new_deck() => GdObject.Call("new_deck");

    /// <inheritdoc cref="global::Godot.GodotObject.SignalName"/>
    public new class SignalName : global::Godot.GodotObject.SignalName
    {

        // Summary:
        //     Cached name for the 'deck_choosen' signal.
        public static readonly StringName deck_choosen = "deck_choosen";
    }
    public event System.Action<long> deck_choosen
    {
        add
        {
            Connect(SignalName.deck_choosen, global::Godot.Callable.From(value));
        }
        remove
        {
            Disconnect(SignalName.deck_choosen, global::Godot.Callable.From(value));
        }
    }
}