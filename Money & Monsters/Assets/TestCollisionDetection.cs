using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCollisionDetection : MonoBehaviour
{
	public GameObject collisionmarker;
	void OnCollisionEnter(Collision collision)
	{
		foreach (ContactPoint contact in collision.contacts)
		{
			Instantiate<GameObject>(collisionmarker, contact.point, Quaternion.FromToRotation(Vector3.down, contact.normal));
			Debug.Log("contacted");
		}
	}
}
