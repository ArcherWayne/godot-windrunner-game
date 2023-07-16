using Godot;
using System;

public partial class level : Node2D
{
	// preload a scene
	private PackedScene arrow_scene;
	private PackedScene grenade_scene;

	private CharacterBody2D _playNode;
	private Node2D _projectile;
	public override void _Ready()
	{
		// Sprite2D mySprite = (Sprite2D)GetNode("MySprite");
		Sprite2D car = (Sprite2D)GetNode("Car");
		car.RotationDegrees = 90;
		// CharacterBody2D player = (CharacterBody2D)GetNode("Player");

		arrow_scene = (PackedScene)ResourceLoader.Load("res://scenes/Arrow/arrow.tscn");
		grenade_scene = (PackedScene)ResourceLoader.Load("res://scenes/Grenade/grenade.tscn");

		_playNode = (CharacterBody2D)GetNode("Player");
		_projectile = (Node2D)GetNode("Projectiles");
	}

	public override void _Process(double delta)
	{
	}


	public void _on_player_primary_action(){
		GD.Print("custom_signal_primary_action");
		Area2D arrow = (Area2D)arrow_scene.Instantiate();
		arrow.Position = _playNode.Position;
		_projectile.AddChild(arrow);
	}

	public void _on_player_secondary_action(){
		GD.Print("custom_signal_secondary_action");
		RigidBody2D grenade = (RigidBody2D)grenade_scene.Instantiate();
		grenade.Position = _playNode.Position;
		grenade.LinearVelocity = Vector2.Up * 500;
		_projectile.AddChild(grenade);
	}

}
