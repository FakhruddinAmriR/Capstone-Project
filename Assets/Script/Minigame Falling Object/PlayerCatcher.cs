using UnityEngine;


[RequireComponent(typeof(Collider2D))]
public class PlayerCatcher : MonoBehaviour
{
    void Start()
    {
        Collider2D col = GetComponent<Collider2D>();
        col.isTrigger = true; // ensure it's trigger
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        FallingObject fo = other.GetComponent<FallingObject>();
        if (fo == null) return;


        // Object was caught by player
        if (fo.itemType == ItemType.Good)
        {
            GameManagerFallingObject.Instance.AddScore(fo.scoreValue);
        }
        else if (fo.itemType == ItemType.Bomb)
        {
            // Bomb when caught -> subtract scoreValue
            GameManagerFallingObject.Instance.AddScore(-fo.scoreValue);
        }


        Destroy(other.gameObject);
    }
}