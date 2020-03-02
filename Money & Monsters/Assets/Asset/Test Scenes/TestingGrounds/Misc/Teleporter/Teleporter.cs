using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleporter : Interactable
{
	public string Scenename;
	public Animator animator;
	public bool hasAnimator = true;

	public override void Interact()
	{
		base.Interact();
		Debug.Log("switched");
		if (hasAnimator)
		{
			animator.Play("Activate");
		}
		else
		{
			SceneManager.LoadScene(Scenename);
		}
		
	}

	void Teleport()
	{
		SceneManager.LoadScene(Scenename);
	}
}
