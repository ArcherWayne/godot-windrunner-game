using Godot;
using System;

public partial class arrow : RigidBody2D
{
	

	public override void _Ready()
	{
	}

	public override void _Process(double delta){

	}

	public void _on_body_entered(Node body){
		GD.Print("arrow collied");
		QueueFree();
	}

	public void _on_timer_timeout(){
		QueueFree();
	}

}