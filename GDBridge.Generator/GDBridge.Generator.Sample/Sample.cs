using Godot;

namespace GDBridge.Generator.Sample;

class Sample : Node
{
    [Export(PropertyHint.NodePathValidTypes, ArenaBridge.GDClassName)] NodePath arena = null!;
        
    void Init()
    {
        var myGDScript = new GdScriptBridgeFactory(this).ResolveBridge<ArenaBridge>(arena);

        myGDScript.on_configure(42);
    }
}