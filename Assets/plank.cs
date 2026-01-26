using UnityEngine;

public class plank : MonoBehaviour
{
    private Camera cam;
    [SerializeField] private PopUpBangunan PopUp;


    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        // Untuk Android (touch)
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Vector2 touchPos = cam.ScreenToWorldPoint(Input.touches[0].position);
            RaycastHit2D hit = Physics2D.Raycast(touchPos, Vector2.zero);

            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                OnSpriteTapped();
            }
        }

        // Untuk editor PC (klik kiri mouse)
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 clickPos = cam.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(clickPos, Vector2.zero);

            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                OnSpriteTapped();
            }
        }
    }

    void OnSpriteTapped()
    {
        PopUp.showdialog();
    }
}