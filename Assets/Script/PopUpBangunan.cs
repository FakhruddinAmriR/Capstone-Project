using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpBangunan : MonoBehaviour
{
    bool interact;

    [SerializeField] GameObject dialog;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && interact)
        {
            //Debug.Log("Anda memasuki bangun xxblabla");
            dialog.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            interact = true;
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interact = false;
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
