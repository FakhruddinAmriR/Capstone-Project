using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Maps : MonoBehaviour
{
    public Transform[] targetPos;

    GameObject player;

    string place;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        if (place == null) place = "Auditorium"; 

        for (int i = 0; i < targetPos.Length; i++)
        {
            if (targetPos[i] != null)
            {
                if (place.ToLower() == targetPos[i].name.ToLower()) player.transform.position = targetPos[i].position;
            }
        }
    }

    public void changeButton()
    {
        for (int i = 0; i < targetPos.Length; i++)
        {
            if (EventSystem.current.currentSelectedGameObject.name.ToLower() == targetPos[i].name.ToLower())
            {
                player.transform.position = targetPos[i].position;
                place = targetPos[i].name.ToUpper();
            }
        }
    }

    public void ChangeTarget()
    {
        SceneManager.LoadScene(place);
    }
}
