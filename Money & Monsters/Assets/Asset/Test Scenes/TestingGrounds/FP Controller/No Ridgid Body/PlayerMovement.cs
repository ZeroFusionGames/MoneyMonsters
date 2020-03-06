using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public CharacterController controller;
	private Camera cam;
	private float camFOV;

    [SerializeField] private float speed = 12f;
	public float crouchSpeed = 12f;
	public float walkSpeed = 12f;
	public float runSpeed = 12f;
	public float gravity = -9.8f;
	public float terminalVolocity = -100f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public float jumpHight = 3f;
	private bool doubleJumped;
	public bool inPositiveGravFeild;
	
	//Crouch settings
	private bool crouched;
	[SerializeField] private float crouchPercentage = 2.5f;
	[SerializeField] private GameObject playerCamera;
	[SerializeField] private GameObject playerBody;

	public Vector3 velocity;
    bool isGrounded;

	private void Start()
	{
		cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
		camFOV = cam.fieldOfView;
	}

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
		#region Crouch
		if (!crouched && InputManager.instance.KeyDown("Crouch")) //crouch
		{
			crouched = true;
			playerBody.transform.localScale = new Vector3(playerBody.transform.localScale.x, playerBody.transform.localScale.y / crouchPercentage, playerBody.transform.localScale.z);
			playerCamera.transform.localPosition = new Vector3(playerCamera.transform.localPosition.x, playerCamera.transform.localPosition.y / crouchPercentage, playerCamera.transform.localPosition.z);
			controller.height = controller.height / crouchPercentage;
			speed = crouchSpeed;
		}
		else if(crouched && InputManager.instance.KeyDown("Crouch")) //stand up
		{
			velocity.y = Mathf.Sqrt(1 * -2f * gravity);
			playerBody.transform.localScale = new Vector3(playerBody.transform.localScale.x, playerBody.transform.localScale.y * crouchPercentage, playerBody.transform.localScale.z);
			playerCamera.transform.localPosition = new Vector3(playerCamera.transform.localPosition.x, playerCamera.transform.localPosition.y * crouchPercentage, playerCamera.transform.localPosition.z);
			controller.height = controller.height * crouchPercentage;
			speed = walkSpeed;
			crouched = false;
		}
		#endregion


		#region Sprint
		if (!crouched && InputManager.instance.GetKey("Sprint")) //crouch
		{
			speed = runSpeed;
			cam.fieldOfView = camFOV + 10f;
		}
		else
		{
			speed = walkSpeed;
			cam.fieldOfView = camFOV;
		}
			#endregion

			velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
