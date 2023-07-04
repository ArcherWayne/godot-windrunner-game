using Godot;
using System;

public partial class level : Node2D
{
	public override void _Ready()
	{
		// Sprite2D mySprite = (Sprite2D)GetNode("MySprite");
		Sprite2D car = (Sprite2D)GetNode("Car");
		car.RotationDegrees = 90;
	}
}
