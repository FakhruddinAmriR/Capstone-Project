using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLocation : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject Popup;
    [SerializeField] GameObject Player;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
        SceneManager.LoadScene(sceneName);
    }
}
