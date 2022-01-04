using UnityEditor;
using UnityEngine;

public sealed class GameTools : Editor
{
    [MenuItem("GameTools/Clear all PlayerPrefs database")]
    public static void ClearAllPlayerPrefs() => PlayerPrefs.DeleteAll();
}