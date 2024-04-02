using Godot;
using System;

public partial class BoxColor : ColorRect
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	private void ChangeTextColorRGB_SpinBox()
	{
		GetParent().GetNode<SpinBox>("R/SpinBox").Value = Color.R8;
		GetParent().GetNode<SpinBox>("G/SpinBox").Value = Color.G8;
		GetParent().GetNode<SpinBox>("B/SpinBox").Value = Color.B8;
		GetParent().GetNode<SpinBox>("A/SpinBox").Value = Color.A8;
	}
	
	private void _on_gui_input(InputEvent @event)
	{
		if(@event.AsText() == "Left Mouse Button")
		{
			StandardMaterial3D mat = new StandardMaterial3D();
			mat.AlbedoColor = Color;
			GetParent().GetParent().GetParent().GetNode<MeshInstance3D>("Cube").SetSurfaceOverrideMaterial(0, mat);
			
			ChangeTextColorRGB_SpinBox();
		}
	}
}



