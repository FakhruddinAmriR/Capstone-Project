using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    public float timeLeft = 30f; // detik
    public Text timerText;

    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0 && enabled)
        {
            timeLeft = 0;
            enabled = false; // stop update timer
            MatchManager.Instance.TimeUp();
        }

        timerText.text = Mathf.Ceil(timeLeft).ToString();

    }
}
