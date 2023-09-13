//HintName: MenuBridge.cs
using GDBridge;
using Godot;

[GlobalClass]
public partial class MenuBridge : GDScriptBridge
{
    public const string ClassName = "MenuBridge";
    public Godot.Variant chooseDeck
    {
        get => GdObject.Get("chooseDeck").As<Godot.Variant>();
        set => GdObject.Set("chooseDeck", value);
    }

    public MenuBridge(GodotObject gdObject) : base(gdObject) {}
}