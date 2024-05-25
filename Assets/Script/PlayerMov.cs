using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerMov : MonoBehaviour
{
    // Start is called before the first frame update

    Rigidbody2D rb;
    Animator animator;
    [SerializeField] float speed = 5f;
    
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2 (Input.GetAxisRaw("Horizontal"), rb.velocity.y ) * speed;
        if (rb.velocity.x != 0)
        {
            if (rb.velocity.x < 0) GetComponent<SpriteRenderer>().flipX = true;

            else if (rb.velocity.x > 0) GetComponent<SpriteRenderer>().flipX = false;
        } 

    }

    private void FixedUpdate()
    {
        animator.SetFloat("speed" , Mathf.Abs( rb.velocity.x ));
    }
}
