using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{
    [Header("Room Set")]
    public RoomSets roomSet;

    [Header("Room Components")]
    public GameObject[] leftRooms;
    public GameObject[] rightRooms;
    public GameObject[] topRooms;
    public GameObject[] bottomRooms;
    [Header("Elevation Room Components")]
    public GameObject[] upRooms;
    public GameObject[] downRooms;

    [Header("Big Room Components")]
    public GameObject[] topleftRooms;
    public GameObject[] bottomLeftRooms;
    public GameObject[] topRightRooms;
    public GameObject[] bottomRightRooms;

    [Header("Wall Component")]
    public GameObject[] closedRooms;

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

    [ContextMenu("Populate Roomset")]
    void PopulateTemplate()
    {
        bottomRooms = roomSet.bottomRooms;
        leftRooms = roomSet.leftRooms;
        rightRooms = roomSet.rightRooms;
        topRooms = roomSet.topRooms;
        upRooms = roomSet.upRooms;
        downRooms = roomSet.downRooms;
        closedRooms = roomSet.closedRooms;
    }

    [ContextMenu("Reset Roomset")]
    void ResetTemplate()
    {
        bottomRooms = new GameObject[0];
        leftRooms = new GameObject[0];
        rightRooms = new GameObject[0];
        topRooms = new GameObject[0];
        upRooms = new GameObject[0];
        downRooms = new GameObject[0];
        closedRooms = new GameObject[0];
    }

    [ContextMenu("Reset and Populate")]
    void ResetAndPopulate()
    {
        ResetTemplate();
        PopulateTemplate();
    }
}