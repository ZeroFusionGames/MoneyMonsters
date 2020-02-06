using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ObjectDestructionOnImpactScript : MonoBehaviour
{
	public Rigidbody rb;
	public GameObject destroyedVersion;
	public float strength = 4;
	public bool broken;
	// Start is called before the first frame update
	void Start()
    {
		rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame


    void Update()
    {

    }

	void OnCollisionEnter(Collision collision)
	{
		CheckAndBreak(collision);
	}

	private void CheckAndBreak(Collision collision)
	{
		if(!broken)
		{
			if (rb.velocity.magnitude > strength || collision.gameObject.GetComponent<Rigidbody>() && (collision.gameObject.GetComponent<Rigidbody>().velocity.magnitude > strength))
			{
				if (collision.gameObject.GetComponent<ObjectDestructionOnImpactScript>() && collision.gameObject.GetComponent<ObjectDestructionOnImpactScript>().broken == false)
				{
					if (rb.velocity.magnitude > collision.gameObject.GetComponent<ObjectDestructionOnImpactScript>().strength)
					{
						collision.gameObject.GetComponent<ObjectDestructionOnImpactScript>().BreakApart();

					}
					else;
				}
				BreakApart();
				broken = true;
			}
		}
	}

	public void BreakApart()
	{

		destroyedVersion = Instantiate(destroyedVersion);
		destroyedVersion.transform.position = this.transform.position;
		destroyedVersion.transform.rotation = this.transform.rotation;
		destroyedVersion.transform.localScale = this.transform.localScale;
		List<Rigidbody> destroyedVersionRidgidBodies = new List<Rigidbody>();
		destroyedVersion.AddComponent<DestroyAfterDelay>();
		for (int i = 0; i < destroyedVersion.transform.childCount; i++)
		{
			if(destroyedVersion.transform.GetChild(i).GetComponent<Rigidbody>())
			{
				destroyedVersionRidgidBodies.Add(destroyedVersion.transform.GetChild(i).GetComponent<Rigidbody>());
			}
		}
		foreach (Rigidbody rbDestroyed in destroyedVersionRidgidBodies)
		{
			rbDestroyed.velocity = rb.velocity;
			
			rbDestroyed.gameObject.AddComponent<DestroyAfterDelay>();
		}
		Destroy(this.gameObject);
	}
}
