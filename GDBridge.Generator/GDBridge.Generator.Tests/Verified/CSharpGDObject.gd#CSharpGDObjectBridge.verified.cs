//HintName: CSharpGDObjectBridge.cs
using GDBridge;
using Godot;

[GlobalClass]
public partial class CSharpGDObjectBridge : GDScriptBridge
{
    public const string ClassName = "CSharpGDObjectBridge";
    public GDBridge.Generator.Tests.TestProjectClasses.TestGDObject test_object
    {
        get => GdObject.Get("test_object").As<GDBridge.Generator.Tests.TestProjectClasses.TestGDObject>();
        set => GdObject.Set("test_object", value);
    }

    public CSharpGDObjectBridge(GodotObject gdObject) : base(gdObject) {}

    public void on_configure(GDBridge.Generator.Tests.TestProjectClasses.TestGDObject test_object) => GdObject.Call("on_configure", test_object);
}