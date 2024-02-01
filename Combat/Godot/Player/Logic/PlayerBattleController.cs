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
	
	[Export]
	public string EntityId { get; set; }
	public Entity PlayerEntity { get; set; }
	
	public override void _Ready()
	{
		this._animationPlayer = (AnimationPlayer) GetNode("girl_animated_2/AnimationPlayer");
		this._animationPlayer.Play("Idle");
		_sharedBattleSignal = GetNode<SharedBattleSignal>("/root/SharedBattleSignal");
		LoadEntity();
	}

	private void LoadEntity()
	{
		Console.WriteLine("Loading Context...");
		GameContext context = Infrastructure.DatabaseManager.GetInstance().GetContext();
		Console.WriteLine("Loading Repo...");
		PlayerEntity = new EntityRepository(context).GetById(EntityId);
		Console.WriteLine("Loaded!");
		Console.WriteLine(PlayerEntity.Name);
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
