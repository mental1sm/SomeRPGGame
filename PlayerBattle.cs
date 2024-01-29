using Godot;
using System;

public partial class PlayerBattle : CharacterBody3D
{
	public float gravity = ProjectSettings.GetSetting("physics/3d/default_gravity").AsSingle();
	
	private AnimationPlayer _animationPlayer;
	
	public override void _Ready()
	{
		this._animationPlayer = (AnimationPlayer) GetNode("girl_animated_2/AnimationPlayer");
		this._animationPlayer.Play("Idle");
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
