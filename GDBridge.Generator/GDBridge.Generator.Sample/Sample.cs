using Godot;

namespace GDBridge.Generator.Sample;

class Sample : Node
{
    [Export(PropertyHint.NodePathValidTypes, ArenaBridge.GDClassName)] NodePath arena = null!;
        
    void Init()
    {
        var myGDScript = ArenaBridge.From(GetNode(arena));
        
        myGDScript.on_configure(42);
    }
}