//HintName: SceneLoaderBridge.cs
using Godot;
using GDBridge;

[GlobalClass]
public partial class SceneLoaderBridge : GDScriptBridge
{
    public const string ClassName = "SceneLoaderBridge";
    public PackedScene menuScene
    {
        get => GdObject.Get("menuScene").As<PackedScene>();
        set => GdObject.Set("menuScene", value);
    }

    public PackedScene arenaScene
    {
        get => GdObject.Get("arenaScene").As<PackedScene>();
        set => GdObject.Set("arenaScene", value);
    }

    public PackedScene deckbuilderScene
    {
        get => GdObject.Get("deckbuilderScene").As<PackedScene>();
        set => GdObject.Set("deckbuilderScene", value);
    }

    public Node current_scene
    {
        get => GdObject.Get("current_scene").As<Node>();
        set => GdObject.Set("current_scene", value);
    }

    public SceneLoaderBridge(GodotObject gdObject) : base(gdObject) {}

    public Variant goto_menu() => GdObject.Call("goto_menu");

    public Variant goto_arena(long player_deck_id) => GdObject.Call("goto_arena", player_deck_id);

    public Variant goto_deckbuilder(bool createNewDeck) => GdObject.Call("goto_deckbuilder", createNewDeck);
}