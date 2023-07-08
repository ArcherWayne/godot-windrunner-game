using Godot;
using System;

public partial class level : Node2D
{

	public override void _Ready()
	{
		// Sprite2D mySprite = (Sprite2D)GetNode("MySprite");
		Sprite2D car = (Sprite2D)GetNode("Car");
		car.RotationDegrees = 90;

		CharacterBody2D player = (CharacterBody2D)GetNode("Player");
	}

	public override void _Process(double delta)
	{
		// Input.IsActionPressed("left");
	}

	private void _on_area_2d_body_entered(Node body){
		GD.Print("body has entered");
		GD.Print("the entered body is" + body.Name);
	}
}
