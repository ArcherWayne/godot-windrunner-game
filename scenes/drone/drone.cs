using Godot;
using System;
// using Math;

public partial class drone : CharacterBody2D
{
	Vector2 startPoint = new Vector2();

	// Time
	int maxRate = 600;
	double currentRate = 0;

	// Frequency
	int xFreq = 12;
	int yFreq = 15;


	public override void _Ready()
	{
		Vector2 screenSize = GetViewportRect().Size;
		startPoint = (screenSize / 2);
		Position = startPoint;
	}

	public override void _Process(double delta)
	{
	}

	public override void _PhysicsProcess(double delta){
		// Amplitude
		Vector2 screenSize = GetViewportRect().Size;
		startPoint = (screenSize / 2);
		int xAmp = (int)screenSize.X / 2;
		int yAmp = (int)screenSize.Y / 2;

		Vector2 lissajousPos = new Vector2();
		float xDegrees = 2 * Mathf.Pi * (float)xFreq * (float)currentRate;
		float xRadians = (float)(xDegrees * Math.PI / 180);
		lissajousPos.X = 
			(float)(xAmp * Math.Sin(xRadians));

		float yDegrees = 2 * Mathf.Pi * (float)yFreq * (float)currentRate;
		float yRadians = (float)(yDegrees * Math.PI / 180);
		lissajousPos.Y = 
			(float)(yAmp * Math.Sin(yRadians));

		if (currentRate <= maxRate){
			currentRate += 0.01;
		}
		else {
			currentRate = 0;
		}

		Position = startPoint + lissajousPos;

		MoveAndSlide();
	}
}
