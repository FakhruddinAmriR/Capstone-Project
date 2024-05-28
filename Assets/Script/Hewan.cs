using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Hewan : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject panel;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition),Vector2.zero);
            if (hit.collider != null & hit.collider.gameObject == gameObject)
            {
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePosition.z = 0f;
                Debug.Log("Tersentuh");

                panel.SetActive(true);
                panel.GetComponent<PlayableDirector>().Play();
            }
        }  
    }
}
