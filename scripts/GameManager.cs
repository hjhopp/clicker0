using Godot;
using System;

public partial class GameManager : Node
{
    public static GameManager Instance { get; private set; }

    public int Score { get; private set; }

    [Signal]
    public delegate void ScoreChangedEventHandler(int newScore);

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        Instance = this;
    }

    public void IncrementScore(int amount)
    {
        Score += amount;

        EmitSignal(SignalName.ScoreChanged, Score);
    }
}
