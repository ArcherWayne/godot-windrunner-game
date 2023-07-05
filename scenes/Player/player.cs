using Godot;
using System;

public partial class player : Node2D
{
	int movementSpeed = 200;
	Vector2 playerPos = new Vector2();
	public override void _Process(double delta)
	{
		// input
		var direction = Input.GetVector("left", "right", "up", "down");

		// Position += direction * movementSpeed * delta;
		playerPos.X += direction.X * movementSpeed * (float)delta;
		playerPos.Y += direction.Y * movementSpeed * (float)delta;

		Position = playerPos;

		// arrow shooting input
		if (Input.IsActionPressed("primary action")){
			GD.Print("shoot arrow");

		}


	}
}
