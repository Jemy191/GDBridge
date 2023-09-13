using Godot;

namespace GDBridge;

public abstract class GDScriptBridge
{
    protected readonly GodotObject GdObject;

    protected GDScriptBridge(GodotObject gdObject) => GdObject = gdObject;
}