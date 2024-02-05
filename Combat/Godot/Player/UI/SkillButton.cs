using System;
using System.Linq;
using Desert.Combat.Domain.Skill;
using Desert.Combat.Godot.Player.Logic;
using Desert.Combat.Godot.Util;
using Godot;

namespace Desert.Combat.Godot.Player.UI;

/// <summary>
/// Префаб кнопки скилла
/// </summary>
public partial class SkillButton : Button
{
	private EntityBehaviorController _behaviorController;
	private Skill _containedSkill;
	
	public SkillButton(Skill skill)
	{
		_containedSkill = skill;
		Text = skill.Name.ToCharArray()[0].ToString();
		Size = new Vector2(56, 56);
		AddThemeFontSizeOverride("font_size", 20);
		TooltipText = skill.Name;
	}

	public override void _Ready()
	{
		Console.WriteLine("Инициализация скилла...");
		_behaviorController = ((PlayerBattleController)GetTree().Root.GetChildren().Last().GetNode("CharacterBody3D")).EntityBehaviorController;
	}

	public override void _Pressed()
	{
		_behaviorController.UseSkill(1, skill: _containedSkill);
	}
}
