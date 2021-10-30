using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Animator animator;
    Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        //Input
        movement.x = Input.GetAxisRaw("Horizontal"); //Gives value between -1 and 1
        //Left = -1, Right = 1, Nothing = 0
        //Arrow keys, WASD, Controller

        movement.y = Input.GetAxisRaw("Vertical");

    }

    void Movement(Vector2 move)
    {
        // Collision detection
        if (move.magnitude < 0.00001f) return;
        RaycastHit2D[] results = new RaycastHit2D[16];
        int count = GetComponent<Rigidbody2D>().Cast(move, results, move.magnitude + 0.001f);
        if (count > 0)
        {
            print("collide!");
            return;
        }

        // Movement
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        
        // WIP: Have object face direction of movement (rotate rectangle based on movement)
        // Change z-axis of rotation based on movement

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Use Quaternions to do absolute rotations
        if (moveHorizontal > 0) {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (moveHorizontal < 0) {
            transform.rotation = Quaternion.Euler(0, 0, 180);
        }   
        if (moveVertical > 0) {
            transform.rotation = Quaternion.Euler(0, 0, 90);
        }
        if (moveVertical < 0) {
            transform.rotation = Quaternion.Euler(0, 0, -90);
        }   

        // Animation
        //animator.SetFloat("Horizontal", movement.x);
        //animator.SetFloat("Vertical", movement.y);

        //animator.SetFloat("Speed", movement.sqrMagnitude); // sqr magnitude is more optimized than regular magnitude

    }

    void FixedUpdate()
    {
        //Movement
        //move rigid body to new position while colliding with anything in the way
        //scales with moveSpeed as well
        //fixed delta time makes sure moveSpeed is consistent
        Movement(movement);
    }
}
