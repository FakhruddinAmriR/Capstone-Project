using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropTarget : MonoBehaviour, IDropHandler
{
    [Tooltip("Nama gambar yang benar, misal: AppleImage")]
    public string correctImageName;

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log(eventData.pointerDrag.GetComponent<Image>().sprite.name.ToLower() +"=="+ correctImageName.ToLower());
        Draggable drag = eventData.pointerDrag.GetComponent<Draggable>();
        if (drag == null) return;

        if (eventData.pointerDrag.GetComponent<Image>().sprite.name.ToLower() == correctImageName.ToLower())
        {
            drag.transform.SetParent(transform);
            drag.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;

            MatchManager.Instance.AddMatch();
        }

    
        else
            {
                // salah -> shake lalu kembalikan
                StartCoroutine(drag.Shake());
                drag.transform.SetParent(drag.originalParent);
            }


        
    }
}
