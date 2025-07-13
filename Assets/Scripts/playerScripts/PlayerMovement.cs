using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;
//using UnityEngine.Windows;

public class PlayerMovement : MonoBehaviour
{
    [Header("movement")]
    public float moveSpeed;

    public float groundDrag;

    public float jumpForce, jumpCooldown, airMultiplier;
    bool ready;

    [Header("key Binder")]
    public KeyCode jumpKey = KeyCode.Space;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool onGround;

    public Transform orientation;

    float Horizontal, Verticle;

    Vector3 moveDir;

    Rigidbody rb;

    // Start is called before the first frame update
    private void Start()
    {
        ready = true;
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    private void Update()
    {
        //ground check
        onGround = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

        playerInput();
        speedControl();
        //drag calculator
        if (onGround) rb.drag = groundDrag;
        else rb.drag = 0;
        

    }

    private void FixedUpdate()
    {
        movePLayer();
    }

    private void playerInput()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");
        Verticle = Input.GetAxisRaw("Vertical");
        if (Input.GetKey(jumpKey) && ready && onGround)
        {
            Console.WriteLine("jumped");
            ready = false;

            Jump();
            Invoke(nameof(resetJump), jumpCooldown);
        }
    }

    private void movePLayer()
    {
        //movement direction
        moveDir = orientation.forward * Verticle + orientation.right * Horizontal;
        if (onGround)
        {
            rb.AddForce(moveDir.normalized * moveSpeed, ForceMode.Force);
        }
        else if (!onGround)
        {
            rb.AddForce(moveDir.normalized * moveSpeed * airMultiplier, ForceMode.Force);
        }
    }

    private void speedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x,0f, rb.velocity.z);
        //limiting velocity
        if(flatVel.magnitude > moveSpeed)
        {
            Vector3 limitVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitVel.x, rb.velocity.y, limitVel.z);
        }
    }

    private void Jump()
    {
        //reset y velocity
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }
    private void resetJump()
    {
        ready = true;
    }

}
