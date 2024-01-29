using System;
using System.Linq;
using Godot;

namespace Desert.Combat.Godot;

public partial class EnergyBarController : ColorRect
{
    private PlayerBattleController _playerBattleController;
    private Label _energyLabel;
    private SharedBattleSignal _sharedBattleSignal;
    public override void _Ready()
    {
        _playerBattleController = (PlayerBattleController) GetTree().Root.GetChildren().Last().GetNode("CharacterBody3D");
        _energyLabel = (Label) this.GetChildren().Last(child => child.Name == "EnergyValueLabel");
        _sharedBattleSignal = GetNode<SharedBattleSignal>("/root/SharedBattleSignal");
        _sharedBattleSignal.DrainedEnergySignal += OnEnergyDrain;
        _energyLabel.Text = $"{_playerBattleController.PlayerEntity.CurrentEnergy} / {_playerBattleController.PlayerEntity.MaxEnergy}";
    }

    private void OnEnergyDrain(int emitterId)
    {
        Console.WriteLine($"Received signal from entity with id {emitterId}");
    }
}