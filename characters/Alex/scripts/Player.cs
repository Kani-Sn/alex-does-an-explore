using Godot;

public partial class Player : CharacterBody3D
{
	public PlayerState PlayerState { get; set; }
	public Settings Settings { get; set; }

	// Nodes
	private Control PauseMenu;
	private CameraArm CameraArm;
	private MeshInstance3D Mesh;

	public override void _Ready()
	{
		PlayerState = GetNodeOrNull("/root/PlayerState") as PlayerState;
		Settings = GetNodeOrNull("/root/Settings") as Settings;
		Input.MouseMode = Input.MouseModeEnum.Captured;
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
			velocity.Y = PlayerState.JumpVelocity;
		}

		Vector2 inputDir = Input.GetVector("left", "right", "forward", "backward");
		Vector3 direction = (Transform.Basis * new Vector3(inputDir.X, 0, inputDir.Y)).Rotated(Vector3.Up, CameraArm.Rotation.Y).Normalized();

		velocity.X = direction == Vector3.Zero ? Mathf.MoveToward(Velocity.X, 0, PlayerState.Speed) : direction.X * PlayerState.Speed;
		velocity.Z = direction == Vector3.Zero ? Mathf.MoveToward(Velocity.Z, 0, PlayerState.Speed) : direction.Z * PlayerState.Speed;

		Velocity = velocity;
		MoveAndSlide();
	}

	private void RotateMesh(float delta)
	{
		Vector3 velocity = Velocity;
		Vector3 newRotation = Mesh.Rotation;
		if (velocity != Vector3.Zero)
		{
			newRotation.Y = Mathf.LerpAngle(Mesh.Rotation.Y, CameraArm.Rotation.Y, delta * PlayerState.MeshRotationSpeed);
			Mesh.Rotation = newRotation;
		}
	}

	private void SetRunSpeed()
	{
		float runSpeed = PlayerState.CanRun ? 3 : 1;

		if (!PlayerState.IsRunning && !PlayerState.CanRun)
		{
			return;
		}

		if (Input.IsActionJustPressed("run") || Input.IsActionJustReleased("run") && PlayerState.IsRunning && !Settings.IsRunToggle)
		{
			PlayerState.IsRunning = !PlayerState.IsRunning;
			PlayerState.Speed = PlayerState.BaseSpeed * (PlayerState.IsRunning ? runSpeed : 1);
		}
	}
}