using Godot;
using System;

public partial class PlayerHud : Control
{
	private Label Speed { get; set; }
	private Label JumpVelocity { get; set; }
	private PlayerState PlayerState { get; set; }
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		PlayerState = GetNodeOrNull("/root/PlayerState") as PlayerState;
		Speed = GetNode<Label>("%Speed");
		JumpVelocity = GetNode<Label>("%Jump Velocity");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Speed.Text = String.Format("Speed: {0}", PlayerState.Speed);
		JumpVelocity.Text = String.Format("Jump Velocity: {0}", PlayerState.JumpVelocity);
	}
}
