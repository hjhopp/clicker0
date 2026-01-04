using Godot;

public partial class NormalScoreParticles : GpuParticles2D
{
    public override void _Ready()
    {
        GameManager.Instance.ScoreChanged += OnScoreChanged;

        CallDeferred(MethodName.GetParentCenter);
    }

    public override void _ExitTree()
    {
        GameManager.Instance.ScoreChanged -= OnScoreChanged;
    }

    private void GetParentCenter()
    {
        var parent = GetParent();

        if (parent is Control control)
        {
            Position = control.Size / 2;
        }
        else
        {
            Position = Vector2.Zero;
        }
    }

    private void OnScoreChanged(int score)
    {
        if (Emitting)
        {
            Restart();
        }

        Emitting = true;
    }
}