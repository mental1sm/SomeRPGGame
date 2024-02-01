using System.Collections.Generic;
using System.Linq;
using Desert.Combat.Domain;
using Desert.Combat.Domain.Skill;
using Godot;
using SkillButton = Desert.Combat.Godot.Util.SkillButton;

namespace Desert.Combat.Godot.Player.UI;

public partial class SkillContainer : HBoxContainer
{
	private Logic.PlayerBattleController _playerBattleController;
	
	public override void _Ready()
	{
		_playerBattleController = (Logic.PlayerBattleController) GetTree().Root.GetChildren().Last().GetNode("CharacterBody3D");
		List<ColorRect> slots = new List<ColorRect>();
		foreach (var child in this.GetChildren())
		{
			if (child.GetType() == typeof(ColorRect))
			{
				slots.Add((ColorRect) child);
			}
		}

		int counter = 0;
		foreach (Skill skill in _playerBattleController.PlayerEntity.SkillSet.Skills)
		{
			SkillButton skillButton = new SkillButton(skill);
			slots[counter].AddChild(skillButton);
			counter++;
		}
	}
	
	public override void _Process(double delta)
	{
		
	}
}