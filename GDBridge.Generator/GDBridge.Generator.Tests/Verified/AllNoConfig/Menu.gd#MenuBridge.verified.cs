//HintName: MenuBridge.cs
using GDBridge;
using Godot;

public partial class MenuBridge : GDScriptBridge
{
    public const string GDClassName = "Menu";
    public Godot.Variant chooseDeck
    {
        get => GdObject.Get("chooseDeck").As<Godot.Variant>();
        set => GdObject.Set("chooseDeck", value);
    }

    public MenuBridge(GodotObject gdObject) : base(gdObject) {}
}