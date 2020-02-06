using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleEnableObject : Interactable
{
	public GameObject objectInUse;


	public override void Interact()
	{
		base.Interact();

		if (objectInUse.activeSelf)
		{
			objectInUse.SetActive(false);
		}
		else if (!objectInUse.activeSelf)
		{
			objectInUse.SetActive(true);
		}
		

	}
}
