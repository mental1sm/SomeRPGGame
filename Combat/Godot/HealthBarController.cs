using System;
using System.Linq;
using Godot;

namespace Desert.Combat.Godot;

public partial class HealthBarController : ColorRect
{
	private PlayerBattleController _playerBattleController;
	private Label _hpLabel;
	private SharedBattleSignal _sharedBattleSignal;
	public override void _Ready()
	{
		_playerBattleController = (PlayerBattleController) GetTree().Root.GetChildren().Last().GetNode("CharacterBody3D");
		_hpLabel = (Label) this.GetChildren().Last(child => child.Name == "HpValueLabel");
		_sharedBattleSignal = GetNode<SharedBattleSignal>("/root/SharedBattleSignal");
		_sharedBattleSignal.TakeDamageSignal += OnDamageTaken;
		_hpLabel.Text = $"{_playerBattleController.PlayerEntity.CurrentHealth} / {_playerBattleController.PlayerEntity.MaxHealth}";
	}

	private void OnDamageTaken(int emitterId)
	{
		Console.WriteLine($"Received signal from entity with id {emitterId}");
	}
}
