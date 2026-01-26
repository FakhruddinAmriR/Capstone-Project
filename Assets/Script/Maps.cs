using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Maps : MonoBehaviour
{
    public Transform[] targetPos;

    public SceneCompletionTrigger trigger;

    GameObject player;

    string place;

    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("PlayerMap");

        if (PlayerPrefs.HasKey("namalokasi"))
        {
            PlayerPrefs.SetString("namalokasi", "Auditorium");    
        }

        place = PlayerPrefs.GetString("namalokasi");

        for (int i = 0; i < targetPos.Length; i++)
        {
            if (targetPos[i] != null)
            {
                if (targetPos[i].name.ToLower() == place)
                {
                    PlayerPrefs.SetFloat("x", targetPos[i].position.x);
                    PlayerPrefs.SetFloat("y", targetPos[i].position.y);
                    
                }
            }
        }
        player.transform.position = new Vector2(PlayerPrefs.GetFloat("x"), PlayerPrefs.GetFloat("y"));
    }

    public void changeButton(bool isPoint)
    {
        trigger.changeactive(isPoint);
        for (int i = 0; i < targetPos.Length; i++)
        {
            if (EventSystem.current.currentSelectedGameObject.name.ToLower() == targetPos[i].name.ToLower())
            {
                //player.transform.position = targetPos[i].position;
                place = targetPos[i].name.ToUpper();
                
                trigger.nextSceneName = place;
                trigger.currentScene = place;
                PlayerPrefs.SetString("namalokasi", place);
                PlayerPrefs.SetFloat("x", targetPos[i].position.x);
                PlayerPrefs.SetFloat("y", targetPos[i].position.y);

            }
        }
    }

    public void ChangeTarget()
    {
        SceneManager.LoadScene(place);
    }
}
