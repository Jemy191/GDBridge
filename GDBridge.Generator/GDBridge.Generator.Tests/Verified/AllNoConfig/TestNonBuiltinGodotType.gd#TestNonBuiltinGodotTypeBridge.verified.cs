//HintName: TestNonBuiltinGodotTypeBridge.cs
using GDBridge;
using Godot;

[GlobalClass]
public partial class TestNonBuiltinGodotTypeBridge : GDScriptBridge
{
    public const string GDClassName = "TestNonBuiltinGodotType";
    public Godot.Node2D node
    {
        get => GdObject.Get("node").As<Godot.Node2D>();
        set => GdObject.Set("node", value);
    }

    public TestNonBuiltinGodotTypeBridge(GodotObject gdObject) : base(gdObject) {}

    public void on_configure(Godot.Node2D node) => GdObject.Call("on_configure", node);
}