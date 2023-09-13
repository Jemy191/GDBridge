//HintName: TestNonBuiltinGodotTypeBridge.cs
using Godot;
using GDBridge;

[GlobalClass]
public partial class TestNonBuiltinGodotTypeBridge : GDScriptBridge
{
    public const string ClassName = "TestNonBuiltinGodotTypeBridge";
    public Node2D node
    {
        get => GdObject.Get("node").As<Node2D>();
        set => GdObject.Set("node", value);
    }

    public TestNonBuiltinGodotTypeBridge(GodotObject gdObject) : base(gdObject) {}

    public void on_configure(Node2D node) => GdObject.Call("on_configure", node);
}