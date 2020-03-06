using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
	[Header("Base interactable settings")]
	public bool selected;
	public bool interacted;
	public bool interactable = true;
	public bool unSelectable = false;
	public float radius = 3;
	public bool oneUse = false;
	public GameObject player;
	public Transform interactionTransform;
	


	[SerializeField] private float playerDistance;
	 public GameObject selectionManager;
	[SerializeField] private string selectionManagerTag = "Main Manager";
	


	protected virtual void Start()
	{
		selectionManager = GameObject.FindGameObjectWithTag(selectionManagerTag);
		player = GameObject.FindGameObjectWithTag("Player");

	}

	public void Update()
	{
		playerDistance = Vector3.Distance(player.transform.position, this.interactionTransform.position);
		

		if(selected == true && interactable == true && InputManager.instance.KeyDown("Interact"))
		{
			
			if(!interacted)
			{
				StartCoroutine("Interact");
			}
			if (oneUse)
			{
				interacted = true;
			}
		}

		if(selectionManager.GetComponent<SelectionManager>().focus == this.gameObject && playerDistance < radius)
		{
			selected = true;
		}
		else
		{
			if(!oneUse)
			{
				interacted = false;
			}
			selected = false;
		}
	}

	void OnDrawGizmosSelected ()
	{
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(interactionTransform.position, radius);
		

	}
	void OnDrawGizmos()
	{
		Gizmos.DrawRay(interactionTransform.position, interactionTransform.forward);
	}

	public virtual void Interact()
	{
		//Made to be overritten
		
	}

	private void OnValidate()
	{
		if (interactionTransform == null)
		{
			interactionTransform = transform;
		}
	}
}
