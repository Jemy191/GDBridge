//HintName: HandBridge.cs
using GDBridge;
using Godot;

public partial class HandBridge : GDScriptBridge
{
    public const string GDClassName = "Hand";
    public Godot.PackedScene card_scene
    {
        get => GdObject.Get("card_scene").As<Godot.PackedScene>();
        set => GdObject.Set("card_scene", value);
    }

    public Godot.Node card_container
    {
        get => GdObject.Get("card_container").As<Godot.Node>();
        set => GdObject.Set("card_container", value);
    }

    public HandBridge(GodotObject gdObject) : base(gdObject) {}
}