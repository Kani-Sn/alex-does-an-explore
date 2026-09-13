using Godot;
using System;

public partial class CameraArm : SpringArm3D
{
	private const int MinLength = 2;
	private const int MaxLength = 10;

	private Vector2 _mouse_position = new(0.0f, 0.0f);
	private float _total_pitch = 0.0f;
	[Export(PropertyHint.Range, "0.01, 1")] public float Sensitivity = 0.1f;

	public static float ZoomSpeed { get; set; } = 0.5f;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		AlterZoom();
		UpdateRotation();
	}

	public override void _Input(InputEvent @event)
	{
		if (@event is InputEventMouseMotion mouseMotionEvent)
		{
			_mouse_position = mouseMotionEvent.Relative;
		}
	}

	private void UpdateRotation()
	{
		if (Input.MouseMode == Input.MouseModeEnum.Captured)
		{
			_mouse_position *= Sensitivity;
			float yaw = _mouse_position.X;
			float pitch = _mouse_position.Y;
			_mouse_position = Vector2.Zero;

			pitch = Mathf.Clamp(pitch, -35 - _total_pitch, 80 - _total_pitch);
			_total_pitch += pitch;

			RotateY(Mathf.DegToRad(-yaw));
			RotateObjectLocal(new(1.0f, 0.0f, 0.0f), Mathf.DegToRad(-pitch));
		}
	}

	private void AlterZoom()
	{
		if (Input.IsActionJustPressed("camera_zoom_in"))
		{
			this.SpringLength -= ZoomSpeed * (Input.IsKeyPressed(Key.Shift) ? 0.2f : 1);
		}
		if (Input.IsActionJustPressed("camera_zoom_out"))
		{
			this.SpringLength += ZoomSpeed * (Input.IsKeyPressed(Key.Shift) ? 0.2f : 1);
		}

		this.SpringLength = Math.Clamp(this.SpringLength, MinLength, MaxLength);
	}
}
