using Godot;
using System;

public partial class bed : item_container
{
	public void _on_mouse_exited(){
		GD.Print("Bed Exited");
	}
}
