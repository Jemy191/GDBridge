using Godot;

namespace GDBridge.Generator.Sample
{
    class Sample : Node
    {
        [Export(PropertyHint.NodePathValidTypes, ArenaBridge.ClassName)] NodePath arena = null!;
        
        void Init()
        {
            var myGDScript = new GdScriptBridgeFactory(this).ResolveBridge<ArenaBridge>(arena);

            myGDScript.on_configure(42);
        }
    }
}

partial class ArenaBridge
{
    public void DoSomethingElse(int deckId) => on_configure(deckId);
}