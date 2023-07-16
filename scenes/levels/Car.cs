using Godot;
using System;

public partial class Car : Sprite2D
{
	Vector2 pos = new Vector2();
	int speed = 10;
	public override void _Ready(){
		Vector2 screenSize = GetViewportRect().Size;
		Vector2 nodeSize = GetScaledSpriteSize(GetRect().Size);
		Vector2 centeredPosition = (screenSize / 2);
		Position = centeredPosition;
		// GD.Print(Position);
	}

	public override void _Process(double delta){
	}

	private Vector2 GetScaledSpriteSize(Vector2 size){
		Vector2 ScaledSize = new Vector2();
		ScaledSize.X = size.X * Scale.X;
		ScaledSize.Y = size.Y * Scale.Y;

		return ScaledSize;
	}
}
