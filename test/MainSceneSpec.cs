using Godot;
using GdUnit4;
using static GdUnit4.Assertions;
using System.Threading.Tasks;

[TestSuite]
[RequireGodotRuntime]
public class MainSceneSpec()
{
    [TestCase]
    public void MainSceneLoads()
    {
        var runner = ISceneRunner.Load("res://main.tscn", true);

        AssertThat(runner).IsNotNull();
    }

    [TestCase]
    public void HasScoreButtonAndScore()
    {
        var runner = ISceneRunner.Load("res://main.tscn", true);

        var scoreButton = runner.FindChild("ScoreButton");
        var scoreLabel = runner.FindChild("ScoreLabel");
        var score = runner.FindChild("Score");

        AssertThat(scoreButton).IsNotNull();
        AssertThat(scoreLabel).IsNotNull();
        AssertThat(score).IsNotNull();
    }

    [TestCase]
    public void ScoreStartsAtZero()
    {
        var runner = ISceneRunner.Load("res://main.tscn", true);

        var score = runner.FindChild("Score") as Label;

        AssertThat(score.Text).IsEqual("0");
    }
}