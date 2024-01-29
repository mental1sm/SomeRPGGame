using Desert.Combat.Domain;
using Godot;

namespace Desert.Combat.Godot;

public partial class PlayerBattleController : CharacterBody3D
{
	private float gravity = ProjectSettings.GetSetting("physics/3d/default_gravity").AsSingle();
	
	private AnimationPlayer _animationPlayer;
	private SharedBattleSignal _sharedBattleSignal;
	
	public Player PlayerEntity { get; set; }
	
	public override void _Ready()
	{
		this._animationPlayer = (AnimationPlayer) GetNode("girl_animated_2/AnimationPlayer");
		this._animationPlayer.Play("Idle");
		_sharedBattleSignal = GetNode<SharedBattleSignal>("/root/SharedBattleSignal");
		_sharedBattleSignal.EmitSignal(SharedBattleSignal.SignalName.EndTurnSignal, 0);
		PlayerEntity = new Player(id: 0, emitSignalStrategy: _sharedBattleSignal.EmitBattleSignal);
		//EmitSignal(SignalName.TakeDamageSignal, 0);
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
