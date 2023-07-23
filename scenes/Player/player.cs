using Godot;
using System;

public partial class player : CharacterBody2D
{
	int movementSpeed = 500;
	Vector2 playerPos = new Vector2();

	// bool can_rotate_car = true;

	private Node2D _arrowStartPosition;
	private Node2D GrenadeStartPosition;
	private Marker2D randomArrowStartPosition;

	[Signal]
	public delegate void primaryActionEventHandler(Vector2 direction, Vector2 position);
	[Signal]
	public delegate void secondaryActionEventHandler(Vector2 direction, Vector2 position);

	public override void _Ready(){
		_arrowStartPosition = (Node2D)GetNode("ArrowStartPosition");
		GrenadeStartPosition = (Node2D)GetNode("GrenadeStartPosition");
	}


	public override void _Process(double delta)
	{
		// input
		// var carNode = GetNode<Sprite2D>("../Car");
		// var rotateCarTimer = GetNode<Timer>("rotateCarTimer");

		// rotate player
		LookAt(GetGlobalMousePosition());

		// arrow shooting input
		if (Input.IsActionJustPressed("primary action")){
			// for the purpose of practise, access car node from this node
			// and the primary action is to rotate the car 90 degrees clockwsie. 
			// carNode.RotationDegrees += 90;

			// can_rotate_car = false;
			// rotateCarTimer.Start();

			// randomly selected a marker2D for the laser start point. 
			// emit the position we selected. 

			Random arrowRandomMarker = new Random();
			int irandomedarrowMarker = arrowRandomMarker.Next(0, 3);
			randomArrowStartPosition = (Marker2D)GetNode("ArrowStartPosition/Marker2D" + irandomedarrowMarker.ToString());

			Vector2 direction = (GetGlobalMousePosition() - Position).Normalized();

			Vector2 selectedMarkerPos = randomArrowStartPosition.GlobalPosition;

			EmitSignal(SignalName.primaryAction, direction, selectedMarkerPos);
		}

		if (Input.IsActionJustPressed("secondary action")){
			// carNode.RotationDegrees += 180;
			Vector2 direction = (GetGlobalMousePosition() - Position).Normalized();

			EmitSignal(SignalName.secondaryAction, direction, GrenadeStartPosition.GlobalPosition);
		}
	}

	public override void _PhysicsProcess(double delta){
		var direction = Input.GetVector("left", "right", "up", "down");
		// Velocity automatically includes the effect of delta
		// so no need to repeat the process
		// which will slow you down for the times of framerate
		Velocity = direction * movementSpeed;

		MoveAndSlide();
	}
}
