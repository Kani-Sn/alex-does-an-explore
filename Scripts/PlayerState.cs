using Godot;

public partial class PlayerState : Node
{

	public float BaseSpeed { get; set; } = 1.3f;
	public float JumpVelocity { get; set; } = 5;
	public float MeshRotationSpeed { get; set; } = 10;
	public float Speed { get; set; }
	public bool IsRunning { get; set; } = false;

	public override void _Ready()
	{
		Speed = BaseSpeed;
	}
}
