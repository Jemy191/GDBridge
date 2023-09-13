//HintName: Arena.cs
using Godot;
using GdBridge;

namespace GDScript.Bridge;

[GlobalClass]
public partial class Arena : GdScriptBridge
{
    public const string ClassName = "Arena";
    NodePath game_startup
    {
        get => GdObject.Get("game_startup").As<NodePath>();
        set => GdObject.Set("game_startup", value);
    }

    public Arena(GodotObject gdObject) : base(gdObject) {}

    Variant on_configure(Variant deck_id_in) => GdObject.Call("on_configure", deck_id_in);
}