using Godot;

namespace GdBridge;

public abstract class ScriptBridge : GodotObject
{
    protected readonly GodotObject GdObject;

    protected ScriptBridge(GodotObject gdObject) => GdObject = gdObject;
}