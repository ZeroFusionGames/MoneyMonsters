using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSetSorter : MonoBehaviour
{
	[Header("Insert blank roomset")]
	public RoomSets roomSet;
	[Header("Input all rooms to sort")]
	public GameObject[] roomsToSort;
	[Header("Sorted Rooms")]
    public List<GameObject> leftRooms;
    public List<GameObject> rightRooms;
    public List<GameObject> topRooms;
    public List<GameObject> bottomRooms;
    public List<GameObject> upRooms;
    public List<GameObject> downRooms;
    [Header("Crouch Room Components")]
    public List<GameObject> crouchLeftRooms;
    public List<GameObject> crouchRightRooms;
    public List<GameObject> crouchTopRooms;
    public List<GameObject> crouchBottomRooms;
    [Header("Wall Component")]
    public List<GameObject> closedRooms;

    [ContextMenu("Sort Rooms")]
    void sortRooms()
    {
        foreach (var item in roomsToSort)
        {
            var room = item.GetComponent<AddRoom>();
            if (room.leftDoor) { leftRooms.Add(item); }
            if (room.rightDoor) { rightRooms.Add(item); }
            if (room.topDoor) { topRooms.Add(item); }
            if (room.bottomDoor) { bottomRooms.Add(item); }
            if (room.upDoor) { upRooms.Add(item); }
            if (room.downDoor) { downRooms.Add(item); }
            if (room.crouchBottomRooms) { crouchBottomRooms.Add(item); }
            if (room.crouchLeftRooms) { crouchLeftRooms.Add(item); }
            if (room.crouchRightRooms) { crouchRightRooms.Add(item); }
            if (room.crouchTopRooms) { crouchTopRooms.Add(item); }
            if (!room.leftDoor && !room.rightDoor && !room.topDoor && !room.bottomDoor && !room.upDoor && !room.downDoor && !room.crouchBottomRooms && !room.crouchLeftRooms && !room.crouchRightRooms && !room.crouchTopRooms) { closedRooms.Add(item); }
        }
    }

    [ContextMenu("Apply to RoomSet")]
    void ApplyToRoomSet()
    {
        roomSet.leftRooms = new GameObject[0];
        roomSet.rightRooms = new GameObject[0];
        roomSet.topRooms = new GameObject[0];
        roomSet.bottomRooms = new GameObject[0];
        roomSet.upRooms = new GameObject[0];
        roomSet.downRooms = new GameObject[0];
        roomSet.crouchBottomRooms = new GameObject[0];
        roomSet.crouchLeftRooms = new GameObject[0];
        roomSet.crouchRightRooms = new GameObject[0];
        roomSet.crouchTopRooms = new GameObject[0];

        roomSet.leftRooms = leftRooms.ToArray();
        roomSet.rightRooms = rightRooms.ToArray();
        roomSet.topRooms = topRooms.ToArray();
        roomSet.bottomRooms = bottomRooms.ToArray();
        roomSet.upRooms = upRooms.ToArray();
        roomSet.downRooms = downRooms.ToArray();
        roomSet.closedRooms = closedRooms.ToArray();
        roomSet.crouchBottomRooms = crouchBottomRooms.ToArray();
        roomSet.crouchLeftRooms = crouchLeftRooms.ToArray();
        roomSet.crouchRightRooms = crouchRightRooms.ToArray();
        roomSet.crouchTopRooms = crouchTopRooms.ToArray();
    }

    [ContextMenu("Sort and Apply")]
    void SortAndApply()
    {
        sortRooms();
        ApplyToRoomSet();
    }

    [ContextMenu("Reset Lists")]
    private void ResetLists()
    {
        leftRooms.Clear();
        rightRooms.Clear();
        topRooms.Clear();
        bottomRooms.Clear();
        upRooms.Clear();
        downRooms.Clear();
        crouchBottomRooms.Clear();
        crouchLeftRooms.Clear();
        crouchRightRooms.Clear();
        crouchTopRooms.Clear();
    }
}
