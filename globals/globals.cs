using Godot;
using System;

public partial class globals : Node
{
	// public int arrow_amount = 20;

	// public override void _Ready()
	// {
	public int arrow_amount = 20;
	// }

	public override void _Process(double delta){
		GD.Print(arrow_amount);
	}
}
