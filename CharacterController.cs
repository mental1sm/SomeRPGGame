using Godot;
using System;
using Desert.Combat.Godot.Util;

public partial class CharacterController : CharacterBody3D
{
	private const float Speed = 1.8f;
	private const float JumpVelocity = 3.5f;

	public Vector3 CurrentPlayerPosition
	{
		get => GlobalPosition;
		set => GlobalPosition = value;
	}
	private AnimationPlayer _animationPlayer;

	// Get the gravity from the project settings to be synced with RigidBody nodes.
	public float gravity = ProjectSettings.GetSetting("physics/3d/default_gravity").AsSingle();

	public override void _Ready()
	{
		this._animationPlayer = (AnimationPlayer) GetNode("girl_animated_2/AnimationPlayer");
		this._animationPlayer.Play("Idle");
		Input.MouseMode = Input.MouseModeEnum.Captured;
	}

	public override void _PhysicsProcess(double delta)
	{
		Vector3 velocity = Velocity;
		
		if (!IsOnFloor())
			velocity.Y -= gravity * (float)delta;
		
		if (Input.IsActionJustPressed("ui_accept") && IsOnFloor())
			velocity.Y = JumpVelocity;
		
		Vector2 inputDir = Input.GetVector("ui_right", "ui_left", "ui_down", "ui_up");
		Vector3 direction = (Transform.Basis * new Vector3(inputDir.X, 0, inputDir.Y)).Normalized();
		
		if (direction != Vector3.Zero)
		{
			velocity.X = direction.X * Speed;
			velocity.Z = direction.Z * Speed;
			this._animationPlayer.Play(name: "Walking", customSpeed: 2f);
		}
		else
		{
			this._animationPlayer.Play("Idle");
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
			velocity.Z = Mathf.MoveToward(Velocity.Z, 0, Speed);
		}

		Velocity = velocity;
		MoveAndSlide();
	}
	
	public override void _Input(InputEvent @event)
	{
		if (@event is InputEventMouseMotion)
		{
			InputEventMouseMotion motion = (InputEventMouseMotion)@event;
			Rotation = new Vector3(Rotation.X, Rotation.Y - motion.Relative.X / 1000, 0);
		}

		if (Input.IsActionJustReleased("ui_cancel"))
		{
			Console.WriteLine("Esc pressed!");
			switch (Input.MouseMode)
			{
				case Input.MouseModeEnum.Captured:
				{
					Input.MouseMode = Input.MouseModeEnum.Visible;
					Console.WriteLine("Changed visibility to Visible");
					break;
				}

				case Input.MouseModeEnum.Visible:
				{
					Input.MouseMode = Input.MouseModeEnum.Captured;
					Console.WriteLine("Changed visibility to Captured");
					break;
				}
			}
			
		}
		
	}
}
