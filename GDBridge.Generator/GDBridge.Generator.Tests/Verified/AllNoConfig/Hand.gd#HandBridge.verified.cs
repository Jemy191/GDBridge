//HintName: HandBridge.cs
using GDBridge;
using Godot;

public partial class HandBridge : GDScriptBridge
{
    public const string GDClassName = "Hand";
    public Godot.PackedScene card_scene
    {
        get => GdObject.Get("card_scene").As<Godot.PackedScene>();
        set => GdObject.Set("card_scene", Godot.Variant.From(value));
    }

    public Godot.Node card_container
    {
        get => GdObject.Get("card_container").As<Godot.Node>();
        set => GdObject.Set("card_container", Godot.Variant.From(value));
    }

    public HandBridge(GodotObject gdObject) : base(gdObject) {}

    /// <inheritdoc cref="global::Godot.GodotObject.SignalName"/>
    public new class SignalName : global::Godot.GodotObject.SignalName
    {
    }
}