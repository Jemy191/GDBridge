//HintName: Battlefield.cs
using Godot;
using GdBridge;

namespace GDScript.Bridge;

[GlobalClass]
public partial class Battlefield : GdScriptBridge
{
    public Battlefield(GodotObject gdObject) : base(gdObject) {}
}