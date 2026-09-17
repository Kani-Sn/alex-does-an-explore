using Godot;
using System;

public partial class GraphicSettings : TabBar
{
	[Export] private Label FOVLabel;
	[Export] private Label CameraSensLabel;
	[Export] private TextEdit FPSLimit;

	private Player PlayerCharacter;
	private Camera3D PlayerCamera;

	private Settings Settings;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Settings = GetNodeOrNull("/root/Settings") as Settings;
		PlayerCharacter = GetOwner().GetOwner<Player>();
		PlayerCamera = PlayerCharacter.GetNode<Camera3D>("%Camera");

		FOVLabel.Text = PlayerCamera.Fov.ToString();
		FPSLimit.Text = Engine.MaxFps.ToString();
		CameraSensLabel.Text = Settings.CameraSensitivity.ToString();
	}

	private void SetCameraFOV(int value)
	{
		FOVLabel.Text = value.ToString();
		PlayerCamera.Fov = value;
	}

	private void SetFPSLimit()
	{
		Settings.SetFPSLimit(FPSLimit.Text.ToInt());
	}
}
