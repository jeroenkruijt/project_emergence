using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    //sets the charater controller in unity variable 
    public CharacterController controller;
    
    //set the default values for the variable(speed, gravity and jumpheight)
    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    //values for the groundchecks to reset the gravity 
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    //puts the velocity to values 
    Vector3 velocity;
    
    // variable for the ground check 1 or 0 
    bool isGrounded;

    // Update is called once per frame
    void Update()
    {
        //makes move and fall 
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        //checks if charater is grounded of the value in the isgrounded 
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        
        //getting input of the wasd keys (default unity inputs horizontal, vertical)
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        
        //makes the move value
        Vector3 move = transform.right * x + transform.forward * z;
        
        //applies move value to make charater move
        controller.Move(move * speed * Time.deltaTime);

        //if spacebar is button goes down and isgrounded is true = jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        
        //makes the gravity build up
        velocity.y += gravity * Time.deltaTime;

        //apply velocity to move down
        controller.Move(velocity * Time.deltaTime);
        
    }

}



