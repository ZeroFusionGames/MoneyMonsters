using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public bool invertGen = false;

    void Start()
    {

        this.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        this.gameObject.GetComponent<BoxCollider>().isTrigger = true;
    }

        void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("spawnPoint") == true)
        {
            Destroy(other.gameObject);
        }

    }
}
