using Godot;
using System;

public partial class item : Area2D
{
	public float RotationSpeed = 5f;
	// private Sprite2D image;

	// public Node globals;

	public override void _Ready()
	{

		string[] AvailableOptions = new string[]
		{
			"laser",
			"grenade",
			"health"
		};

		Random random = new();
		int randomIndex = random.Next(0, AvailableOptions.Length);
		string type = AvailableOptions[randomIndex];

		if(type == "laser")
		{
			// image = (Sprite2D)GetNode("Sprite2D");
			// image.Modulate = Colors("ff00ff");
		}
	}

	public override void _Process(double delta)
	{
		Rotation += RotationSpeed * (float)delta;
	}

	public void _on_body_entered(Node body)
	{
		var globals = GetNode<globals>("/root/globals");
		globals.PlayerHealth += 10;
		// GD.Print(globals.PlayerHealth);
	}
}
