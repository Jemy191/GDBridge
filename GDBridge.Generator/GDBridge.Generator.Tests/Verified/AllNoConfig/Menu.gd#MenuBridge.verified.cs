//HintName: MenuBridge.cs
using GDBridge;
using Godot;

public partial class MenuBridge : GDScriptBridge
{
    public const string GDClassName = "Menu";
    public Godot.Variant chooseDeck
    {
        get => GdObject.Get("chooseDeck").As<Godot.Variant>();
        set => GdObject.Set("chooseDeck", Godot.Variant.From(value));
    }

    public MenuBridge(GodotObject gdObject) : base(gdObject) {}

    /// <inheritdoc cref="global::Godot.GodotObject.SignalName"/>
    public new class SignalName : global::Godot.GodotObject.SignalName
    {
    }
}