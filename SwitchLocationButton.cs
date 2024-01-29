using Godot;
using System;
using System.Linq;

public partial class SwitchLocationButton : Button
{
	[Export]
	public string Path { get; set; }
	
	[Export]
	public bool LoadPreviousPosition { get; set; }
	public override void _Ready()
	{
	}

	public override void _Pressed()
	{
		PlayerVars global = (PlayerVars)GetNode("/root/PlayerVars");
		Console.WriteLine(GetTree().Root.GetChildren().Last().GetChildren());
		CharacterController characterController = (CharacterController) GetTree().Root.GetChildren().Last().GetNode("CharacterBody3D");
		if (this.LoadPreviousPosition)
		{
			global.SwitchSceneWithPreviousPosition(string.Format("res://{0}.tscn", this.Path), characterController.GlobalPosition);
		}
		else
		{
			global.SwitchScene(string.Format("res://{0}.tscn", this.Path), characterController.GlobalPosition);
		}
	}
}
