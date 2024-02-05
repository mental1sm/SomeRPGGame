using System;
using System.Linq;
using Desert.Combat.Domain.Entity;
using Desert.Combat.Godot.Util;
using Desert.Combat.Infrastructure;
using Desert.Combat.Repository;
using Godot;

namespace Desert.Combat.Godot.Player.Logic;

/// <summary>
/// Контроллер игрока в бою
/// </summary>
public partial class PlayerBattleController : CharacterBody3D
{
	private float gravity = ProjectSettings.GetSetting("physics/3d/default_gravity").AsSingle();
	
	private AnimationPlayer _animationPlayer;
	private SharedBattleSignal _sharedBattleSignal;
	public EntityBehaviorController EntityBehaviorController { get; set; }
	
	[Export]
	public string EntityId { get; set; }
	public Entity PlayerEntity { get; set; }
	
	public override void _Ready()
	{
		_animationPlayer = (AnimationPlayer) GetNode("girl_animated_2/AnimationPlayer");
		_animationPlayer.Play("Idle");
		_sharedBattleSignal = GetNode<SharedBattleSignal>("/root/SharedBattleSignal");
		LoadEntity();
		BattleManager battleManager = (BattleManager)GetTree().Root.GetChildren().Last().GetNode("BattleManager");
		EntityBehaviorController = new EntityBehaviorController(battleManager, PlayerEntity);
		EntityBehaviorController.RegisterEntity();
		EntityBehaviorController.NotifyReady();
	}

	private void LoadEntity()
	{
		GameContext context = Infrastructure.DatabaseManager.GetInstance().GetContext();
		PlayerEntity = new EntityRepository(context).GetById(EntityId);
		PlayerEntity.EmitSignalStrategy = _sharedBattleSignal.EmitBattleSignal;
	}

	public override void _PhysicsProcess(double delta)
	{
		Vector3 velocity = Velocity;
		
		if (!IsOnFloor())
			velocity.Y -= gravity * (float)delta;

		Velocity = velocity;
		MoveAndSlide();
	}
	
}
