
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonMainMenu : MonoBehaviour
{
    public void Main(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1.0f;
    }

    public void baliklokasi()
    {
        Main("LAPANGAN");
    }

    public void Keluar()
    {
        Debug.Log("Keluar Aplikasi");
        Application.Quit();
    }

    public void ResetProgress()
    {
        PlayerPrefs.DeleteKey("VisitedMaps");
        Debug.Log("reset berhasil");

    }


}







