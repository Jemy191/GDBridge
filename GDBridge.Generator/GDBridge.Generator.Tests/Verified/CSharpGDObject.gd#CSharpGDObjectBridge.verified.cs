//HintName: CSharpGDObjectBridge.cs
using Godot;
using GDBridge;

[GlobalClass]
public partial class CSharpGDObjectBridge : GDScriptBridge
{
    public const string ClassName = "CSharpGDObjectBridge";
    public TestGDObject test_object
    {
        get => GdObject.Get("test_object").As<TestGDObject>();
        set => GdObject.Set("test_object", value);
    }

    public CSharpGDObjectBridge(GodotObject gdObject) : base(gdObject) {}

    public void on_configure(TestGDObject test_object) => GdObject.Call("on_configure", test_object);
}