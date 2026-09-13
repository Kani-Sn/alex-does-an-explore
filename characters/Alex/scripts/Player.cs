using Godot;
using System;

public partial class Player : CharacterBody3D
{
	// Editable during runtime
	[Export(PropertyHint.Range, "1.0, 5.0")] public float BaseSpeed { get; set; } = 1.3f;
	[Export(PropertyHint.Range, "4.0, 10.0")] public float JumpVelocity { get; set; } = 5;
	[Export(PropertyHint.Range, "5, 20")] public float MeshRotationSpeed { get; set; } = 10;
	public float Speed { get; set; }
	[Export] public bool IsRunToggle = true;
	private bool IsRunning = false;

	// Nodes
	private Control PauseMenu;
	private CameraArm CameraArm;
	private MeshInstance3D Mesh;

	public override void _Ready()
	{
		Input.MouseMode = Input.MouseModeEnum.Captured;
		Speed = BaseSpeed;
		PauseMenu = GetNode<Control>("Pausemenu");
		CameraArm = GetNode<CameraArm>("CameraArm");
		Mesh = GetNode<MeshInstance3D>("Mesh");
	}

	public override void _PhysicsProcess(double delta)
	{
		UpdateMovement(delta);
	}

	public override void _Process(double delta)
	{
		RotateMesh((float)delta);
		SetRunSpeed();
	}

	public override void _Input(InputEvent @event)
	{
		// Pause Menu
		if (Input.IsActionJustPressed("pause_menu"))
		{
			Input.MouseMode = Input.MouseModeEnum.Visible;
			PauseMenu.Visible = true;
			GetTree().Paused = true;
		}
	}

	private void UpdateMovement(double delta)
	{
		Vector3 velocity = Velocity;

		// Add the gravity
		if (!IsOnFloor())
		{
			velocity += GetGravity() * (float)delta;
		}

		if (Input.IsActionJustPressed("jump") && IsOnFloor())
		{
			velocity.Y = JumpVelocity;
		}

		Vector2 inputDir = Input.GetVector("left", "right", "forward", "backward");
		Vector3 direction = (Transform.Basis * new Vector3(inputDir.X, 0, inputDir.Y)).Rotated(Vector3.Up, CameraArm.Rotation.Y).Normalized();

		velocity.X = direction == Vector3.Zero ? Mathf.MoveToward(Velocity.X, 0, Speed) : direction.X * Speed;
		velocity.Z = direction == Vector3.Zero ? Mathf.MoveToward(Velocity.Z, 0, Speed) : direction.Z * Speed;

		Velocity = velocity;
		MoveAndSlide();
	}

	private void RotateMesh(float delta)
	{
		Vector3 velocity = Velocity;
		Vector3 newRotation = Mesh.Rotation;
		if (velocity != Vector3.Zero)
		{
			newRotation.Y = Mathf.LerpAngle(Mesh.Rotation.Y, CameraArm.Rotation.Y, delta * MeshRotationSpeed);
			Mesh.Rotation = newRotation;
		}
	}

	private void SetRunSpeed()
	{
		if (Input.IsActionJustPressed("run") || Input.IsActionJustReleased("run") && IsRunning && !IsRunToggle)
		{
			IsRunning = !IsRunning;
			Speed = BaseSpeed * (IsRunning ? 5 : 1);
		}
	}
}