using Godot;
using System;

public partial class GraphicSettings : TabBar
{
	[Export] private Label FOVLabel;
	[Export] private Label CameraSensLabel;
	private Player PlayerCharacter;
	private Camera3D PlayerCamera;
	private SpringArm3D PlayerCameraArm;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		PlayerCharacter = GetOwner().GetOwner<Player>();
		PlayerCamera = PlayerCharacter.GetNode<Camera3D>("%Camera");
		PlayerCameraArm = PlayerCharacter.GetNode<SpringArm3D>("%CameraArm");

		FOVLabel.Text = PlayerCamera.Fov.ToString();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void SetCameraFOV(int value)
	{
		FOVLabel.Text = value.ToString();
		PlayerCamera.Fov = value;
	}

	private void SetCameraSens(float value)
	{
		CameraSensLabel.Text = (value * 10).ToString("0.0");
	}
}
