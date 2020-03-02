using System.Collections;
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
	private bool crouched;

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
			controller.slopeLimit = 90f; //stop jumping gitter
		}
		
		//double jump
		if (InputManager.instance.KeyDown("Jump") && isGrounded == false && doubleJumped == false && inPositiveGravFeild == false)
		{
			velocity.y = Mathf.Sqrt(jumpHight * -2f * gravity);
			controller.slopeLimit = 90f; //stop jumping gitter
			doubleJumped = true;
		}

		if (!crouched && InputManager.instance.KeyDown("Crouch"))
		{
			crouched = true;
			this.gameObject.transform.localScale = new Vector3(this.gameObject.transform.localScale.x, this.gameObject.transform.localScale.y / 2, this.gameObject.transform.localScale.z);
		}
		else if(crouched && InputManager.instance.KeyDown("Crouch"))
		{
			this.gameObject.transform.localScale = new Vector3(this.gameObject.transform.localScale.x, this.gameObject.transform.localScale.y * 2, this.gameObject.transform.localScale.z);
			crouched = false;
		}

			velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
