using Godot;
using System;

public partial class player : CharacterBody2D
{
	int movementSpeed = 1200;
	Vector2 playerPos = new Vector2();

	public override void _Ready(){
	}


	public override void _Process(double delta)
	{
		// input
		var carNode = GetNode<Sprite2D>("../Car");

		// arrow shooting input
		if (Input.IsActionJustPressed("primary action")){
			// for the purpose of practise, access car node from this node
			// and the primary action is to rotate the car 90 degrees clockwsie. 
			carNode.RotationDegrees += 90;
		}
	}

	public override void _PhysicsProcess(double delta){
		var direction = Input.GetVector("left", "right", "up", "down");
		// Position += direction * movementSpeed * delta;
		// playerPos.X += direction.X * movementSpeed * (float)delta;
		// playerPos.Y += direction.Y * movementSpeed * (float)delta;
		Velocity = direction * movementSpeed * (float)delta;

		GD.Print(Velocity);
		MoveAndSlide();
	}
}
