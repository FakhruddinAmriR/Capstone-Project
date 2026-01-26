using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManagerFallingObject : MonoBehaviour
{
    public static GameManagerFallingObject Instance { get; private set; }


    [Header("Game rules")]
    public int startingScore = 0;
    public float gameDuration = 30f;


    //[HideInInspector]
public bool IsSpawning = false;


private int score = 0;
private float timeLeft;


[Header("References")]
public Spawner spawner;
public UIManager uiManager;


void Awake()
{
    if (Instance != null && Instance != this) Destroy(gameObject);
    else Instance = this;
}


void Start()
{
    score = startingScore;
    timeLeft = gameDuration;
    uiManager.UpdateScore(score);
    uiManager.UpdateTimer(timeLeft);
    StartGame();
}


public void StartGame()
{
    score = startingScore;
    timeLeft = gameDuration;
    IsSpawning = true;
    if (spawner != null) spawner.StartSpawning();
    StartCoroutine(GameTimer());
}


IEnumerator GameTimer()
{
    while (timeLeft > 0f)
    {
        yield return new WaitForSeconds(1f);
        timeLeft -= 1f;
        uiManager.UpdateTimer(timeLeft);
    }


    // Time up
    IsSpawning = false;
    if (spawner != null) spawner.StopSpawning();
    yield return new WaitForSeconds(0.25f); // small delay to let last collisions resolve
    uiManager.ShowEndPanel(score);
}


public void AddScore(int delta)
{
    score += delta;
    uiManager.UpdateScore(score);
}


public int GetScore() => score;


public void RestartGame()
{
    // reload current scene
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
}


public void GoToMainMenu(string sceneName = "FASILKOM")
{
    // Load main menu if exists
    SceneManager.LoadScene(sceneName);
}
}