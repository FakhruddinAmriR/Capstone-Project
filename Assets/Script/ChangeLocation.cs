using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLocation : MonoBehaviour
{
    [SerializeField] GameObject Popup;
    [SerializeField] GameObject Player;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            Popup.SetActive(true);
            Player.GetComponent<PlayerMov>().enabled = false;
        }
    }

    public void ChangeScene(string sceneName)
    {
        SceneData.SceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName);
    }
}
