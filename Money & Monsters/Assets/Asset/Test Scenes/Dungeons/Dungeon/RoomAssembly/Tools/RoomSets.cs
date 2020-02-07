using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewRoomSet",menuName = "RoomSet")]
public class RoomSets : ScriptableObject
{
    [Header("Room Components")]
    public GameObject[] leftRooms;
    public GameObject[] rightRooms;
    public GameObject[] topRooms;
    public GameObject[] bottomRooms;
    [Header("Elevation Room Components")]
    public GameObject[] upRooms;
    public GameObject[] downRooms;
    [Header("Wall Component")]
    public GameObject[] closedRooms;
}
