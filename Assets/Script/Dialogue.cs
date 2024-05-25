using System.Collections;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.Playables;

public class Dialogue : MonoBehaviour
{
    public Dialogues[] dialogues;

    [SerializeField] GameObject dPanel;
    [SerializeField] GameObject nextPhase;

    [SerializeField] float textSpeed;

    [SerializeField] GameObject[] ilustrations;
    [SerializeField] GameObject[] names;

    [SerializeField] GameObject button;

    public int index;

    [SerializeField] Text textComponent;
    GameObject player;

    void Start()
    {
        for (int i = 0; i < dialogues.Length; i++)
        {
            Debug.Log(dialogues[i].name);
        }

        textComponent.text = string.Empty;

        if (dialogues.Length > 0)
        {
            StartDialogue();
        }

        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (textComponent.text == string.Empty) StartCoroutine(TypeLine());

        if (dialogues[index].pilihan && textComponent.text == dialogues[index].content) button.SetActive(true);

        if (Input.GetMouseButtonDown(0))
        {

            if (textComponent.text == dialogues[index].content && !dialogues[index].pilihan)
            {
                NextLine();
            }

            else
            {
                StopAllCoroutines();
                textComponent.text = dialogues[index].content;

                if (dialogues[index].pilihan) button.SetActive(true);
            }
        }
    }

    void StartDialogue()
    {
        index = 0;

        if (dialogues[index].dIndex == 0 && names[0].activeSelf == false)
        {
            names[0].SetActive(true);
            names[1].SetActive(false);
        
            ilustrations[0].SetActive(true);
            ilustrations[1].SetActive(false);
        }

        else if (dialogues[index].dIndex == 1 && names[1].activeSelf == false)
        {
            names[0].SetActive(false);
            names[1].SetActive(true);
        
            ilustrations[0].SetActive(false);
            ilustrations[1].SetActive(true);
        }

        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        for (int i = 0; i < names.Length; i++)
        {
            if (names[i].activeSelf)
            {
                names[i].GetComponent<Text>().text = dialogues[index].name;
                ilustrations[i].GetComponent<Image>().sprite = dialogues[index].ilustration;
            } 
        }

        foreach (char c in dialogues[index].content.ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < dialogues.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            if (nextPhase != null) nextPhase.SetActive(true);

            dPanel.SetActive(false);
            index = 0;
            textComponent.text = string.Empty;
        }
    }

    public void changeIndex(int newIndex)
    {
        index = newIndex - 1;

        NextLine();
    }
}

//public class Dialogue : MonoBehaviour
//{
//    [SerializeField] private GameObject nextDialogue;
//    GameObject player;
//    [SerializeField] private GameObject panel;
//    //[SerializeField] private PlayableDirector transition;

    
//    public Text textComponent;
//    public string[] lines;
//    public float textSpeed;

//    private int index;
//    //AudioManager audioManager;

//    private void Awake()
//    {
//        //audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
//    }

//    // Start is called before the first frame update
//    void Start()
//    {
//        textComponent.text = string.Empty;
//        StartDialogue();

//        player = GameObject.FindGameObjectWithTag("Player");
//        //audioManager.PlaySFX(audioManager.dialogText);
//    }

//    void Update()
//    {
//        if (textComponent.text == lines[index])
//        {
//            //audioManager.StopSFX();
//        }

//        if(Input.GetMouseButtonDown(0))
//        {
//            if (textComponent.text == lines[index])
//            {
//                NextLine();
//                if (nextDialogue != null && nextDialogue.CompareTag("Ending"))
//                {
//                    nextDialogue.SetActive(true);

//                    if (gameObject.transform.parent.name == "Dialog Pintu")
//                    {
//                        //audioManager.PlaySFX(audioManager.door);
//                    }

//                    //if (transition != null)
//                    //{
//                    //    Time.timeScale = 0;
//                    //    transition.Play();
//                    //}
//                }
//                else if (nextDialogue != null)
//                {
//                    nextDialogue.SetActive(true);
//                }
//                else
//                {
//                    player.GetComponent<PlayerMov>().enabled = true;
//                    panel.SetActive(false);
//                }
//            }
//            else
//            {
//                StopAllCoroutines();
//                textComponent.text = lines[index];
//            }
//        }
//    }

//    void StartDialogue()
//    {
//        index = 0;
//        StartCoroutine(TypeLine());
//    }
    
//    IEnumerator TypeLine()
//    {
//        foreach (char c in lines[index].ToCharArray())
//        {
//             textComponent.text += c;
//             yield return new WaitForSeconds(textSpeed);
//        }
//    }

//    void NextLine()
//    {
//        if (index < lines.Length - 1)
//        {
//            index++;
//            textComponent.text = string.Empty;
//            StartCoroutine(TypeLine());
//        }
//        else
//        {
//            gameObject.SetActive(false);
//        }
//    }
//}
