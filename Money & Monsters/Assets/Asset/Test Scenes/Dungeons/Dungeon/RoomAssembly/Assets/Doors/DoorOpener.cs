using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : Interactable
{
	public Animator animator;

	public override void Interact()
	{
		base.Interact();

		animator.enabled = true;
	}
}
