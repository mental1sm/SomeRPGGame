using System.Linq;
using Godot;

namespace Desert.Combat.Godot.Mob.UI;

/// <summary>
/// Отрисовывает шкалу ХП моба и обновляет ее при получении урона
/// </summary>
public partial class MobHpBar : ColorRect
{
	private Logic.MobController _mobController;
	private Label _hpLabel;
	private Util.SharedBattleSignal _sharedBattleSignal;
	public override void _Ready()
	{
		_mobController = (Logic.MobController) GetTree().Root.GetChildren().Last().GetNode("CharacterBody3D2");
		_hpLabel = (Label) this.GetChildren().Last(child => child.Name == "HpValueLabel");
		_sharedBattleSignal = GetNode<Util.SharedBattleSignal>("/root/SharedBattleSignal");
		_sharedBattleSignal.TakeDamageSignal += OnDamageTaken;
		_hpLabel.Text = $"{_mobController.Entity.CurrentHealth} / {_mobController.Entity.MaxHealth}";
	}

	private void OnDamageTaken(int emitterId)
	{
		_hpLabel.Text = $"{_mobController.Entity.CurrentHealth} / {_mobController.Entity.MaxHealth}";
	}
}
