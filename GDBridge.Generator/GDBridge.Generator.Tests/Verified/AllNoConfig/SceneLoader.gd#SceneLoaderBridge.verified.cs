//HintName: SceneLoaderBridge.cs
using GDBridge;
using Godot;

public partial class SceneLoaderBridge : GDScriptBridge
{
    public const string GDClassName = "SceneLoader";
    public Godot.PackedScene menuScene
    {
        get => GdObject.Get("menuScene").As<Godot.PackedScene>();
        set => GdObject.Set("menuScene", value);
    }

    public Godot.PackedScene arenaScene
    {
        get => GdObject.Get("arenaScene").As<Godot.PackedScene>();
        set => GdObject.Set("arenaScene", value);
    }

    public Godot.PackedScene deckbuilderScene
    {
        get => GdObject.Get("deckbuilderScene").As<Godot.PackedScene>();
        set => GdObject.Set("deckbuilderScene", value);
    }

    public Godot.Node current_scene
    {
        get => GdObject.Get("current_scene").As<Godot.Node>();
        set => GdObject.Set("current_scene", value);
    }

    public SceneLoaderBridge(GodotObject gdObject) : base(gdObject) {}

    public Variant goto_menu() => GdObject.Call("goto_menu");

    public Variant goto_arena(long player_deck_id) => GdObject.Call("goto_arena", player_deck_id);

    public Variant goto_deckbuilder(bool createNewDeck) => GdObject.Call("goto_deckbuilder", createNewDeck);
}