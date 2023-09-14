using Godot;

namespace CardGame.Core.Data;

[GlobalClass]
public partial class DeckData : GodotObject
{
    [Export] public int Id { get; set; }
    [Export] public string Name { get; set; } = null!;
    [Export] public int Terrain { get; set; }
    [Export] public int Castle { get; set; }
    [Export] public int Race { get; set; }
    [Export] public int[] Cards { get; set; } = null!;
}