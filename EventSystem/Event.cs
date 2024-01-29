using System;
using System.ComponentModel;
using Godot;

namespace Desert.EventSystem;

public class Event
{
	private string _id;
	
	public string Id
	{
		get => _id;
	}
	
	public string Description { get; set; }
	
}
