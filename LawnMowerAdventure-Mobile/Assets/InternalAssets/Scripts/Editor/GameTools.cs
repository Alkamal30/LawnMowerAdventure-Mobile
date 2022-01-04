using System;
using System.IO;
using UnityEditor;
using UnityEngine;
//©
public sealed class GameTools : Editor
{
    [MenuItem("GameTools/Clear all PlayerPrefs database")]
    public static void ClearAllPlayerPrefs() => PlayerPrefs.DeleteAll();

    [MenuItem("GameTools/Take Screenshot Game Screen")]
    public static void TakeScreenshotGameScreen()
    {
        string path = "GameTools/Screenshot";
        string fileName = $"{DateTime.Now.Year}.{DateTime.Now.Month}.{DateTime.Now.Day} [{DateTime.Now.Hour}.{DateTime.Now.Minute}.{DateTime.Now.Second}-{DateTime.Now.Millisecond}].png";

        Directory.CreateDirectory(path);

        while (File.Exists($"{path}/{fileName}")) { }

        ScreenCapture.CaptureScreenshot($"{path}/{fileName}");
    }
}