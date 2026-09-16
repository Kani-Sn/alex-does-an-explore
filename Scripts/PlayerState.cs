using System;
using Godot;

public partial class PlayerState : Node
{

	public float BaseSpeed { get; set; } = 1.3f;
	public float JumpVelocity { get; set; } = 5.5f;
	public float MeshRotationSpeed { get; set; } = 15;
	public float Speed { get; set; }
	public float ExtraBatteryLevel { get; set; } = 100;
	public Vector3 velocity;

	public bool IsRunning { get; set; } = false;
	public bool CanRun { get; set; } = true;

	public override void _Ready()
	{
		Speed = BaseSpeed;
	}

	public override void _PhysicsProcess(double delta)
	{
		AdjustExtraBatteryLevel((float)delta);
	}

	private void AdjustExtraBatteryLevel(float delta)
	{
		if (IsRunning && ExtraBatteryLevel > 0 && velocity != Vector3.Zero)
		{
			ExtraBatteryLevel -= 0.5f;
		}
		else if (!IsRunning && ExtraBatteryLevel < 100 || velocity == Vector3.Zero && ExtraBatteryLevel < 100)
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
