using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance { get; private set; }

    private GameSaveData saveData;
    private string savePath;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        savePath = Path.Combine(Application.persistentDataPath, "savegame.dat");
        LoadGame();
    }

    public void SaveGame()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(savePath);
        bf.Serialize(file, saveData);
        file.Close();
        Debug.Log("Game saved: " + savePath);
    }

    public void LoadGame()
    {
        if (File.Exists(savePath))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(savePath, FileMode.Open);
            saveData = (GameSaveData)bf.Deserialize(file);
            file.Close();
            Debug.Log("Game loaded.");
        }
        else
        {
            saveData = new GameSaveData();
            Debug.Log("No save found. Starting new game.");
        }
    }

    // NEW: Delete ALL Progress (New Game)
    public void DeleteProgress()
    {
        if (File.Exists(savePath))
        {
            File.Delete(savePath);
            Debug.Log("Save file DELETED!");
        }

        // Reset data in memory
        saveData = new GameSaveData();

        // Force reload UI
        UpdateAllProgressUI();
    }

    // Notify all ProgressUI to refresh
    private void UpdateAllProgressUI()
    {
        ProgressUI[] uis = FindObjectsOfType<ProgressUI>();
        foreach (var ui in uis)
        {
            ui.ForceUpdate();
        }
    }

    public GameSaveData GetSaveData() => saveData;

    private void OnApplicationQuit()
    {
        SaveGame();
    }
}