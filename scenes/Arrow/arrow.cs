using Godot;
using System;

public partial class arrow : Area2D
{
	[Export]
	int movementSpeed = 550;
	Vector2 direction = new Vector2(0f, -1f);
	Vector2 pos = new Vector2();

	public override void _Ready()
	{
		pos = Position;
	}

	public override void _Process(double delta)
	{
		pos.X += (float)(direction.X * movementSpeed * delta);
		pos.Y += (float)(direction.Y * movementSpeed * delta);

		this.Position = pos;
		// GD.Print(Position);

	}
}
