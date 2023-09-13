using Godot;

namespace GDBridge;

public class GdScriptBridgeFactory
{
    readonly Node currentNode;
    public GdScriptBridgeFactory(Node currentNode) => this.currentNode = currentNode;

    public T ResolveBridge<T>(NodePath nodePath) where T : GDScriptBridge
    {
        var node = currentNode.GetNode(nodePath);
        var output = (T)Activator.CreateInstance(typeof(T), node)!;
        return output;
    }
}