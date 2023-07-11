using Godot;
using System;

public partial class level : Node2D
{
	// preload a scene
	private PackedScene arrow_scene;

	private CharacterBody2D _playNode;
	public override void _Ready()
	{
		// Sprite2D mySprite = (Sprite2D)GetNode("MySprite");
		Sprite2D car = (Sprite2D)GetNode("Car");
		car.RotationDegrees = 90;
		// CharacterBody2D player = (CharacterBody2D)GetNode("Player");

		arrow_scene = (PackedScene)ResourceLoader.Load("res://scenes/Arrow/arrow.tscn");

		_playNode = (CharacterBody2D)GetNode("Player");
	}

	public override void _Process(double delta)
	{
	}


	public void _on_player_primary_action(){
		GD.Print("custom_signal_primary_action");
		Area2D arrow = (Area2D)arrow_scene.Instantiate();
		arrow.Position = _playNode.Position;
		AddChild(arrow);
	}

	public void _on_player_secondary_action(){
		GD.Print("custom_signal_secondary_action");
	}

}
