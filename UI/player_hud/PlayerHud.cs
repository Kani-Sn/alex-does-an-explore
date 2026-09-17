using Godot;
using System;

public partial class PlayerHud : Control
{
	private PlayerState PlayerState;
	private Label Speed;
	private Label JumpVelocity;
	private Label ExtraBattery;
	private Label FPSCounter;
	private ProgressBar ExtraBatteryLevel;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		PlayerState = GetNodeOrNull("/root/PlayerState") as PlayerState;
		Speed = GetNode<Label>("%Speed");
		JumpVelocity = GetNode<Label>("%Jump Velocity");
		ExtraBattery = GetNode<Label>("%Battery Level");
		FPSCounter = GetNode<Label>("%FPSCounter");
		ExtraBatteryLevel = GetNode<ProgressBar>("%ExtraBatteryLevel");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Speed.Text = String.Format("Speed: {0}", PlayerState.Speed);
		JumpVelocity.Text = String.Format("Jump Velocity: {0}", PlayerState.JumpVelocity);
		ExtraBattery.Text = String.Format("Extra Battery: {0}", PlayerState.ExtraBatteryLevel);
		FPSCounter.Text = Engine.GetFramesPerSecond().ToString();
		ExtraBatteryLevel.Value = PlayerState.ExtraBatteryLevel;
	}
}
