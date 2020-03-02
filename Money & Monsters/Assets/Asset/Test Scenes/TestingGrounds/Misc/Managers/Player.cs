using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	#region Pick up objects variables
	[Header("Pick Up Options")]
	[SerializeField] private string selectionManagerTag = "Main Manager";
	private SelectionManager selectionManager;
	public bool handsFull; // does the player have an objct in their hand
	public GameObject hand; // Where Tools are held
	public GameObject itemHolder; // Where Items are held
	public GameObject currentItemInHand; // Current Item in players hand
	public float throwStrength; // players throw strength
	#endregion
	// Start is called before the first frame update

	private void Start()
	{
		selectionManager = GameObject.FindGameObjectWithTag(selectionManagerTag).GetComponent<SelectionManager>();
		selectionManager.gameObject.GetComponent<HUDManager>().StartCoroutine("fadeOutPlayerHUD");
	}

	// Update is called once per frame
	void Update()
    {
        if(InputManager.instance.KeyDown("Pickup"))
		{
			if (handsFull == false)
			{
				StartCoroutine("pickupToHand");
			}
			else if(handsFull == true)
			{
				StartCoroutine("DropItemInHand");
			}
		}
		if (InputManager.instance.KeyDown("Throw") && handsFull == true)
		{
			StartCoroutine("ThrowItemInHand");
		}
	}

	void pickupToHand()
	{
		if(selectionManager.focus != null)
		{
			GameObject target;
			target = selectionManager.focus;
			Transform interactionTransform = target.GetComponent<Interactable>().interactionTransform;
			if (selectionManager.selectionConfirmed == true && target.GetComponent<PickUpable>())
			{
				Vector3 targetOffset;

				
				if(target.GetComponent<PickUpable>().isTool == true)
				{
					target.transform.SetParent(hand.transform);
					targetOffset = target.transform.position - interactionTransform.position;
				}
				else
				{
					target.transform.SetParent(itemHolder.transform);
					targetOffset = Vector3.zero;
				}
				//target.transform.localPosition = Vector3.zero;
				target.transform.localPosition = targetOffset;
				if(target.GetComponent<PickUpable>().isTool == true)
				{
					target.transform.localRotation = Quaternion.Inverse(interactionTransform.localRotation);
				}
				else
				{
					target.transform.localRotation = Quaternion.Euler(0,0,0);
				}
				
				target.GetComponent<Interactable>().unSelectable = true;
				if(target.GetComponent<Rigidbody>() != null)
				{
					target.GetComponent<Rigidbody>().isKinematic = true;
				}
				currentItemInHand = target;
				target = null;
				if(currentItemInHand.GetComponent<PickUpable>().isTool == false)
				{
					DisableColliders();
				}
				handsFull = true;
			}
			else
			{
				target = null;
				handsFull = false;
			}
		}

	}

	void ThrowItemInHand()
	{
		EnableColliders();
		Matrix4x4 worldPosMatrix = currentItemInHand.transform.worldToLocalMatrix;
		worldPosMatrix.MultiplyPoint3x4(currentItemInHand.transform.position);
		currentItemInHand.GetComponent<Interactable>().unSelectable = false;
		currentItemInHand.transform.SetParent(null);
		if (currentItemInHand.GetComponent<Rigidbody>() != null)
		{
			currentItemInHand.GetComponent<Rigidbody>().isKinematic = false;
			currentItemInHand.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * throwStrength, ForceMode.Impulse);
			currentItemInHand.GetComponent<Rigidbody>().AddTorque(transform.right * .5f, ForceMode.Impulse);
		}

		currentItemInHand = null;
		handsFull = false;
	}

	void DropItemInHand()
	{
		EnableColliders();
		Matrix4x4 worldPosMatrix = currentItemInHand.transform.worldToLocalMatrix;
		worldPosMatrix.MultiplyPoint3x4(currentItemInHand.transform.position);
		currentItemInHand.GetComponent<Interactable>().unSelectable = false;
		currentItemInHand.transform.SetParent(null);
		if (currentItemInHand.GetComponent<Rigidbody>() != null)
		{
			currentItemInHand.GetComponent<Rigidbody>().isKinematic = false;
		}

		currentItemInHand = null;
		handsFull = false;
	}

	void EnableColliders()
	{
		if (currentItemInHand.GetComponent<Collider>())
		{
			currentItemInHand.GetComponent<Collider>().enabled = true;
		}
		for (int i = 0; i < currentItemInHand.transform.childCount; i++)
		{
			if (currentItemInHand.transform.GetChild(i).GetComponent<Collider>())
			{
				currentItemInHand.transform.GetChild(i).GetComponent<Collider>().enabled = true;
			}
		}
	}

	void DisableColliders()
	{
		if(currentItemInHand.GetComponent<Collider>())
		{
			currentItemInHand.GetComponent<Collider>().enabled = false;
		}
		for (int i = 0; i < currentItemInHand.transform.childCount; i++)
		{
			if (currentItemInHand.transform.GetChild(i).GetComponent<Collider>())
			{
				currentItemInHand.transform.GetChild(i).GetComponent<Collider>().enabled = false;
			}
		}
	}
}
