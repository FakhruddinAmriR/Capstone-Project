using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEditor.PlayerSettings;


[RequireComponent(typeof(Collider2D), typeof(Rigidbody2D))]
public class PlayerDragController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    [Header("Horizontal movement limits (world units)")]
    public float minX = -7.5f;
    public float maxX = 7.5f;


    private bool dragging = false;
    private Vector3 pointerOffset;
    private Camera mainCam;
    private float fixedY;
    private Rigidbody2D rb;
    private Animator animator;

    void Awake()
    {
        mainCam = Camera.main;
        rb = GetComponent<Rigidbody2D>();
        // Player should be kinematic so physics objects trigger collisions properly
        rb.isKinematic = true;
        fixedY = transform.position.y;
        animator = GetComponent<Animator>(); 
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("geser");
        dragging = true;
        Vector3 worldPoint = mainCam.ScreenToWorldPoint(eventData.position);
        pointerOffset = transform.position - new Vector3(worldPoint.x, transform.position.y, transform.position.z);
    }


    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("bergerak");
        if (!dragging) return;
        //Vector3 worldPoint = mainCam.ScreenToWorldPoint(eventData.position);
        //float targetX = worldPoint.x + pointerOffset.x;
        //targetX = Mathf.Clamp(targetX, minX, maxX);
        //Vector3 newPos = new Vector3(targetX, fixedY, transform.position.z);
        //transform.position = newPos;

        float temp = transform.position.x;
        Vector3 pos = Camera.main.ScreenToWorldPoint(eventData.position);
        pos.z = 0; // jaga z tetap sama
        transform.position = new Vector3(pos.x, transform.position.y);

        Debug.Log((temp - pos.x) * 120);
        animator.SetFloat("speed", Mathf.Abs((temp - pos.x) * 120f));
        if (temp-pos.x>0) GetComponent<SpriteRenderer>().flipX = true;
        else GetComponent<SpriteRenderer>().flipX = false;
    }


    public void OnPointerUp(PointerEventData eventData)
    {
        dragging = false;
        animator.SetFloat("speed", Mathf.Abs(0f));
    }
}