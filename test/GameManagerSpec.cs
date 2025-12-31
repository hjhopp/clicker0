using Godot;
using GdUnit4;
using static GdUnit4.Assertions;
using System.Threading.Tasks;

[TestSuite]
[RequireGodotRuntime]
public class GameManagerSpec()
{
    GameManager _gameManager = null!;

    [BeforeTest]
    public void Setup()
    {
        _gameManager = new GameManager();
    }

    [AfterTest]
    public void Teardown()
    {
        if (_gameManager != null)
        {
            _gameManager.Free();
            _gameManager = null!;
        }
    }

    [TestCase]
    public void IsManagerNotNull()
    {
        AssertThat(_gameManager).IsNotNull();
    }

    [TestCase]
    public void ScoreStartsAtZero()
    {
        AssertThat(_gameManager.Score).IsEqual(0);
    }

    [TestCase]
    public void IncrementScoreWorks()
    {
        _gameManager.IncrementScore(5);

        AssertThat(_gameManager.Score).IsEqual(5);

        _gameManager.IncrementScore(3);

        AssertThat(_gameManager.Score).IsEqual(8);
    }

    [TestCase]
    public async Task ScoreChangedSignalEmitted()
    {
        var monitor = AssertSignal(_gameManager).StartMonitoring();

        _gameManager.IncrementScore(2);

        await monitor.IsEmitted(nameof(GameManager.ScoreChanged));
    }

    [TestCase]
    public async Task ScoreChangedSignalEmitsCorrectValue()
    {
        var monitor = AssertSignal(_gameManager).StartMonitoring();

        _gameManager.IncrementScore(4);

        await monitor
            .IsEmitted(nameof(GameManager.ScoreChanged), 4)
            .WithTimeout(TestGlobals.SHORT_TIMEOUT);
    }
}