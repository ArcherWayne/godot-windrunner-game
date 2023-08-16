using Godot;
using System;

public partial class globals : Node
{
	// public int arrow_amount = 20;
	[Signal]
	public delegate void PlayerHealthChangedEventHandler(int NewPlayerHealth);

	public int arrow_amount = 20;
	// public int PlayerHealth = 50;
	private int _playerHealth = 50;
	public int PlayerHealth
	{
		get
		{
			return _playerHealth;
		}
		set
		{
			_playerHealth = Mathf.Clamp(value, 0, 100);
			// EmitSignal(nameof(PlayerHealthChangedEventHandler), _playerHealth);
		}
	}

	public override void _Ready()
	{
		// int PlayerHealth = 50;
	}

	public override void _Process(double delta){
	}
}
