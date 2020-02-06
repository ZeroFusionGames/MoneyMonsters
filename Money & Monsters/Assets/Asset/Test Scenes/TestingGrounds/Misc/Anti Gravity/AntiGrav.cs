using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiGrav : MonoBehaviour
{
	public PlayerMovement player;
	public float gravityModValue;
	public float originalGravValue;
	public float originalGroundCheck;
	public float originalVelocity;
	public float objectsGravMulti;
	public Rigidbody[] allGravObjects = new Rigidbody[0];

	void Start()
	{
		player =  GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
		originalGravValue = player.gravity;
		originalGroundCheck = player.groundDistance;

	}

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			player.gravity = gravityModValue;
			if(gravityModValue > 0)
			{
				player.groundDistance = 0f;
				player.velocity.y = Mathf.Clamp(player.velocity.y, -gravityModValue, gravityModValue);
				if(gravityModValue > 0)
				{
					player.inPositiveGravFeild = true;
				}
				
			}
		}
		if(other.GetComponent<Rigidbody>())
		{
			
			other.GetComponent<Rigidbody>();
			launchObjects();
		}
	}

	void OnTriggerExit(Collider other)
	{
		player.gravity = originalGravValue;
		player.groundDistance = originalGroundCheck;
		player.inPositiveGravFeild = false;
		if (other.GetComponent<Rigidbody>())
		{ 
			other.GetComponent<Rigidbody>().useGravity = true;
			other.GetComponent<Rigidbody>().angularDrag = 0.05f;
		}
	}

	public IEnumerator launchObjects()
	{
		yield return new WaitForSeconds(1);
		for (int i = 0; i < allGravObjects.Length; i++)
		{
			allGravObjects[i].useGravity = false;
			allGravObjects[i].AddRelativeForce(0f, -gravityModValue * objectsGravMulti, 0f);
			allGravObjects[i].angularDrag = 0f;
			
		}
		System.Array.Clear(allGravObjects, 0, allGravObjects.Length);
	}
}
