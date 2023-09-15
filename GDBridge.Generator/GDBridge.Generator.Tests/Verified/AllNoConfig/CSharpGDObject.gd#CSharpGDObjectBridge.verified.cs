//HintName: CSharpGDObjectBridge.cs
using GDBridge;
using Godot;

[GlobalClass]
public partial class CSharpGDObjectBridge : GDScriptBridge
{
    public const string GDClassName = "CSharpGDObject";
    public TestGDObject test_object
    {
        get => GdObject.Get("test_object").As<TestGDObject>();
        set => GdObject.Set("test_object", value);
    }

    public CSharpGDObjectBridge(GodotObject gdObject) : base(gdObject) {}

    public void on_configure(TestGDObject test_object) => GdObject.Call("on_configure", test_object);
}