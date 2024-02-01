using System;
using System.Linq;
using Godot;

namespace Desert.Combat.Godot.Player.UI;

/// <summary>
/// Контроллер шкалы энергии
/// </summary>
public partial class EnergyBarController : ColorRect
{
    private Logic.PlayerBattleController _playerBattleController;
    private Label _energyLabel;
    private Util.SharedBattleSignal _sharedBattleSignal;
    public override void _Ready()
    {
        _playerBattleController = (Logic.PlayerBattleController) GetTree().Root.GetChildren().Last().GetNode("CharacterBody3D");
        _energyLabel = (Label) this.GetChildren().Last(child => child.Name == "EnergyValueLabel");
        _sharedBattleSignal = GetNode<Util.SharedBattleSignal>("/root/SharedBattleSignal");
        _sharedBattleSignal.DrainedEnergySignal += OnEnergyDrain;
        _energyLabel.Text = $"{_playerBattleController.PlayerEntity.CurrentEnergy} / {_playerBattleController.PlayerEntity.MaxEnergy}";
    }

    private void OnEnergyDrain(int emitterId)
    {
        Console.WriteLine($"Received signal from entity with id {emitterId}");
        _energyLabel.Text = $"{_playerBattleController.PlayerEntity.CurrentEnergy} / {_playerBattleController.PlayerEntity.MaxEnergy}";
    }
}