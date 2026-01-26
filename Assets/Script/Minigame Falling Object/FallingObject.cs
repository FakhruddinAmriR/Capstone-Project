using UnityEngine;


public enum ItemType { Good, Bomb }


[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class FallingObject : MonoBehaviour
{
    public ItemType itemType = ItemType.Good;
    public int scoreValue = 1; // positive for good, positive magnitude used when applying penalty for bomb capture


    [Header("Despawn settings")]
    public float despawnY = -6.0f; // if object falls below this Y and wasn't caught


    private bool caught = false;


    void Start()
    {
        // Make sure Rigidbody2D is dynamic so gravity affects it
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Dynamic;
        GetComponent<Collider2D>().isTrigger = false; // collider used for physics and triggers on player entry
    }


    void Update()
    {
        if (!caught && transform.position.y < despawnY)
        {
            HandleMiss();
        }
    }


    void HandleMiss()
    {
        // Rules: Good item missed => score -1 (or -scoreValue). Bomb missed => no effect
        if (itemType == ItemType.Good)
        {
            GameManagerFallingObject.Instance.AddScore(-scoreValue);
        }
        // Destroy in any case
        Destroy(gameObject);
    }


    // We will use the player's trigger collider to detect catch.
    // The player has a trigger collider; falling objects have non-trigger colliders.
    void OnTriggerEnter2D(Collider2D other)
    {
        // Not used; detection handled on player side via OnTriggerEnter2D there.
    }
}