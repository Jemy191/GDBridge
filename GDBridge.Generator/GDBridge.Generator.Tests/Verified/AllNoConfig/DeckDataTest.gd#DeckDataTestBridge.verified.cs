//HintName: DeckDataTestBridge.cs
using GDBridge;
using Godot;

public partial class DeckDataTestBridge : GDScriptBridge
{
    public const string GDClassName = "DeckDataTest";
    public CardGame.Core.Data.DeckData test_object
    {
        get => GdObject.Get("test_object").As<CardGame.Core.Data.DeckData>();
        set => GdObject.Set("test_object", value);
    }

    public DeckDataTestBridge(GodotObject gdObject) : base(gdObject) {}

    public void on_configure(CardGame.Core.Data.DeckData deck_data) => GdObject.Call("on_configure", deck_data);
}