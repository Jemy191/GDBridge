//HintName: TestWeirdBridge.cs
using GDBridge;
using Godot;

[GlobalClass]
public partial class TestWeirdBridge : GDScriptBridge
{
    public const string GDClassName = "TestWeird";
    public Godot.Variant chooseDeck
    {
        get => GdObject.Get("chooseDeck").As<Godot.Variant>();
        set => GdObject.Set("chooseDeck", value);
    }

    public TestWeirdBridge(GodotObject gdObject) : base(gdObject) {}
}