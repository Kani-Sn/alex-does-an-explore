using Godot;
using System;

public partial class CheatSettings : TabBar
{
	private Cheats Cheats;
	public CheckButton UnlimitedBattery;

	public override void _Ready()
	{
		Cheats = GetNodeOrNull("/root/Cheats") as Cheats;
		UnlimitedBattery = GetNode<CheckButton>("%UnlimitedBattery");
	}

	public void SetUnlimitedBattery(bool isUnlimited)
	{
		Cheats.UnlimitedBattery = isUnlimited;
	}
}
