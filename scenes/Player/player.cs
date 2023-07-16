using Godot;
using System;

public partial class player : CharacterBody2D
{
	int movementSpeed = 500;
	Vector2 playerPos = new Vector2();

	bool can_rotate_car = true;

	private Node2D _arrowStartPosition;

	[Signal]
	public delegate void primaryActionEventHandler();
	[Signal]
	public delegate void secondaryActionEventHandler();

	public override void _Ready(){
		_arrowStartPosition = (Node2D)GetNode("ArrowStartPosition");
	}


	public override void _Process(double delta)
	{
		// input
		var carNode = GetNode<Sprite2D>("../Car");
		var rotateCarTimer = GetNode<Timer>("rotateCarTimer");

		// arrow shooting input
		if (Input.IsActionJustPressed("primary action") && can_rotate_car){
			// for the purpose of practise, access car node from this node
			// and the primary action is to rotate the car 90 degrees clockwsie. 
			carNode.RotationDegrees += 90;

			can_rotate_car = false;
			rotateCarTimer.Start();

			// randomly selected a marker2D for the laser start point. 
			// emit the position we selected. 
			var arrow_markers = _arrowStartPosition.GetChildren();

			Random arrowRandomMarker = new Random();
			// a randomed reference of that Node;
			Node selected_marker = arrow_markers[arrowRandomMarker.Next(0, 2)];
			// Vector2 selectedMarkerPos = selected_marker.Prosition;

			EmitSignal(SignalName.primaryAction);
		}

		if (Input.IsActionJustPressed("secondary action")){
			carNode.RotationDegrees += 180;

			EmitSignal(SignalName.secondaryAction);
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

	private void _on_timer_timeout(){
		can_rotate_car = true;
	}
}
