using Godot;
using System;
using System.Collections;
using System.Collections.Generic;

public partial class MeshInstance3D2 : MeshInstance3D
{

	private float _speed = 5F;

	[Export]
	public float Speed
	{
		get => _speed;
		set => _speed = value;
	}

	public enum MoveDirection
	{
		Forward,
		Backward,
		Left,
		Right,
		None
	}

	private List<MoveDirection> CheckInput()
	{
		List<MoveDirection> directions = new List<MoveDirection>();
		if (Input.IsActionPressed("ui_up"))
		{
			directions.Add(MoveDirection.Forward);
		}

		if (Input.IsActionPressed("ui_down"))
		{
			directions.Add(MoveDirection.Backward);
		}

		if (Input.IsActionPressed("ui_left"))
		{
			directions.Add(MoveDirection.Left);
		}

		if (Input.IsActionPressed("ui_right"))
		{
			directions.Add(MoveDirection.Right);
		}

		return directions;
	}
	
	public override void _Ready()
	{
	}
	
	public override void _Process(double delta)
	{
		List<MoveDirection> directions = CheckInput();
		Vector3 movement = new Vector3();
		
		if (directions.Contains(MoveDirection.Forward))
		{
			movement.Z -= this._speed;
		}

		if (directions.Contains(MoveDirection.Backward))
		{
			movement.Z += this._speed;
		}

		if (directions.Contains(MoveDirection.Left))
		{
			movement.X -= this._speed;
		}

		if (directions.Contains(MoveDirection.Right))
		{
			movement.X += this._speed;
		}

		float deltaF = float.Parse(delta.ToString());
		Translate(movement * new Vector3(deltaF, deltaF, deltaF));
		
	}
}
