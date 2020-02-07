using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyWall : MonoBehaviour
{

    void OnTriggerEnter(Collider other)

    {
        if (other.gameObject.CompareTag("wall"))
        {
            Destroy(other.gameObject);

        }
    }
}
