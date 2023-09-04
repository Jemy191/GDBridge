using Godot;

namespace GdBridge;

public class ScriptBridgeFactory
{
    readonly Node currentNode;
    public ScriptBridgeFactory(Node currentNode) => this.currentNode = currentNode;

    public T ResolveNode<T>(NodePath nodePath) where T : ScriptBridge
    {
        var node = currentNode.GetNode(nodePath);
        var output = (T)Activator.CreateInstance(typeof(T), node)!;
        return output;
    }
}