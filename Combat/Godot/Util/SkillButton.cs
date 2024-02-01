using System;
using System.Linq;
using Desert.Combat.Domain;
using Desert.Combat.Domain.Skill;
using Godot;

namespace Desert.Combat.Godot.Util;

public partial class SkillButton : Button
{
	private Domain.Player _player;
	private Skill _containedSkill;
	
	public SkillButton(Skill skill)
	{
		_containedSkill = skill;
		this.Text = skill.Name;
		this.Size = new Vector2(56, 56);
		AddThemeFontSizeOverride("font_size", 10);
	}

	public override void _Ready()
	{
		Console.WriteLine("Инициализация скилла...");
		Util.BattleManager battleManager = (Util.BattleManager)GetTree().Root.GetChildren().Last().GetNode("BattleManager");
		//_player = battleManager.Player;
	}

	public override void _Pressed()
	{
		Util.BattleManager battleManager = (Util.BattleManager)GetTree().Root.GetChildren().Last().GetNode("BattleManager");
		//Domain.Mob target = battleManager.GetRandomTarget();
		//_player.Attack(target: target, skill: _containedSkill);
	}
}
