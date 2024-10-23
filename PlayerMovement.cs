using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    // Variables
    float horizontalInput;
    
    public float moveSpeed = 5f;
    public float walkSpeed = 5f;
    public float sprintSpeed = 7f;

    public float jumpPower = 4f;
    public bool isJumping = false;

    // References
    public DebugManager debugManager;
    public GameObject spawnpoint;
    private Rigidbody2D rb;

    // Runs code at Start
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Runs code every Frame
    void Update()
    {
        // X Axis | Left & Right Movement
        horizontalInput = Input.GetAxis("Horizontal");

        // Sprinting
        if (Input.GetKeyDown(KeyCode.LeftShift)) 
        {
            moveSpeed = sprintSpeed;
        } else if (Input.GetKeyUp(KeyCode.LeftShift)) {
            moveSpeed = walkSpeed;
        }

        // Y Axis | Jump
        if (Input.GetButtonDown("Jump") && !isJumping ) 
        {
            // Applies Velocity to the RigidBody? Idfk
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);

            // Checks if Inf. Jump has been enabled.
            if (debugManager.infJump == true) {
                isJumping = false;
            } else {
                isJumping = true;
            }
        }
        
    }

    // Idk some random thing i found on the web
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
    }

    // Detects when a collision enters another collision
    private void OnCollisionEnter2D(Collision2D collision) 
    {
        isJumping = false;

        // SpawnBack ( aka Spawnpoints )
        if (collision.gameObject.tag == "SpawnBack") 
        {
            transform.position = spawnpoint.transform.position;
        }
    }

}
