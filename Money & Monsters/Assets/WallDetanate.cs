using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDetanate : MonoBehaviour
{
	public Rigidbody wallRigidbody;
	public int hitProtection = 1;
	private int hits;
	public bool goBang;

    // Start is called before the first frame update
    void Start()
    {
		wallRigidbody = this.GetComponent<Rigidbody>();
		hits = 0;
		wallRigidbody.isKinematic = true;
		goBang = false;
	}

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.G))
		{
			hits++;
		}

		if(hits == hitProtection  && goBang == false)
		{
			wallRigidbody.isKinematic = false;
			goBang = true;
		}
		else if (hits < hitProtection)
		{
			wallRigidbody.isKinematic = true;
		}
    }
}
