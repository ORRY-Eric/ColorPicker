using Godot;
using System;

public partial class ui : Control
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	private MeshInstance3D GetCube()
	{
		return GetParent().GetNode<MeshInstance3D>("Cube");
	}
	
	private StandardMaterial3D GetCubeMaterial()
	{
		MeshInstance3D Cube = GetCube();
		return (StandardMaterial3D)Cube.GetSurfaceOverrideMaterial(0);
	}
	
	private void ChangeColorCube(Color col)
	{
		MeshInstance3D Cube = GetCube();
		StandardMaterial3D mat = new StandardMaterial3D();
		mat.AlbedoColor = col;
		Cube.SetSurfaceOverrideMaterial(0, mat);
	}
	
	private void WhenCubeChangeColor()
	{
		StandardMaterial3D mat = GetCubeMaterial();
		GetNode<SpinBox>("CanvasLayer/R/SpinBox").Value = mat.AlbedoColor.R8;
		GetNode<SpinBox>("CanvasLayer/G/SpinBox").Value = mat.AlbedoColor.G8;
		GetNode<SpinBox>("CanvasLayer/B/SpinBox").Value = mat.AlbedoColor.B8;
		GetNode<SpinBox>("CanvasLayer/A/SpinBox").Value = mat.AlbedoColor.A8;
	}
	
	private void _on_spin_box_value_changed_R(double value)
	{
		StandardMaterial3D mat = GetCubeMaterial();
		Color temp = new Color((float)value / 255, mat.AlbedoColor.G, mat.AlbedoColor.B, mat.AlbedoColor.A);
		ChangeColorCube(temp);
	}
	
	private void _on_spin_box_value_changed_Green(double value)
	{
		StandardMaterial3D mat = GetCubeMaterial();
		Color temp = new Color(mat.AlbedoColor.R, (float)value / 255, mat.AlbedoColor.B, mat.AlbedoColor.A); 
		ChangeColorCube(temp);
	}
	
	private void _on_spin_box_value_changed_Blue(double value)
	{
		StandardMaterial3D mat = GetCubeMaterial();
		Color temp = new Color(mat.AlbedoColor.R, mat.AlbedoColor.G, (float)value / 255, mat.AlbedoColor.A);
		ChangeColorCube(temp);
	}
	
	private void _on_spin_box_value_changed_Alpha(double value)
	{
		StandardMaterial3D mat = GetCubeMaterial();
		Color temp = new Color(mat.AlbedoColor.R, mat.AlbedoColor.G, mat.AlbedoColor.B, (float)value / 255);
		ChangeColorCube(temp);
	}
	
	private void _on_color_picker_button_color_changed(Color color)
	{
		ChangeColorCube(color);
		GetNode<ColorPickerButton>("CanvasLayer/Text Color Picker/ColorPickerButton").Color = color;
		WhenCubeChangeColor();
	}

}
