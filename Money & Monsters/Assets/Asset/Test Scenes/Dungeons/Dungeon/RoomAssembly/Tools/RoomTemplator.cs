using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplator : MonoBehaviour
{
	[Header ("Room Size Config")]
	public float RoomSize;
	public float RoomHeight;

	[Header("Room Componants")]
	public GameObject spawnPoint;
	public GameObject destoryer;
	private GameObject room;

	[Header("Door Config")]
	public bool leftDoor = false;
	public bool rightDoor = false;
	public bool topDoor = false;
	public bool bottomDoor = false;
	public bool upDoor = false;
	public bool downDoor = false;

	private void OnDrawGizmos()
	{
		Gizmos.DrawWireCube(new Vector3(0, RoomHeight / 2, 0), new Vector3(RoomSize, RoomHeight, RoomSize));
	}

	[ContextMenu("Reset Door")]
	private void ResetDoors()
	{
		leftDoor = false;
		rightDoor = false;
		topDoor = false;
		bottomDoor = false;
		upDoor = false;
		downDoor = false;
	}

	[ContextMenu("Delete Last Room")]
	private void DeleteLastMadeDoor()
	{
		DestroyImmediate(room);
		room = null;
	}

	[ContextMenu("Create Room Template")]
	private void CreateRoomTemplate()
	{
		//Create the empty game objects and parents them.
		room = new GameObject("INSERT ROOM NAME");
		var spawnPoints = new GameObject("SpawnPoints");
		spawnPoints.transform.SetParent(room.transform);
		var toAdd = new GameObject("Walls");
		toAdd.transform.SetParent(room.transform);
		toAdd = new GameObject("Floors");
		toAdd.transform.SetParent(room.transform);
		toAdd = new GameObject("Ceilings");
		toAdd.transform.SetParent(room.transform);
		toAdd = new GameObject("Objects");
		toAdd.transform.SetParent(room.transform);

		if(leftDoor)
		{
			var currentSpawn = Instantiate(spawnPoint, new Vector3(-RoomSize, 0, 0), Quaternion.identity);
			currentSpawn.transform.SetParent(spawnPoints.transform);
			currentSpawn.GetComponent<RoomSpawner>().opening = RoomSpawner.openingDirection.Left;
			currentSpawn.name = "LeftSpawn";
		}
		if (rightDoor)
		{
			var currentSpawn = Instantiate(spawnPoint, new Vector3(RoomSize, 0, 0), Quaternion.identity);
			currentSpawn.transform.SetParent(spawnPoints.transform);
			currentSpawn.GetComponent<RoomSpawner>().opening = RoomSpawner.openingDirection.Right;
			currentSpawn.name = "RightSpawn";
		}
		if (topDoor)
		{
			var currentSpawn = Instantiate(spawnPoint, new Vector3(0, 0, RoomSize), Quaternion.identity);
			currentSpawn.transform.SetParent(spawnPoints.transform);
			currentSpawn.GetComponent<RoomSpawner>().opening = RoomSpawner.openingDirection.Top;
			currentSpawn.name = "TopSpawn";
		}
		if (bottomDoor)
		{
			var currentSpawn = Instantiate(spawnPoint, new Vector3(0, 0, -RoomSize), Quaternion.identity);
			currentSpawn.transform.SetParent(spawnPoints.transform);
			currentSpawn.GetComponent<RoomSpawner>().opening = RoomSpawner.openingDirection.Bottom;
			currentSpawn.name = "BottomSpawn";
		}
		if (upDoor)
		{
			var currentSpawn = Instantiate(spawnPoint, new Vector3(0, RoomHeight, 0), Quaternion.identity);
			currentSpawn.transform.SetParent(spawnPoints.transform);
			currentSpawn.GetComponent<RoomSpawner>().opening = RoomSpawner.openingDirection.Up;
			currentSpawn.name = "UpSpawn";
		}
		if (downDoor)
		{
			var currentSpawn = Instantiate(spawnPoint, new Vector3(0, -RoomHeight, 0), Quaternion.identity);
			currentSpawn.transform.SetParent(spawnPoints.transform);
			currentSpawn.GetComponent<RoomSpawner>().opening = RoomSpawner.openingDirection.Down;
			currentSpawn.name = "DownSpawn";
		}

		var currentDestroyer = Instantiate(destoryer, Vector3.zero, Quaternion.identity);
		currentDestroyer.GetComponent<BoxCollider>().center = new Vector3(0, RoomHeight / 4, 0);
		currentDestroyer.GetComponent<BoxCollider>().size = new Vector3(RoomSize - 0.1f, RoomHeight / 2, RoomSize - 0.1f);
		currentDestroyer.transform.SetParent(room.transform);
	}
}
