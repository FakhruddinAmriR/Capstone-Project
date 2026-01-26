using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    public float timeLeft = 30f;
    public Text timerText;

    private bool running = true;

    private void Update()
    {
        if (!running) return;

        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            timeLeft = 0;
            running = false;
            GameManagerFindItem.Instance.Lose();
        }

        UpdateUI();
    }

    void UpdateUI()
    {
        if (timerText != null)
            timerText.text = Mathf.CeilToInt(timeLeft).ToString();
    }

    public void StopTimer()
    {
        running = false;
    }
}
