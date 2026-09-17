using Godot;
using System;

public partial class GraphicSettings : TabBar
{
	[Export] private Label FOVLabel;
	[Export] private Label CameraSensLabel;
	[Export] private TextEdit FPSLimit;

	private Player PlayerCharacter;
	private Camera3D PlayerCamera;
	private SpringArm3D PlayerCameraArm;

	private Settings Settings { get; set; }

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Settings = GetNodeOrNull("/root/Settings") as Settings;
		PlayerCharacter = GetOwner().GetOwner<Player>();
		PlayerCamera = PlayerCharacter.GetNode<Camera3D>("%Camera");
		PlayerCameraArm = PlayerCharacter.GetNode<SpringArm3D>("%CameraArm");

		FOVLabel.Text = PlayerCamera.Fov.ToString();
		FPSLimit.Text = Engine.MaxFps.ToString();
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

	private void SetFPSLimit()
	{
		Settings.SetFPSLimit(FPSLimit.Text.ToInt());
	}
}
