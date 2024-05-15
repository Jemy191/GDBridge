//HintName: ScriptWithPropertyAndGetSetFuncBridge.cs
using GDBridge;
using Godot;

public partial class ScriptWithPropertyAndGetSetFuncBridge : GDScriptBridge
{
    public const string GDClassName = "ScriptWithPropertyAndGetSetFunc";
    public Variant limit_target
    {
        get => GdObject.Get("limit_target");
        set => GdObject.Set("limit_target", value);
    }

    public ScriptWithPropertyAndGetSetFuncBridge(GodotObject gdObject) : base(gdObject) {}

    public void set_limit_target_compat(Godot.NodePath value) => GdObject.Call("set_limit_target", value);

    public Godot.NodePath get_limit_target_compat() => GdObject.Call("get_limit_target").As<Godot.NodePath>();
}