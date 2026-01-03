using Godot;
using GdUnit4;
using static GdUnit4.Assertions;
using System.Threading.Tasks;
using System;

[TestSuite]
[RequireGodotRuntime]
public class MainSceneSpec() : SceneTestBase
{
    [TestCase]
    public async Task MainSceneLoads()
    {
        await SceneTest(async Task () =>
        {
            var runner = ISceneRunner.Load("res://scenes/main.tscn", true);

            AssertThat(runner).IsNotNull();
        });
    }

    [TestCase]
    public async Task HasScoreButtonAndScore()
    {
        await SceneTest(async Task () =>
        {
            var runner = ISceneRunner.Load("res://scenes/main.tscn", true);

            var scoreButton = runner.FindChild("ScoreButton");
            var scoreLabel = runner.FindChild("ScoreLabel");
            var score = runner.FindChild("Score");

            AssertThat(scoreButton).IsNotNull();
            AssertThat(scoreLabel).IsNotNull();
            AssertThat(score).IsNotNull();
        });
    }

    [TestCase]
    public async Task ScoreStartsAtZero()
    {
        await SceneTest(async Task () =>
        {
            var runner = ISceneRunner.Load("res://scenes/main.tscn", true);

            var score = runner.FindChild("Score") as Label;

            AssertThat(score.Text).IsEqual("0");
        });
    }

    [TestCase]
    public async Task ClickingButtonIncrementsScore()
    {
        await SceneTest(async Task () =>
        {
            var runner = ISceneRunner.Load("res://scenes/main.tscn", true);

            var scene = runner.Scene().IsNodeReady();

            var button = runner.FindChild("ScoreButton") as Button;
            var score = runner.FindChild("Score") as Label;

            var insideButtonPos = button.Position + (button.Size / 2);

            runner.SetMousePos(insideButtonPos);
            runner.SimulateMouseButtonPress(MouseButton.Left);

            await runner.SimulateFrames(60);

            AssertThat(score.Text).IsEqual("1");
        });
    }
}