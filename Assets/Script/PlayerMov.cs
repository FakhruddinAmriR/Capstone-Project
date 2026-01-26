using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerMov : MonoBehaviour


{
    // Start is called before the first frame update
    public string lokasi;
    Control control;
    Rigidbody2D rb;
    Animator animator;
    [SerializeField] float speed = 5f;
    Vector2 move = new Vector2();
    private void Awake()
    {
        control = new Control();
    }

    private void OnEnable()
    {
        control.Android.Enable();

        control.Android.Mundur.performed += ctx=>move.x=-1;
        control.Android.Mundur.canceled += ctx => move.x = 0;
        control.Android.Maju.performed += ctx => move.x = 1;
        control.Android.Maju.canceled += ctx => move.x = 0;
    }

    private void OnDisable()
    {
        control.Android.Disable();
    }

    //public void OnMoveLeft(InputAction.CallbackContext context)
    //{
    //    move.x = context.performed ? -1 : 0;
    //}

    //public void OnMoveRight(InputAction.CallbackContext context)
    //{
    //    move.x = context.performed ? 1 : 0;
    //}

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

        rb.velocity=move*speed;
     
    }

    private void FixedUpdate()
    {
        animator.SetFloat("speed" , Mathf.Abs( rb.velocity.x ));
    }

    public void movement(int arah)
    {
        rb.velocity = new Vector2(arah, rb.velocity.y) * speed;
    }

    public void TekanKiri()
    {
        move.x = -1;
        GetComponent<SpriteRenderer>().flipX = true;

        //control.Android.Mundur.Trigger(new InputAction.CallbackContext());

        //var context = new InputAction.CallbackContext();
        //control.Android.Mundur.PerformInteractiveRebinding().WithAction(control.Android.Mundur);
        //OnMoveLeft(context);
    }

    public void LepasKiri()
    {
        move.x = 0;
        //control.Android.Mundur.Cancel(new InputAction.CallbackContext());

        //var context = new InputAction.CallbackContext();
        //OnMoveLeft(context);
    }

    public void TekanKanan()
    {
        move.x = 1;
        GetComponent<SpriteRenderer>().flipX = false;
        //var context = new InputAction.CallbackContext();
        //control.Android.Maju.PerformInteractiveRebinding().WithAction(control.Android.Maju);
        //OnMoveRight(context);
    }

    public void LepasKanan()
    {  
        move.x = 0;
        //var context = new InputAction.CallbackContext();
        //OnMoveRight(context);
    }




}
