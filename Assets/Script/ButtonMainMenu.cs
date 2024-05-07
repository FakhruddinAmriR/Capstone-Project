using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonMainMenu : MonoBehaviour
{
    public void Main(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void Keluar()
    {
        Application.Quit();
    }

    
}
