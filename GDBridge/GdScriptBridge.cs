using Godot;

namespace GdBridge;

public abstract class GdScriptBridge : GodotObject
{
    protected readonly GodotObject GdObject;

    protected GdScriptBridge(GodotObject gdObject) => GdObject = gdObject;
}