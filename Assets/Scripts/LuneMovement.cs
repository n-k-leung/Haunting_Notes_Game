using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuneMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public float runSpeed;
    float horizontalMove = 0f;
    bool jump = false;

    //holding on jump button changes height of jump
    public float jumpVelocity;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        if(Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
        Input.GetAxisRaw("Jump");
        Input.GetAxisRaw("Horizontal");

    }


    void FixedUpdate()
    {
        /*
        if (jump)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpVelocity, ForceMode2D.Impulse);
        }
        if (rb.velocity.y < 0)
        {
            rb.gravityScale = fallMultiplier;
        }
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.gravityScale = lowJumpMultiplier;
        }
        else
        {
            rb.gravityScale = 1f;
        }
        */
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}
