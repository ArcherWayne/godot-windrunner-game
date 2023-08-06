using Godot;
using System;


public partial class ui : CanvasLayer
{
	private Label ArrowLabel;
	private globals globals;

	public override void _Ready()
	{
		ArrowLabel = GetNode<Label>("ArrowCounter/VBoxContainer/Label");
		globals = GetNode<globals>("/root/globals");
	}

	public override void _Process(double delta)
	{
		UpdateArrowLabel();
	}

	public void UpdateArrowLabel()
	{
		ArrowLabel.Text = globals.arrow_amount.ToString();
	}
}

