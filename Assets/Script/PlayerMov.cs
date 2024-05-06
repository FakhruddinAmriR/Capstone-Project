using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMov : MonoBehaviour
{
    // Start is called before the first frame update

    Rigidbody2D rb;
    [SerializeField] float speed = 5f;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2 (Input.GetAxisRaw("Horizontal"), rb.velocity.y ) * speed;
    }
}
