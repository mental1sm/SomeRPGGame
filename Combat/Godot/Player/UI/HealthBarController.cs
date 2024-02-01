using System;
using System.Linq;
using Godot;

namespace Desert.Combat.Godot.Player.UI;

/// <summary>
/// Контроллер шкалы ХП
/// </summary>
public partial class HealthBarController : ColorRect
{
	private Logic.PlayerBattleController _playerBattleController;
	private Label _hpLabel;
	private Util.SharedBattleSignal _sharedBattleSignal;
	public override void _Ready()
	{
		_playerBattleController = (Logic.PlayerBattleController) GetTree().Root.GetChildren().Last().GetNode("CharacterBody3D");
		_hpLabel = (Label) this.GetChildren().Last(child => child.Name == "HpValueLabel");
		_sharedBattleSignal = GetNode<Util.SharedBattleSignal>("/root/SharedBattleSignal");
		_sharedBattleSignal.TakeDamageSignal += OnDamageTaken;
		_hpLabel.Text = $"{_playerBattleController.PlayerEntity.CurrentHealth} / {_playerBattleController.PlayerEntity.MaxHealth}";
	}

	private void OnDamageTaken(int emitterId)
	{
		Console.WriteLine($"Received signal from entity with id {emitterId}");
		_hpLabel.Text = $"{_playerBattleController.PlayerEntity.CurrentHealth} / {_playerBattleController.PlayerEntity.MaxHealth}";
	}
}
