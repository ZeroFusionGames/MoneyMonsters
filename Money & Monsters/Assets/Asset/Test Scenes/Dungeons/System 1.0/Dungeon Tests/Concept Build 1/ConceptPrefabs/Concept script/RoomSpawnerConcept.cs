using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawnerConcept : MonoBehaviour
{
    public int openingDirection;
    // 1 --> Needs Left Door
    // 2 --> Needs Right Door
    // 3 --> Needs Top Door
    // 4 --> Needs Bottom Door
    // 5 --> Needs Down Door
    // 6 --> Needs Up Door

    //BigRoom Assembley
    // 10 --> Needs topRight
    // 11 --> Needs topLeft
    // 12 --> Needs bottomRight
    // 13 --> Needs bottomLeft

    private RoomTemplatesConcept templates;
    private int rand;
    public bool spawned = false;
    public GameObject spawnPoint;


    public float waitTime = 5f;

    void Start()
    {
        
        this.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        this.gameObject.GetComponent<BoxCollider>().isTrigger = true;

        Destroy(gameObject, waitTime);
        templates = GameObject.FindGameObjectWithTag("roomTemplate").GetComponent<RoomTemplatesConcept>();

        Invoke("SpawnRoom", 0.1f);
    }

    void SpawnRoom()
    {
        if(spawned == false)
        {
            if (openingDirection == 1)
            {
                //Needs room with left door
                rand = Random.Range(0, templates.leftRooms.Length);
                Instantiate(templates.leftRooms[rand], transform.position, templates.leftRooms[rand].transform.rotation);
            }
            else if (openingDirection == 2)
            {
                //Needs room with right door
                rand = Random.Range(0, templates.rightRooms.Length);
                Instantiate(templates.rightRooms[rand], transform.position, templates.rightRooms[rand].transform.rotation);
            }
            else if (openingDirection == 3)
            {
                //Needs room with Top door
                rand = Random.Range(0, templates.topRooms.Length);
                Instantiate(templates.topRooms[rand], transform.position, templates.topRooms[rand].transform.rotation);
            }
            else if (openingDirection == 4)
            {
                //Needs room with Bottom door
                rand = Random.Range(0, templates.bottomRooms.Length);
                Instantiate(templates.bottomRooms[rand], transform.position, templates.bottomRooms[rand].transform.rotation);
            }
            else if (openingDirection == 5)
            {
                //Needs room with Down door
                rand = Random.Range(0, templates.downRooms.Length);
                Instantiate(templates.downRooms[rand], transform.position, templates.downRooms[rand].transform.rotation);
            }
            else if (openingDirection == 6)
            {
                //Needs room with Up door
                rand = Random.Range(0, templates.upRooms.Length);
                Instantiate(templates.upRooms[rand], transform.position, templates.upRooms[rand].transform.rotation);
            }

            //Big Room Spawners
            else if (openingDirection == 10)
            {
                // 10 --> Needs topRight
                rand = Random.Range(0, templates.topRightRooms.Length);
                Instantiate(templates.topRightRooms[rand], transform.position, templates.topRightRooms[rand].transform.rotation);
            }
            else if (openingDirection == 11)
            {
                // 11 --> Needs topLeft
                rand = Random.Range(0, templates.topleftRooms.Length);
                Instantiate(templates.topleftRooms[rand], transform.position, templates.topleftRooms[rand].transform.rotation);
            }
            else if (openingDirection == 12)
            {
                // 12 --> Needs bottomRight
                rand = Random.Range(0, templates.bottomRightRooms.Length);
                Instantiate(templates.bottomRightRooms[rand], transform.position, templates.bottomRightRooms[rand].transform.rotation);
            }
            else if (openingDirection == 13)
            {
                // 13 --> Needs bottomLeft
                rand = Random.Range(0, templates.bottomLeftRooms.Length);
                Instantiate(templates.bottomLeftRooms[rand], transform.position, templates.bottomLeftRooms[rand].transform.rotation);
            }
            spawned = true;

        }
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("spawnPoint"))
        {
            if (other.GetComponent<RoomSpawnerConcept>().spawned == false && spawned == false)
            {
                //spawn wall to block holes]
                Instantiate(templates.closedRooms, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            spawned = true;
           
            

        }
    }
   

}
