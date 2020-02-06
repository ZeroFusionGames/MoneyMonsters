using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    #region Outdated spawn guide
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
    #endregion

    public enum openingDirection
    {
        Left,
        Right,
        Top,
        Bottom,
        Up,
        Down,
    }
    public openingDirection opening;


    private RoomTemplates templates;
    private int rand;
    public bool spawned = false;
    public GameObject spawnPoint;


    public float waitTime = 5f;

    void Start()
    {
        
        this.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        this.gameObject.GetComponent<BoxCollider>().isTrigger = true;

        Destroy(gameObject, waitTime);
        templates = GameObject.FindGameObjectWithTag("roomTemplate").GetComponent<RoomTemplates>();

        Invoke("SpawnRoom", 0.1f);
    }

    void SpawnRoom()
    {
        if(spawned == false)
        {
            switch(opening)
            {
                case openingDirection.Left:
                    LeftDoor();
                    break;
                case openingDirection.Right:
                    RightDoor();
                    break;
                case openingDirection.Top:
                    TopDoor();
                    break;
                case openingDirection.Bottom:
                    BottomDoor();
                    break;
                case openingDirection.Up:
                    UpDoor();
                    break;
                case openingDirection.Down:
                    DownDoor();
                    break;
            }
                

            ////Big Room Spawners
            //else if (openingDirection == 10)
            //{
            //    // 10 --> Needs topRight
            //    rand = Random.Range(0, templates.topRightRooms.Length);
            //    Instantiate(templates.topRightRooms[rand], transform.position, templates.topRightRooms[rand].transform.rotation);
            //}
            //else if (openingDirection == 11)
            //{
            //    // 11 --> Needs topLeft
            //    rand = Random.Range(0, templates.topleftRooms.Length);
            //    Instantiate(templates.topleftRooms[rand], transform.position, templates.topleftRooms[rand].transform.rotation);
            //}
            //else if (openingDirection == 12)
            //{
            //    // 12 --> Needs bottomRight
            //    rand = Random.Range(0, templates.bottomRightRooms.Length);
            //    Instantiate(templates.bottomRightRooms[rand], transform.position, templates.bottomRightRooms[rand].transform.rotation);
            //}
            //else if (openingDirection == 13)
            //{
            //    // 13 --> Needs bottomLeft
            //    rand = Random.Range(0, templates.bottomLeftRooms.Length);
            //    Instantiate(templates.bottomLeftRooms[rand], transform.position, templates.bottomLeftRooms[rand].transform.rotation);
            //}
            //spawned = true;

        }
        
    }

    private void DownDoor()
    {
        //Needs room with Up door
        rand = Random.Range(0, templates.upRooms.Length);
        Instantiate(templates.upRooms[rand], transform.position, templates.upRooms[rand].transform.rotation);
    }

    private void UpDoor()
    {
        //Needs room with Down door
        rand = Random.Range(0, templates.downRooms.Length);
        Instantiate(templates.downRooms[rand], transform.position, templates.downRooms[rand].transform.rotation);
    }

    private void TopDoor()
    {
        //Needs room with Bottom door
        rand = Random.Range(0, templates.bottomRooms.Length);
        Instantiate(templates.bottomRooms[rand], transform.position, templates.bottomRooms[rand].transform.rotation);
    }

    private void BottomDoor()
    {
        //Needs room with Top door
        rand = Random.Range(0, templates.topRooms.Length);
        Instantiate(templates.topRooms[rand], transform.position, templates.topRooms[rand].transform.rotation);
    }

    private void LeftDoor()
    {
        //Needs room with right door
        rand = Random.Range(0, templates.rightRooms.Length);
        Instantiate(templates.rightRooms[rand], transform.position, templates.rightRooms[rand].transform.rotation);
    }

    private void RightDoor()
    {
        //Needs room with left door
        rand = Random.Range(0, templates.leftRooms.Length);
        Instantiate(templates.leftRooms[rand], transform.position, templates.leftRooms[rand].transform.rotation);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("spawnPoint"))
        {
            if (other.GetComponent<RoomSpawner>().spawned == false && spawned == false)
            {
                //spawn wall to block holes]
                Instantiate(templates.closedRooms, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            spawned = true;
           
            

        }
    }
   

}
