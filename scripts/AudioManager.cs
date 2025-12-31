using Godot;
using System;
using System.Collections.Generic;

public partial class AudioManager : Node
{
    public static AudioManager Instance { get; private set; } = null!;

    [Export] private AudioStreamPlayer2D[] ClickSoundPlayers = [];

    private int _nextPlayerIdx = 0;

    public override void _Ready()
    {
        Instance = this;
    }

    public void PlayClickSound()
    {
        if (ClickSoundPlayers.Length == 0)
        {
            return;
        }

        var player = ClickSoundPlayers[_nextPlayerIdx];

        player.Stop();
        player.Play();

        _nextPlayerIdx = (_nextPlayerIdx + 1) % ClickSoundPlayers.Length;
    }
}
