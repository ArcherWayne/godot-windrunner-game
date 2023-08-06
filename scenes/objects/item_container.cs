using Godot;
using System;

public partial class item_container : StaticBody2D
{
	public void _on_mouse_entered(){
		GD.Print("Container Entered");
	}
}
