using Godot;
using System;
using System.Linq;

public partial class PlayerVars : Node
{
	public Node CurrentScene { get; set; }
	public Vector3 PreviousPlayerPosition { get; set; }
	public override void _Ready()
	{
		this.CurrentScene = GetTree().CurrentScene;
	}

	public void SwitchScene(string path, Vector3 currentPlayerPosition)
	{
		CallDeferred(nameof(DeferredSwitchScene), path, currentPlayerPosition);
	}

	public void DeferredSwitchScene(string path, Vector3 currentPlayerPosition)
	{
		this.PreviousPlayerPosition = currentPlayerPosition;
		CurrentScene.Free();

		var nextScene = (PackedScene)GD.Load(path);
		CurrentScene = nextScene.Instantiate();
		GetTree().Root.AddChild(CurrentScene);
	}

	public void SwitchSceneWithPreviousPosition(string path, Vector3 currentPlayerPosition)
	{
		CallDeferred(nameof(DefferedSwitchSceneWithPreviousPosition), path, currentPlayerPosition);
	}

	public void DefferedSwitchSceneWithPreviousPosition(string path, Vector3 currentPlayerPosition)
	{
		Vector3 savedPreviousPosition = this.PreviousPlayerPosition;
		DeferredSwitchScene(path, currentPlayerPosition);
		CharacterController characterController = (CharacterController) GetTree().Root.GetChildren().Last().GetNode("CharacterBody3D");

		characterController.GlobalPosition = savedPreviousPosition;
	}
	
}
