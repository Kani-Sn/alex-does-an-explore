using Godot;

public partial class Settings : Node
{
	public bool IsRunToggle { get; set; } = true;
	public int CurrentFPSLimit { get; set; }
	public float CameraSensitivity { get; set; } = 0.1f;

	public void SetFPSLimit(int maxFPS)
	{
		if (GetTree().Paused)
		{
			CurrentFPSLimit = maxFPS;
		}
		Engine.MaxFps = maxFPS;
	}
}
