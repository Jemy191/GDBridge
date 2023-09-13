using GdBridge;
using GDScript.Bridge;
using Godot;

namespace GDBridge.Generator.Sample
{
    class Sample : Node
    {
        [Export(PropertyHint.NodePathValidTypes, Arena.ClassName)] NodePath arena = null!;
        
        void Init()
        {
            var myGDScript = new GdScriptBridgeFactory(this).ResolveNode<Arena>(arena);

            myGDScript.OnConfigure(42);
        }
    }
}

namespace GDScript.Bridge
{
    partial class Arena
    {
        public void OnConfigure(int deckId) => on_configure(deckId);
    }
}