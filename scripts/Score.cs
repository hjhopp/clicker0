using Godot;
using System;

public partial class Score : Label
{
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        Text = $"{GameManager.Instance.Score}";

        GameManager.Instance.ScoreChanged += OnScoreChanged;
    }

    private void OnScoreChanged(int newScore)
    {
        Text = $"{GameManager.Instance.Score}";
    }
}
