using Godot;
using System;


public partial class tree : StaticBody2D
{

	[Signal]
	public delegate void TestSginalEventHandler();

	private void _on_test_custom_signal_body_entered(Node body){
		EmitSignal(SignalName.TestSginal);
	}

	private void _on_mouse_entered(){
		GD.Print("1");
	}

}
