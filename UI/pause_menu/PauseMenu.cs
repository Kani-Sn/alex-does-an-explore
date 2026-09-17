using Godot;
using System;

public partial class PauseMenu : Control
{
	private Settings Settings { get; set; }

	private Panel DefaultPanel { get; set; }
	private Panel SettingsPanel { get; set; }

	public override void _Ready()
	{
		Settings = GetNodeOrNull("/root/Settings") as Settings;
		DefaultPanel = GetNode<Panel>("Default");
		SettingsPanel = GetNode<Panel>("Settings");
		DefaultPanel.Visible = true;
		SettingsPanel.Visible = false;
	}

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
		Settings.SetFPSLimit(Settings.CurrentFPSLimit); // RESET FPS TO USER VALUE
		this.Visible = false;
		GetTree().Paused = false;
	}

	private void ToggleSettingsPanel()
	{
		DefaultPanel.Visible = !DefaultPanel.Visible;
		SettingsPanel.Visible = !SettingsPanel.Visible;
	}
}
