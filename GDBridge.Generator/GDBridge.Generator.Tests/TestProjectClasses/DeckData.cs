using Godot;
using JetBrains.Annotations;

namespace CardGame.Core.Data;

[GlobalClass, UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
public partial class DeckData : GodotObject
{
    [Export] public int Id { get; set; }
    [Export] public string Name { get; set; } = null!;
    [Export] public int Terrain { get; set; }
    [Export] public int Castle { get; set; }
    [Export] public int Race { get; set; }
    [Export] public int[] Cards { get; set; } = null!;

    public static implicit operator DeckData(GameMaster.Data.DeckData data) => new()
    {
        Id = data.Id,
        Name = data.Name,
        Terrain = data.Terrain,
        Castle = data.Castle,
        Race = data.Race,
        Cards = data.Cards.Select(c => (int)c).ToArray()
    };
}