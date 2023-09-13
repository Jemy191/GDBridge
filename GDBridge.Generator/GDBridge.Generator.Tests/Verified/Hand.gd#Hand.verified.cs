//HintName: Hand.cs
using Godot;
using GDBridge;

[GlobalClass]
public partial class HandBridge : GDScriptBridge
{
    public const string ClassName = "HandBridge";
    public PackedScene card_scene
    {
        get => GdObject.Get("card_scene").As<PackedScene>();
        set => GdObject.Set("card_scene", value);
    }

    public Node card_container
    {
        get => GdObject.Get("card_container").As<Node>();
        set => GdObject.Set("card_container", value);
    }

    public HandBridge(GodotObject gdObject) : base(gdObject) {}
}