using Godot;
using System;

public partial class PlayerSettings : Control
{
	private Player PlayerCharacter { get; set; }

	public override void _Ready()
	{
		PlayerCharacter = GetOwner<Control>().GetOwner<Player>();
		GetNode<CheckBox>("%RunToggleCheck").ButtonPressed = PlayerCharacter.IsRunToggle;
	}

	private void SpeedChanged(int selected)
	{
		switch (selected)
		{
			case 0:
				PlayerCharacter.BaseSpeed = 1.3f;
				break;
			case 1:
				PlayerCharacter.BaseSpeed = 2;
				break;
			case 2:
				PlayerCharacter.BaseSpeed = 3;
				break;
			case 3:
				PlayerCharacter.BaseSpeed = 4;
				break;
		}
		PlayerCharacter.Speed = PlayerCharacter.BaseSpeed;
	}

	private void ToggleRun(bool isToggle)
	{
		PlayerCharacter.IsRunToggle = isToggle;
	}
}
