using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointSwitcher : MonoBehaviour
{
    public GameObject originalSpawnPoint;
    public GameObject switchSpawnPoint;
    public float waitTime = 4.0f;
    public GameObject spawnPointDestroyer;
    public GameObject collided;

    void Start()
    {
        switchSpawnPoint.SetActive(false);
        Destroy(this.gameObject, waitTime);
        
    }

    void Update()
    {
        if(spawnPointDestroyer.GetComponent<Destroyer>().invertGen == true)
        {
            StartCoroutine("flipSpawn");
        }

        if (collided.CompareTag("SpawnDestroyer"))
        {
            if (collided.GetComponent<Destroyer>().invertGen == true)
            {
                spawnPointDestroyer.GetComponent<Destroyer>().invertGen = true;

            }
        }
        
    }

    void OnTriggerEnter(Collider other)
    {
        collided = other.gameObject;

        if(other.gameObject.CompareTag("spawnPoint"))
        {
            if(other.gameObject.GetComponent<RoomSpawner>().spawned == true)
            {

                StartCoroutine("flipSpawn");
            }
        }
        else if (other.gameObject.CompareTag("wall"))
        {
            StartCoroutine("flipSpawn");
        }

    }

    void flipSpawn()
    {
        
        //originalSpawnPoint.SetActive(false);
        Debug.Log("Debug");
        switchSpawnPoint.SetActive(true);
        spawnPointDestroyer.GetComponent<Destroyer>().invertGen = true;
        //Destroy(originalSpawnPoint);
        Destroy(this.gameObject);
        
    }
}
