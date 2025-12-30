using Godot;
using System;

public partial class ScoreButton : Button
{
    public override void _Pressed()
    {
        GameManager.Instance.IncrementScore(1);
    }
}
