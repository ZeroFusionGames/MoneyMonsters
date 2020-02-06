using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplatesConcept : MonoBehaviour
{
    [Header("Room Components")]
    public GameObject[] bottomRooms;
    public GameObject[] leftRooms;
    public GameObject[] rightRooms;
    public GameObject[] topRooms;
    [Header("Elevation Room Components")]
    public GameObject[] upRooms;
    public GameObject[] downRooms;

    [Header("Big Room Components")]
    public GameObject[] topleftRooms;
    public GameObject[] bottomLeftRooms;
    public GameObject[] topRightRooms;
    public GameObject[] bottomRightRooms;

    [Header("Wall Component")]
    public GameObject closedRooms;

    [Header("Spawned rooms")]
    public List<GameObject> rooms;

    public float waitTime;
    private bool spawnedBoss;
    public GameObject boss;

    void Update()
    {
        if (waitTime <= 0 && spawnedBoss == false)
        {
            for (int i = 0; i < rooms.Count; i++)
            {
                if(i == rooms.Count-1)
                {
                    Instantiate(boss, rooms[i].transform.position, Quaternion.identity);
                    spawnedBoss = true;
                }
            }
        }
        else
        {
            waitTime -= Time.deltaTime;
        }
        
    }
}