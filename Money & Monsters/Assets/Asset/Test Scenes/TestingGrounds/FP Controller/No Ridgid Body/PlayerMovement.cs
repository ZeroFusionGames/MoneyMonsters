﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;


    public float speed = 12f;
    public float gravity = -9.8f;
	public float terminalVolocity = -100f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public float jumpHight = 3f;
	private bool doubleJumped;
	public bool inPositiveGravFeild;

	public Vector3 velocity;
    bool isGrounded;

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded == true && velocity.y < 0)
        {
            velocity.y = -2f;
			doubleJumped = false;

		}

		//terminal velocity
		if (velocity.y < terminalVolocity)
		{
			velocity.y = terminalVolocity;
		}

		float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);


		if (InputManager.instance.KeyDown("Jump") && isGrounded == true)
        {
			velocity.y = Mathf.Sqrt(jumpHight * -2f * gravity);
			controller.slopeLimit = 90f;
        }
		
		//double jump
		if (InputManager.instance.KeyDown("Jump") && isGrounded == false && doubleJumped == false && inPositiveGravFeild == false)
		{
			velocity.y = Mathf.Sqrt(jumpHight * -2f * gravity);
			controller.slopeLimit = 90f;
			doubleJumped = true;
		}

		//stop umping gitter

		velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}