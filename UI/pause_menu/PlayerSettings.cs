using Godot;
using System;

public partial class PlayerSettings : Control
{
	public PlayerState PlayerState { get; set; }
	public Settings Settings { get; set; }

	public override void _Ready()
	{
		PlayerState = GetNodeOrNull("/root/PlayerState") as PlayerState;
		Settings = GetNodeOrNull("/root/Settings") as Settings;
		GetNode<CheckBox>("%RunToggleCheck").ButtonPressed = Settings.IsRunToggle;
	}

	private void SpeedChanged(int selected)
	{
		switch (selected)
		{
			case 0:
				PlayerState.BaseSpeed = 1.3f;
				break;
			case 1:
				PlayerState.BaseSpeed = 2;
				break;
			case 2:
				PlayerState.BaseSpeed = 3;
				break;
			case 3:
				PlayerState.BaseSpeed = 4;
				break;
		}

		PlayerState.Speed = PlayerState.BaseSpeed;
	}

	private void IsToggleRun(bool isToggle)
	{
		Settings.IsRunToggle = isToggle;
	}
}
