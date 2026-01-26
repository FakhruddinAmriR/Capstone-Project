using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class SceneProgress
{
    public string sceneName;
    public bool isCompleted = false;  // Only this matters now!
}

[Serializable]
public class GameSaveData
{
    public List<SceneProgress> sceneProgresses = new List<SceneProgress>();
    public string lastScene;
    public int totalScenes = 19;  // Set your total number of scenes

    // Get progress for specific scene
    public SceneProgress GetSceneProgress(string sceneName)
    {
        var progress = sceneProgresses.Find(p => p.sceneName == sceneName);
        if (progress == null)
        {
            progress = new SceneProgress { sceneName = sceneName };
            sceneProgresses.Add(progress);
        }
        return progress;
    }

    // Calculate overall progress (0-100%)
    public float GetOverallProgress()
    {
        int completedCount = 0;
        foreach (var progress in sceneProgresses)
        {
            if (progress.isCompleted) completedCount++;
        }
        return (float)completedCount / totalScenes * 100f;
    }

    // Count completed scenes
    public int GetCompletedScenesCount() => sceneProgresses.Count(p => p.isCompleted);
}