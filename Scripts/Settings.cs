using Godot;

public partial class Settings : Node
{
	public bool IsRunToggle = true;
	public int CurrentFPSLimit;
	public float CameraSensitivity = 0.1f;

	public void SetFPSLimit(int maxFPS)
	{
		if (GetTree().Paused)
		{
			CurrentFPSLimit = maxFPS;
		}
		Engine.MaxFps = maxFPS;
	}
}
