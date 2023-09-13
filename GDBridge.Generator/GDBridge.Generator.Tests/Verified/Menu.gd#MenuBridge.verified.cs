//HintName: MenuBridge.cs
using Godot;
using GDBridge;

[GlobalClass]
public partial class MenuBridge : GDScriptBridge
{
    public const string ClassName = "MenuBridge";
    public Variant chooseDeck
    {
        get => GdObject.Get("chooseDeck");
        set => GdObject.Set("chooseDeck", value);
    }

    public MenuBridge(GodotObject gdObject) : base(gdObject) {}
}