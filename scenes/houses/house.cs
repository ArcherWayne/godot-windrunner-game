using Godot;
using System;

public partial class house : Area2D
{
	[Signal]
	public delegate void PlayerEnteredEventHandler();

	[Signal]
	public delegate void PlayerExitedEventHandler();
	public void _on_body_entered(Node body){
		EmitSignal(SignalName.PlayerEntered);

	}

	public void _on_body_exited(Node body){
		EmitSignal(SignalName.PlayerExited);

	}


}
