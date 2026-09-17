using Godot;
using System;

public partial class PlayerSettings : Control
{
	public PlayerState PlayerState;
	public Settings Settings;
	private Label CameraSensLabel;

	public override void _Ready()
	{
		PlayerState = GetNodeOrNull("/root/PlayerState") as PlayerState;
		Settings = GetNodeOrNull("/root/Settings") as Settings;
		GetNode<CheckBox>("%RunToggleCheck").ButtonPressed = Settings.IsRunToggle;
		CameraSensLabel = GetNode<Label>("%CameraSensLabel");
	}

	private void IsToggleRun(bool isToggle)
	{
		Settings.IsRunToggle = isToggle;
	}

	private void SetCameraSens(float value)
	{
		CameraSensLabel.Text = value.ToString();
		Settings.CameraSensitivity = value;
	}
}
