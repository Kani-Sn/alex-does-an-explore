using System;
using Godot;

public partial class PlayerState : Node
{
	private Cheats Cheats;
	public float BaseSpeed = 1.3f;
	public float JumpVelocity = 5.5f;
	public float MeshRotationSpeed = 15;
	public float Speed;
	public float ExtraBatteryLevel = 100;
	public Vector3 velocity;

	public bool IsRunning = false;
	public bool CanRun = true;

	public override void _Ready()
	{
		Cheats = GetNodeOrNull("/root/Cheats") as Cheats;
		Speed = BaseSpeed;
	}

	public override void _PhysicsProcess(double delta)
	{
		AdjustExtraBatteryLevel((float)delta);
	}

	private void AdjustExtraBatteryLevel(float delta)
	{
		if (IsRunning && ExtraBatteryLevel > 0 && velocity != Vector3.Zero && !Cheats.UnlimitedBattery)
		{
			ExtraBatteryLevel -= 0.5f;
		}
		else if (!IsRunning && ExtraBatteryLevel < 100 ||
		 velocity == Vector3.Zero && ExtraBatteryLevel < 100 ||
		 IsRunning && Cheats.UnlimitedBattery)
		{
			ExtraBatteryLevel += 0.2f;
		}
		else if (ExtraBatteryLevel <= 0)
		{
			IsRunning = false;
			Speed = BaseSpeed;
			CanRun = false;
		}
		else if (ExtraBatteryLevel >= 100 && !CanRun)
		{
			CanRun = true;
		}

		if (ExtraBatteryLevel > 100)
		{
			ExtraBatteryLevel = 100;
		}
	}
}
