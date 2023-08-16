using Godot;
using System;


public partial class ui : CanvasLayer
{
	private Label ArrowLabel;
	private globals globals;
	private TextureProgressBar textureProgressBar;

	public override void _Ready()
	{
		ArrowLabel = GetNode<Label>("ArrowCounter/VBoxContainer/Label");
		globals = GetNode<globals>("/root/globals");
		textureProgressBar = GetNode<TextureProgressBar>("HealthBar/MarginContainer/TextureProgressBar");
	}

	public override void _Process(double delta)
	{
		UpdateArrowLabel();
		UpdatePlayerHealth();
	}

	public void UpdateArrowLabel()
	{
		ArrowLabel.Text = globals.arrow_amount.ToString();
	}

	public void UpdatePlayerHealth()
	{
		textureProgressBar.Value = globals.PlayerHealth;
		GD.Print(textureProgressBar.Value);
	}
}

