using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField]
    private float movSpeed;

    [SerializeField]
    private float floorDrag;

    [SerializeField]
    private float jumpForce;

    [SerializeField]
    private float jumpCooldown;

    [SerializeField]
    private float airMultiplier;

   

    private bool readyToJump;

    private Vector2 movement2d;
    private Vector3 movement3d;

    private float inputX;
    private float inputY;
    

    [Header("Ground Check")]
    [SerializeField]
    private float playerHeight;

    [SerializeField]
    private LayerMask whatIsGnd;

    private bool grounded;

    [SerializeField]
    private Transform orientation;

    public Rigidbody rb;

    [SerializeField]
    private InputManager input;

    public delegate void move();
    public static move moveStart;


    void Awake()
    {
        rb.freezeRotation = true;
        jumpReset();
        moveStart = startMove;
    }



    // Update is called once per frame
    /*void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * .5f + 02f, whatIsGnd);
        //myInput();
        if (grounded)
        {
            rb.drag = floorDrag;
        }
        else
        {
            rb.drag = 0;
        }

        if(input.getJump() && grounded && readyToJump)
        {
            readyToJump = false;
            jump();
            Invoke(nameof(jumpReset), jumpCooldown);
        }
    }
    private void FixedUpdate()
    {
        movePlayer();
    }*/

    
    private void startMove()
    {
        StartCoroutine(playerMove());
        StartCoroutine(playerJump());
    }
    IEnumerator playerMove()
    {
        while(gameStateManager.currState()) { 
       
        movePlayer();
            
        yield return new WaitForFixedUpdate();
        }
    }

    IEnumerator playerJump()
    {
        while (gameStateManager.currState())
        {
            grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * .5f + 02f, whatIsGnd);
            
            speedControl();
            if (grounded)
            {
                rb.drag = floorDrag;
            }
            else
            {
                rb.drag = 0;
            }

            if (input.getJump() && grounded && readyToJump)
            {
                readyToJump = false;
                jump();
                Invoke(nameof(jumpReset), jumpCooldown);
            }
            yield return new WaitForEndOfFrame();
        }
        }

   

    
    private void movePlayer()
    {

        movement2d = input.getPlayerMovement();
        movement3d = (orientation.right * movement2d.x + orientation.forward * movement2d.y);
        //movement = orientation.forward * inputY + orientation.right * inputX;

        

        if (grounded)
        {
            rb.AddForce(movement3d.normalized * movSpeed * 10f, ForceMode.Force);
        }
        else
        {
            rb.AddForce(movement3d.normalized * movSpeed * 10f * airMultiplier, ForceMode.Force);
        }
    }

    private void speedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if(flatVel.magnitude > movSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * movSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    private void jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);

    }

    private void jumpReset()
    {
        readyToJump = true;
    }
}
