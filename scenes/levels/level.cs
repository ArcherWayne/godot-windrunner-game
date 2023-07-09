using Godot;
using System;

public partial class level : Node2D
{
	// preload a scene
	private PackedScene arrow_scene;

	public override void _Ready()
	{
		// Sprite2D mySprite = (Sprite2D)GetNode("MySprite");
		Sprite2D car = (Sprite2D)GetNode("Car");
		car.RotationDegrees = 90;

		CharacterBody2D player = (CharacterBody2D)GetNode("Player");

		arrow_scene = (PackedScene)ResourceLoader.Load("res://scenes/Arrow/arrow.tscn");
	}

	public override void _Process(double delta)
	{
	}


	public void _on_player_primary_action(){
		GD.Print("custom_signal_primary_action");
	}

	public void _on_player_secondary_action(){
		GD.Print("custom_signal_secondary_action");
	}

}
