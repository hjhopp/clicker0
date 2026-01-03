using Godot;
using GdUnit4;
using System;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

#pragma warning disable CA2200 // Re-throwing caught exception changes stack information

[RequireGodotRuntime]
public class SceneTestBase()
{
    protected static async Task SceneTest(Func<Task> test, [CallerMemberName] string testName = "")
    {
        try
        {
            await test();
        }
        catch (Exception e)
        {
            await TakeScreenshot(testName);

            throw e;
        }
    }

    private static async Task TakeScreenshot(string testName = "")
    {
        var sceneTree = Engine.GetMainLoop() as SceneTree;

        if (sceneTree == null || !(bool)ProjectSettings.GetSetting("gdunit4/settings/take_screenshots"))
        {
            return;
        }

        await sceneTree.ToSignal(sceneTree, SceneTree.SignalName.ProcessFrame);

        var screenshot = sceneTree.Root.GetViewport().GetTexture().GetImage();

        var now = DateTime.Now.ToString("yyMMdd_HHmmss");
        var filename = $"{testName}_{now}.png";

        try
        {
            screenshot.SavePng($"res://screenshots/{filename}");
        }
        catch
        {
            GD.Print("Unable to save screenshot");
        }
    }
}