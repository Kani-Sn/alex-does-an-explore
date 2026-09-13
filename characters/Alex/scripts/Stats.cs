using Godot;
using System;

public partial class Stats : Resource
{
  [Export(PropertyHint.Range, "1.0, 5.0")] public float BaseSpeed { get; private set; } = 1.3f;
  [Export] public float CurrentSpeed { get; private set; }
  [Export(PropertyHint.Range, "4.0, 10.0")] public float JumpVelocity { get; private set; } = 5;
  [Export(PropertyHint.Range, "5, 20")] public float MeshRotationSpeed { get; private set; } = 10;
  [Export] public bool IsRunToggle { get; private set; } = true;
  [Export] public bool IsRunning { get; private set; } = false;
  [Export] public float CameraSensitivity { get; private set; } = 0.1f;

  public void SetBaseSpeed(float newBaseSpeed)
  {
	BaseSpeed = newBaseSpeed;
  }

  public void SetCurrentSpeed(float newSpeed)
  {
	CurrentSpeed = newSpeed;
  }

  public void ToggleRunning()
  {
	IsRunning = !IsRunning;
	CurrentSpeed = BaseSpeed * (IsRunning ? 5 : 1);
  }

  public void SetIsRunToggle(bool isToggle)
  {
	IsRunToggle = isToggle;
  }
}
