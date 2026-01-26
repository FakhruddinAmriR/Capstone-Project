using UnityEngine;
using UnityEngine.UI;

public class GameManagerFindItem : MonoBehaviour
{
    public static GameManagerFindItem Instance;

    public int targetCount = 5;  // fixed 5
    private int foundCount = 0;

    public GameObject panelWin;
    public GameObject panelLose;
    public Text foundText; // tampilkan: "Found: x/5"
    public TimerController timer;

    private bool gameOver = false;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        panelWin.SetActive(false);
        panelLose.SetActive(false);
        UpdateFoundUI();
    }

    public void FoundOne()
    {
        if (gameOver) return;

        foundCount++;
        UpdateFoundUI();

        if (foundCount >= targetCount)
            Win();
    }

    void UpdateFoundUI()
    {
        if (foundText != null)
            foundText.text = "Found: " + foundCount + "/" + targetCount;
    }

    void Win()
    {
        gameOver = true;
        timer.StopTimer();
        panelWin.SetActive(true);
    }

    public void Lose()
    {
        if (gameOver) return;

        gameOver = true;
        panelLose.SetActive(true);
    }
}
