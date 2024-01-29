using Godot;
using System;
using System.Linq;

public partial class CameraController : Node3D
{
	public override void _Ready()
	{
	}
	
	public override void _Process(double delta)
	{
	}

	public override void _Input(InputEvent @event)
	{
		if (@event is InputEventMouseMotion)
		{
			InputEventMouseMotion motion = (InputEventMouseMotion)@event;
			Rotation = new Vector3(Mathf.Clamp(Rotation.X - motion.Relative.Y / 1000, -1, .4f), Rotation.Y, 0);
		}
	}
}
