using Godot;
using System;

public partial class principal : Node3D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		// Mets par défaut la couleur Noir
		StandardMaterial3D mat = new StandardMaterial3D(); 
		mat.AlbedoColor = new Color(0, 0, 0);
		GetNode<MeshInstance3D>("Cube").SetSurfaceOverrideMaterial(0, mat);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
