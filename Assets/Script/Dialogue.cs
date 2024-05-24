using System.Collections;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.Playables;

public class Dialogue : MonoBehaviour
{
    [SerializeField] private GameObject nextDialogue;
    GameObject player;
    [SerializeField] private GameObject panel;
    //[SerializeField] private PlayableDirector transition;

    
    public Text textComponent;
    public string[] lines;
    public float textSpeed;

    private int index;
    //AudioManager audioManager;

    private void Awake()
    {
        //audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();

        player = GameObject.FindGameObjectWithTag("Player");
        //audioManager.PlaySFX(audioManager.dialogText);
    }

    void Update()
    {
        if (textComponent.text == lines[index])
        {
            //audioManager.StopSFX();
        }

        if(Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
                if (nextDialogue != null && nextDialogue.CompareTag("Ending"))
                {
                    nextDialogue.SetActive(true);

                    if (gameObject.transform.parent.name == "Dialog Pintu")
                    {
                        //audioManager.PlaySFX(audioManager.door);
                    }

                    //if (transition != null)
                    //{
                    //    Time.timeScale = 0;
                    //    transition.Play();
                    //}
                }
                else if (nextDialogue != null)
                {
                    nextDialogue.SetActive(true);
                }
                else
                {
                    player.GetComponent<PlayerMov>().enabled = true;
                    panel.SetActive(false);
                }
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }
    
    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
             textComponent.text += c;
             yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
