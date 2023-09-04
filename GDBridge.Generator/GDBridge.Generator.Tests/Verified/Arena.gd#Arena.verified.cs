//HintName: Arena.cs
using Godot;
using GodotBridge;

namespace GDScript.Bridge;

[GlobalClass]
public partial class Arena : GdScriptBridge
{
    NodePath game_startup
    {
        get => GdObject.Get("game_startup");
        set => GdObject.Set("game_startup", value);
    }

    public Arena(GodotObject gdObject) : base(gdObject) {}

    Variant on_configure(Variant deck_id_in) => GdObject.Call("on_configure", deck_id_in);
}