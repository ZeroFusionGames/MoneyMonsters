using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
	public GameObject focus;
	public Transform player;
	public bool selectionConfirmed;
	//public GameObject hitchecker;
	// Update is called once per frame

	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player").transform;
	}


	void Update()
    {
		var ray = Camera.main.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
		Debug.DrawRay(ray.origin, ray.direction * 5000000, Color.red);
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit))
		{
			var selection = hit.transform;
			//hitchecker.transform.position = hit.transform.position;
			Interactable interactable = selection.GetComponent<Interactable>();
			if (interactable != null && interactable.unSelectable == false)
			{
				SetFocus(selection);
				if(selection.GetComponent<Interactable>().selected == true)
				{
					selectionConfirmed = true;
				}
				else
				{
					selectionConfirmed = false;
				}
			}
			else
			{
				focus = null;
				selectionConfirmed = false;
			}

		}
    }

	void SetFocus(Transform newFocus)
	{
		focus = newFocus.gameObject;
	}
}
