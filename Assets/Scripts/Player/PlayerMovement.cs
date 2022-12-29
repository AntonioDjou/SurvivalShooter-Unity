using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 6f; // Moving speed
    
    public float gravity = -30f; // Gravity value for adjusting the fall propperly
    Vector3 velocity; // Stores the fall speed

    public Transform groundCheck; // Check if the player is grounded
    public float groundDistance = 0.3f; 
    public LayerMask groundMask;
    public bool isGrounded;

    public float jumpHeight = 2f;

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // Resets the player's vertical velocity 
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime); 

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y = gravity * Time.deltaTime;
        controller.Move(velocity*Time.deltaTime);
    }
}
