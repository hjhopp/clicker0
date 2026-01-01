using Godot;
using GdUnit4;
using static GdUnit4.Assertions;
using System.Threading.Tasks;

#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8604 // Possible null reference argument.

[TestSuite]
[RequireGodotRuntime]
public class GameManagerSpec()
{
    [TestCase]
    public void IsManagerNotNull()
    {
        var gameManager = AutoFree(new GameManager());

        AssertThat(gameManager).IsNotNull();
    }

    [TestCase]
    public void ScoreStartsAtZero()
    {
        var gameManager = AutoFree(new GameManager());

        AssertThat(gameManager.Score).IsEqual(0);
    }

    [TestCase]
    public void IncrementScoreWorks()
    {
        var gameManager = AutoFree(new GameManager());

        gameManager.IncrementScore(5);

        AssertThat(gameManager.Score).IsEqual(5);

        gameManager.IncrementScore(3);

        AssertThat(gameManager.Score).IsEqual(8);
    }

    [TestCase]
    public async Task ScoreChangedSignalEmitted()
    {
        var gameManager = AutoFree(new GameManager());
        var monitor = AssertSignal(gameManager).StartMonitoring();

        gameManager.IncrementScore(2);

        await monitor.IsEmitted(nameof(GameManager.ScoreChanged));
    }

    [TestCase]
    public async Task ScoreChangedSignalEmitsCorrectValue()
    {
        var gameManager = AutoFree(new GameManager());
        var monitor = AssertSignal(gameManager).StartMonitoring();

        gameManager.IncrementScore(4);

        await monitor
            .IsEmitted(nameof(GameManager.ScoreChanged), 4)
            .WithTimeout(TestGlobals.SHORT_TIMEOUT);
    }
}