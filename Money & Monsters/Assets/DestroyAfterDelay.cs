using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterDelay : MonoBehaviour
{
	public int delay = 10;
	// Start is called before the first frame update
	void Start()
	{
		StartCoroutine("BeginDestruction");
	}

	public IEnumerator BeginDestruction()
	{
		yield return new WaitForSeconds(delay);
		if(this.GetComponent<Interactable>())
		{
			if(this.GetComponent<Interactable>().unSelectable)
			{
				this.GetComponent<Interactable>().player.GetComponent<Player>().currentItemInHand = null;
				this.GetComponent<Interactable>().player.GetComponent<Player>().handsFull = false;
				
			}
		}
		
		if (this.gameObject.GetComponent<Collider>())
		{
			Destroy(this.gameObject.GetComponent<Collider>());
			
		}
		else;
		yield return new WaitForSeconds(2);
		Destroy(this.gameObject);
	}
}
