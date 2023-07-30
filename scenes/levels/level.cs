using Godot;
using System;

public partial class level : Node2D
{
	// preload a scene
	private PackedScene arrow_scene;
	private PackedScene grenade_scene;

	private CharacterBody2D _playNode;
	private Node2D _projectile;
	private Camera2D CameraNode;
	public override void _Ready()
	{
		// Sprite2D mySprite = (Sprite2D)GetNode("MySprite");
		// Sprite2D car = (Sprite2D)GetNode("Car");
		// car.RotationDegrees = 90;
		// CharacterBody2D player = (CharacterBody2D)GetNode("Player");

		arrow_scene = (PackedScene)ResourceLoader.Load("res://scenes/Arrow/arrow.tscn");
		grenade_scene = (PackedScene)ResourceLoader.Load("res://scenes/Grenade/grenade.tscn");

		_playNode = (CharacterBody2D)GetNode("Player");
		_projectile = (Node2D)GetNode("Projectiles");

	}

	public override void _Process(double delta)
	{
	}


	public void _on_player_primary_action(Vector2 direction, Vector2 position)
	{
		RigidBody2D arrow = (RigidBody2D)arrow_scene.Instantiate();
		arrow.Position = position;
		arrow.LinearVelocity = direction * 600;
		arrow.Rotation = direction.Angle();
		_projectile.AddChild(arrow);
	}

	public void _on_player_secondary_action(Vector2 direction, Vector2 position)
	{
		RigidBody2D grenade = (RigidBody2D)grenade_scene.Instantiate();
		grenade.Position = position;
		grenade.LinearVelocity = direction * 500;
		_projectile.AddChild(grenade);
	}

	public void _on_house_player_entered()
	{
		var tween = GetTree().CreateTween();

		CameraNode = (Camera2D)GetNode("Player/Camera2D");
		tween.TweenProperty(CameraNode, "zoom", new Vector2(2, 2), 1);

	}

	public void _on_house_player_exited()
	{
		Tween tween = GetTree().CreateTween();

		tween.TweenProperty(GetNode("Player/Camera2D"), "zoom", new Vector2((float)1.2, (float)1.2), 1);
	}
}
