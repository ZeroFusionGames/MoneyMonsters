using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : Interactable
{
	public Animator animator;
	private bool open;

	public override void Interact()
	{
		base.Interact();
		if (!open)
		{
			animator.SetTrigger("Open");
			interacted = false;
			open = true;
		}
		else if (open)
		{
			animator.SetTrigger("Close");
			interacted = false;
			open = false;
		}

	}

	
}
