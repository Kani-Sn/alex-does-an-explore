using Godot;
using System;

public partial class PauseMenu : Control
{
	private Panel DefaultPanel { get; set; }
	private Panel SettingsPanel { get; set; }

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		DefaultPanel = GetNode<Panel>("Default");
		SettingsPanel = GetNode<Panel>("Settings");
		DefaultPanel.Visible = true;
		SettingsPanel.Visible = false;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void QuitButtonPressed()
	{
		GetTree().Quit();
	}

	private void ResumeButtonPressed()
	{
		Input.MouseMode = Input.MouseModeEnum.Captured;
		this.Visible = false;
		GetTree().Paused = false;
	}

	private void ToggleSettingsPanel()
	{
		DefaultPanel.Visible = !DefaultPanel.Visible;
		SettingsPanel.Visible = !SettingsPanel.Visible;
	}
}
