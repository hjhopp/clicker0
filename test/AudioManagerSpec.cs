using Godot;
using GdUnit4;
using static GdUnit4.Assertions;
using System.Reflection;

[TestSuite]
[RequireGodotRuntime]
public class AudioManagerSpec()
{
    private AudioStreamPlayer2D[] FetchPlayers(AudioManager audioManager)
    {
        return typeof(AudioManager)
            .GetField("ClickSoundPlayers", BindingFlags.NonPublic | BindingFlags.Instance)
            .GetValue(audioManager) as AudioStreamPlayer2D[];
    }

    private int FetchIdx(AudioManager audioManager)
    {
        return (int)typeof(AudioManager)
            .GetField("_nextPlayerIdx", BindingFlags.NonPublic | BindingFlags.Instance)
            .GetValue(audioManager);
    }

    [TestCase]
    public void IsManagerNotNull()
    {
        var audioManager = AutoFree(new AudioManager());

        AssertThat(audioManager).IsNotNull();
    }

    [TestCase]
    public void ClickPlayersEmptyOnInit()
    {
        var audioManager = AutoFree(new AudioManager());
        var players = FetchPlayers(audioManager);

        AssertThat(players.Length).IsEqual(0);
    }

    [TestCase]
    public void IdxStaysAtZeroWithNoPlayers()
    {
        var audioManager = AutoFree(new AudioManager());

        audioManager.PlayClickSound();

        var idx = FetchIdx(audioManager);

        AssertThat(idx).IsEqual(0);
    }

    [TestCase]
    public void PlayClickSoundAdvancesIdx()
    {
        var audioManager = AutoFree(new AudioManager());

        var player1 = AutoFree(new AudioStreamPlayer2D());
        var player2 = AutoFree(new AudioStreamPlayer2D());
        var players = new AudioStreamPlayer2D[] { player1, player2 };

        typeof(AudioManager)
            .GetField("ClickSoundPlayers", BindingFlags.NonPublic | BindingFlags.Instance)
            .SetValue(audioManager, players);

        var audioManagerPlayers = FetchPlayers(audioManager);

        AssertThat(audioManagerPlayers.Length).IsEqual(2);
        AssertThat(audioManagerPlayers[0]).IsSame(player1);

        audioManager.PlayClickSound();

        var idx = FetchIdx(audioManager);

        AssertThat(idx).IsEqual(1);

        audioManager.PlayClickSound();

        idx = FetchIdx(audioManager);

        AssertThat(idx).IsEqual(0);

    }
}