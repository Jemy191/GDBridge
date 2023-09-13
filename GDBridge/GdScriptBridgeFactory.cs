using Godot;

namespace GdBridge;

public class GdScriptBridgeFactory
{
    readonly Node currentNode;
    public GdScriptBridgeFactory(Node currentNode) => this.currentNode = currentNode;

    public T ResolveNode<T>(NodePath nodePath) where T : GdScriptBridge
    {
        var node = currentNode.GetNode(nodePath);
        var output = (T)Activator.CreateInstance(typeof(T), node)!;
        return output;
    }
}