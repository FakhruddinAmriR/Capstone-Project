using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    [Header("In-Game UI")]
    public Text scoreText;
    public Text timerText;


    [Header("End Panel")]
    public GameObject endPanel;
    public Text endScoreText;
    public Text highscoreText;


    [Header("Highscore Key")]
    public string highscoreKey = "Highscore";


    void Start()
    {
        if (endPanel != null) endPanel.SetActive(false);
    }


    public void UpdateScore(int score)
    {
        if (scoreText != null) scoreText.text = "Score: " + score.ToString();
    }


    public void UpdateTimer(float timeLeft)
    {
        if (timerText != null)
        {
            int seconds = Mathf.CeilToInt(timeLeft);
            timerText.text = "Time: " + seconds.ToString() + "s";
        }
    }


    public void ShowEndPanel(int finalScore)
    {
        if (endPanel != null) endPanel.SetActive(true);
        if (endScoreText != null) endScoreText.text = "Score: " + finalScore.ToString();


        int hs = PlayerPrefs.GetInt(highscoreKey, int.MinValue);
        if (hs == int.MinValue) hs = finalScore; // first time
        if (finalScore > hs) hs = finalScore;
        PlayerPrefs.SetInt(highscoreKey, hs);
        PlayerPrefs.Save();


        if (highscoreText != null) highscoreText.text = "Highscore: " + hs.ToString();
    }


    // Hook these to buttons on end panel
    public void OnRestartButton()
    {
        GameManagerFallingObject.Instance.RestartGame();
    }


    public void OnMainMenuButton()
    {
        GameManagerFallingObject.Instance.GoToMainMenu();
    }
}