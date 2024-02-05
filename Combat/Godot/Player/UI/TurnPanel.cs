using Godot;
using System.Linq;
using Desert.Combat.Domain.Entity;
using Desert.Combat.Godot.Util;

/// <summary>
/// Отрисовывает панель текущего хода и обновляет ее
/// </summary>
public partial class TurnPanel : ColorRect
{
	private BattleManager _battleManager;
	private SharedBattleSignal _sharedBattleSignal;
	public override void _Ready()
	{
		_battleManager = (BattleManager)GetTree().Root.GetChildren().Last().GetNode("BattleManager");
		_sharedBattleSignal = GetNode<SharedBattleSignal>("/root/SharedBattleSignal");
		_sharedBattleSignal.NewTurnSignal += OnNewTurn;
	}

	private void OnNewTurn(int currentTurnEntityGameId)
	{
		Entity currentTurnEntity = _battleManager.CurrentTurnEntity;
		Label turnLabel = GetNode<Label>("CurrentTurn");
		turnLabel.Text = currentTurnEntity.Name;
	}
	
	
}

public class Util
{
}
