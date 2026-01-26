using UnityEngine;

public class HiddenItem : MonoBehaviour
{
    public float popScale = 1.3f;
    public float animDuration = 0.3f;
    public CanvasGroup cg; // kalau ini 3D object, ganti cara fade

    private Vector3 originalScale;
    private bool clicked = false;

    private void Start()
    {
        originalScale = transform.localScale;

        // jika ini 3D object tanpa CanvasGroup, kita buat sendiri untuk fade pakai renderer
        if (cg == null)
        {
            cg = gameObject.AddComponent<CanvasGroup>();
            cg.alpha = 1f;
        }
        Debug.Log(cg);
    }

    private void OnMouseDown()
    {
        Debug.Log("jalan");
        if (clicked) return;
        clicked = true;

        // disable collider
        Collider col = GetComponent<Collider>();
        if (col) col.enabled = false;

        // beri tahu GameManager
        GameManagerFindItem.Instance.FoundOne();

        // jalankan animasi
        StartCoroutine(AnimateAndDestroy());
    }

    private System.Collections.IEnumerator AnimateAndDestroy()
    {
        float t = 0;
        Vector3 targetScale = originalScale * popScale;

        while (t < animDuration)
        {
            t += Time.deltaTime;
            float lerp = t / animDuration;

            transform.localScale = Vector3.Lerp(originalScale, targetScale, lerp);
            cg.alpha = Mathf.Lerp(1f, 0f, lerp);

            yield return null;
        }

        gameObject.SetActive(false);
    }
}
