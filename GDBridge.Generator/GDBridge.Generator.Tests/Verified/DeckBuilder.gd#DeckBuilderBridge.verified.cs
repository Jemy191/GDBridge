//HintName: DeckBuilderBridge.cs
using GDBridge;
using Godot;

[GlobalClass]
public partial class DeckBuilderBridge : GDScriptBridge
{
    public const string ClassName = "DeckBuilderBridge";
    public bool createNewDeck
    {
        get => GdObject.Get("createNewDeck").As<bool>();
        set => GdObject.Set("createNewDeck", value);
    }

    public DeckBuilderBridge(GodotObject gdObject) : base(gdObject) {}

    public Variant on_configure(Variant args) => GdObject.Call("on_configure", args);
}