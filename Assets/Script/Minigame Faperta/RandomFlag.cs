using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomFlag : MonoBehaviour
{
    public List<Sprite> flag;
    public GameObject draggable;
    public GameObject dropable;

    // Start is called before the first frame update
    void Start()
    {
        List<string> name_flag = new List<string>();
        foreach (Transform child in draggable.transform)
        {
            int index = Random.Range(0, flag.Count);
            child.GetComponent<Image>().sprite = flag[index];
            name_flag.Add(flag[index].name);
            Debug.Log(child.name + " " + flag[index].name);
            flag.RemoveAt(index);
        }

        foreach (Transform child in dropable.transform)
        {
            int index = Random.Range(0, name_flag.Count);
            child.GetComponent<DropTarget>().correctImageName = name_flag[index];
            child.GetComponent<Text>().text = name_flag[index].ToUpper();
            //Debug.Log (child.name + " " +  name_flag[index]);
            name_flag.RemoveAt(index);
        }
    }
}