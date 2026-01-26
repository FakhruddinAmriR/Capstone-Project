using UnityEngine;

public class MatchManager : MonoBehaviour
{
    public static MatchManager Instance;

    public int totalPairs = 4;
    private int matchedCount = 0;

    public GameObject panelWin;
    public GameObject panelTimeUp;
    public GameTimer timer; // drag GameTimer dari Inspector

    void Awake()
    {
        Instance = this;
    }

    public void AddMatch()
    {
        matchedCount++;
        if (matchedCount >= totalPairs)
        {
            WinGame();
            
        }
        Debug.Log($"{matchedCount}");
    }

    public void WinGame()
    {
        timer.enabled = false;        // stop timer
        panelWin.SetActive(true);     // tampilkan panel
        DisableAllDrag();
    }

    public void TimeUp()
    {
        panelTimeUp.SetActive(true);
        DisableAllDrag();
    }

    void DisableAllDrag()
    {
        var drags = FindObjectsOfType<Draggable>();
        foreach (var d in drags)
            d.enabled = false;
    }
}
