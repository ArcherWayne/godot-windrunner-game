using Godot;
using System;

public partial class grenade : RigidBody2D
{
	AnimationPlayer explosion = new AnimationPlayer();
	public void explode(){
		explosion = (AnimationPlayer)GetNode("AnimationPlayer");
		explosion.Play("Explosion");
	}

	public void delete(){
		QueueFree();
	}
}
