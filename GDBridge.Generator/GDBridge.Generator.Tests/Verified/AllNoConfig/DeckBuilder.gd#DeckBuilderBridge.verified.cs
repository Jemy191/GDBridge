//HintName: DeckBuilderBridge.cs
using GDBridge;
using Godot;

public partial class DeckBuilderBridge : GDScriptBridge
{
    public const string GDClassName = "DeckBuilder";
    public bool createNewDeck
    {
        get => GdObject.Get("createNewDeck").As<bool>();
        set => GdObject.Set("createNewDeck", Godot.Variant.From(value));
    }

    public DeckBuilderBridge(GodotObject gdObject) : base(gdObject) {}

    public Variant on_configure(Variant args) => GdObject.Call("on_configure", args);
}