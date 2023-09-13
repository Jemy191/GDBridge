//HintName: TestWeirdBridge.cs
using Godot;
using GDBridge;

[GlobalClass]
public partial class TestWeirdBridge : GDScriptBridge
{
    public const string ClassName = "TestWeirdBridge";
    public Variant chooseDeck
    {
        get => GdObject.Get("chooseDeck");
        set => GdObject.Set("chooseDeck", value);
    }

    public TestWeirdBridge(GodotObject gdObject) : base(gdObject) {}
}