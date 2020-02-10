using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplator : MonoBehaviour
{

	[TextArea]
	public string Guide = "Use multiples of 3. Odd multiples work the best. Always add .5 to the end";
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

	[Header("Room Parts")]
	public GameObject[] wall;
	public GameObject[] floor;
	public GameObject[] doorWays;
	public GameObject[] doorSpawners;
	public GameObject[] roof;

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
		var addRoomScript = room.AddComponent<AddRoom>();
		#region Add Spawnpoints to room data
		if (leftDoor) { addRoomScript.leftDoor = true; }
		if (rightDoor) { addRoomScript.rightDoor = true; }
		if (topDoor) { addRoomScript.topDoor = true; }
		if (bottomDoor) { addRoomScript.bottomDoor = true; }
		if (upDoor) { addRoomScript.upDoor = true; }
		if (downDoor) { addRoomScript.downDoor = true; }
		#endregion
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

	[ContextMenu("Create Entire Room")]
	private void CreateRoomFully()
	{
		//Create the empty game objects and parents them.
		float wallamount = ((RoomSize - 0.5f) / 3);
		room = new GameObject("INSERT ROOM NAME");
		var addRoomScript = room.AddComponent<AddRoom>();
		#region Add Spawnpoints to room data
		if (leftDoor) { addRoomScript.leftDoor = true; }
		if (rightDoor) { addRoomScript.rightDoor = true; }
		if (topDoor) { addRoomScript.topDoor = true; }
		if (bottomDoor) { addRoomScript.bottomDoor = true; }
		if (upDoor) { addRoomScript.upDoor = true; }
		if (downDoor) { addRoomScript.downDoor = true; }
		#endregion

		#region SpawnPoints
		var spawnPoints = new GameObject("SpawnPoints");
		spawnPoints.transform.SetParent(room.transform);

		if (leftDoor)
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
		#endregion
		#region walls
		var walls = new GameObject("Walls");
		walls.transform.SetParent(room.transform);
		if(!leftDoor)
		{
			var lastLocation = -1.5f; //start wall -1.5m so when it adds 3 to the first the end lines up with 0
			var addTo = new GameObject("LeftWalls");
			addTo.transform.SetParent(walls.transform);
			for (int i = 0; i < wallamount; i++) //Loop through all the walls needed
			{
				var currentwall = Instantiate(wall[Random.Range(0, wall.Length )], new Vector3(0, 0.25f, lastLocation+3),Quaternion.identity); //create a wall 3m further than the last
				lastLocation = currentwall.transform.position.z;
				currentwall.transform.SetParent(addTo.transform);
			}
			addTo.transform.rotation = Quaternion.Euler(0, 180, 0); //rotate the entire wall object to allow same algorithm to be used for all orientation
			addTo.transform.position = new Vector3(-((RoomSize/2)-0.125f), 0, ((wallamount / 2) * 3)); //calculates the exact position needed to place wall object holder

		}
		else//Apply DoorWay
		{
			var lastLocation = -1.5f; //start wall -1.5m so when it adds 3 to the first the end lines up with 0
			var addTo = new GameObject("LeftWalls");
			addTo.transform.SetParent(walls.transform);
			for (int i = 0; i < wallamount; i++) //Loop through all the walls needed
			{
				if(lastLocation != (((wallamount/2)*3)-3)) //you do the wallamount/2*3 to find the middle wall, you then -3 to get the wall before as the code +3
				{
					var currentwall = Instantiate(wall[Random.Range(0,wall.Length)], new Vector3(0, 0.25f, lastLocation + 3), Quaternion.identity); 
					lastLocation = currentwall.transform.position.z;
					currentwall.transform.SetParent(addTo.transform);
				}
				else
				{
					var currentwall = Instantiate(doorWays[Random.Range(0, doorWays.Length )], new Vector3(0, 0.25f, lastLocation + 3), Quaternion.identity);
					Instantiate(doorSpawners[Random.Range(0, doorSpawners.Length)], new Vector3(0, 0.25f, lastLocation + 3), Quaternion.identity,currentwall.transform);
					lastLocation = currentwall.transform.position.z;
					currentwall.transform.SetParent(addTo.transform);
				}
			}
			addTo.transform.rotation = Quaternion.Euler(0, 180, 0); //rotate the entire wall object to allow same algorithm to be used for all orientation
			addTo.transform.position = new Vector3(-((RoomSize / 2) - 0.125f), 0, ((wallamount / 2) * 3)); //calculates the exact position needed to place wall object holder
		}
		if (!rightDoor)
		{
			var lastLocation = -1.5f;
			var addTo = new GameObject("RightWalls");
			addTo.transform.SetParent(walls.transform);
			for (int i = 0; i < wallamount; i++)
			{
				var currentwall = Instantiate(wall[Random.Range(0, wall.Length )], new Vector3(0, 0.25f, lastLocation + 3), Quaternion.identity);
				lastLocation = currentwall.transform.position.z;
				currentwall.transform.SetParent(addTo.transform);
			}
			addTo.transform.rotation = Quaternion.Euler(0, 0, 0);
			addTo.transform.position = new Vector3(((RoomSize / 2) - 0.125f), 0, -((wallamount / 2) * 3));
		}
		else//Apply DoorWay
		{
			var lastLocation = -1.5f;
			var addTo = new GameObject("RightWalls");
			addTo.transform.SetParent(walls.transform);
			for (int i = 0; i < wallamount; i++)
			{
				if (lastLocation != (((wallamount / 2) * 3) - 3))
				{
					var currentwall = Instantiate(wall[Random.Range(0, wall.Length )], new Vector3(0, 0.25f, lastLocation + 3), Quaternion.identity);
					lastLocation = currentwall.transform.position.z;
					currentwall.transform.SetParent(addTo.transform);
				}
				else
				{
					var currentwall = Instantiate(doorWays[Random.Range(0, doorWays.Length )], new Vector3(0, 0.25f, lastLocation + 3), Quaternion.identity);
					Instantiate(doorSpawners[Random.Range(0, doorSpawners.Length)], new Vector3(0, 0.25f, lastLocation + 3), Quaternion.identity, currentwall.transform);
					lastLocation = currentwall.transform.position.z;
					currentwall.transform.SetParent(addTo.transform);
				}
			}
			addTo.transform.rotation = Quaternion.Euler(0, 0, 0);
			addTo.transform.position = new Vector3(((RoomSize / 2) - 0.125f), 0, -((wallamount / 2) * 3));
		}
		if (!topDoor)
		{
			var lastLocation = -1.5f;
			var addTo = new GameObject("TopWalls");
			addTo.transform.SetParent(walls.transform);
			for (int i = 0; i < wallamount; i++)
			{
				var currentwall = Instantiate(wall[Random.Range(0, wall.Length )], new Vector3(0, 0.25f, lastLocation + 3), Quaternion.identity);
				lastLocation = currentwall.transform.position.z;
				currentwall.transform.SetParent(addTo.transform);
			}
			addTo.transform.rotation = Quaternion.Euler(0, 270, 0);
			addTo.transform.position = new Vector3(((wallamount / 2) * 3), 0, ((RoomSize / 2) - 0.125f));
			
		}
		else//Apply DoorWay
		{
			var lastLocation = -1.5f;
			var addTo = new GameObject("TopWalls");
			addTo.transform.SetParent(walls.transform);
			for (int i = 0; i < wallamount; i++)
			{
				if (lastLocation != (((wallamount / 2) * 3) - 3))
				{
					var currentwall = Instantiate(wall[Random.Range(0, wall.Length )], new Vector3(0, 0.25f, lastLocation + 3), Quaternion.identity);
					lastLocation = currentwall.transform.position.z;
					currentwall.transform.SetParent(addTo.transform);
				}
				else
				{
					var currentwall = Instantiate(doorWays[Random.Range(0, doorWays.Length )], new Vector3(0, 0.25f, lastLocation + 3), Quaternion.identity);
					Instantiate(doorSpawners[Random.Range(0, doorSpawners.Length)], new Vector3(0, 0.25f, lastLocation + 3), Quaternion.identity, currentwall.transform);
					lastLocation = currentwall.transform.position.z;
					currentwall.transform.SetParent(addTo.transform);
				}
			}
			addTo.transform.rotation = Quaternion.Euler(0, 270, 0);
			addTo.transform.position = new Vector3(((wallamount / 2) * 3), 0, ((RoomSize / 2) - 0.125f));
		}
		if (!bottomDoor)
		{
			var lastLocation = -1.5f;
			var addTo = new GameObject("BottomWalls");
			addTo.transform.SetParent(walls.transform);
			for (int i = 0; i < wallamount; i++)
			{
				var currentwall = Instantiate(wall[Random.Range(0, wall.Length )], new Vector3(0, 0.25f, lastLocation + 3), Quaternion.identity);
				lastLocation = currentwall.transform.position.z;
				currentwall.transform.SetParent(addTo.transform);
			}
			addTo.transform.rotation = Quaternion.Euler(0, 90, 0);
			addTo.transform.position = new Vector3(-((wallamount/2)*3), 0, -((RoomSize / 2) - 0.125f));
		}
		else//Apply DoorWay
		{
			var lastLocation = -1.5f;
			var addTo = new GameObject("BottomWalls");
			addTo.transform.SetParent(walls.transform);
			for (int i = 0; i < wallamount; i++)
			{
				if (lastLocation != (((wallamount / 2) * 3)-3))
				{
					var currentwall = Instantiate(wall[Random.Range(0, wall.Length )], new Vector3(0, 0.25f, lastLocation + 3), Quaternion.identity);
					lastLocation = currentwall.transform.position.z;
					currentwall.transform.SetParent(addTo.transform);
				}
				else
				{
					var currentwall = Instantiate(doorWays[Random.Range(0, doorWays.Length )], new Vector3(0, 0.25f, lastLocation + 3), Quaternion.identity);
					Instantiate(doorSpawners[Random.Range(0, doorSpawners.Length)], new Vector3(0, 0.25f, lastLocation + 3), Quaternion.identity, currentwall.transform);
					lastLocation = currentwall.transform.position.z;
					currentwall.transform.SetParent(addTo.transform);
				}
			}
			addTo.transform.rotation = Quaternion.Euler(0, 90, 0);
			addTo.transform.position = new Vector3(-((wallamount / 2) * 3), 0, -((RoomSize / 2) - 0.125f));
		}
		#endregion
		#region Floors
		var floors = new GameObject("Floors");
		floors.transform.SetParent(room.transform);

		var floorSpaceing = -(((wallamount/2)*3)+1.5f); //the starting offset for the flooring
		for (int i = 0; i < wallamount; i++) //loops to create all strips
		{
			var lastLocation = -1.5f; // sets offset for floors in strip (also resets with each loop)
			var currentFloorStrip = new GameObject("FloorStrip"); // this will hold a strip of the floor
			for (int q = 0; q < wallamount; q++) //this creates the strip
			{

				var currentFloor = Instantiate(floor[Random.Range(0,floor.Length)], new Vector3(0,0,lastLocation+3), Quaternion.identity); // this creates each floor in the strip
				lastLocation = currentFloor.transform.position.z; // this sets the last position to allow next floor to spawn next to it
				currentFloor.transform.SetParent(currentFloorStrip.transform); // parents the floor to it's strip
			}
			currentFloorStrip.transform.position = new Vector3(floorSpaceing+3,0, -((RoomSize / 2) - 0.25f)); //offsets each strip to fill in flooring
			floorSpaceing = currentFloorStrip.transform.position.x; // updates the offset of each strip so that they move net to the last one
			currentFloorStrip.transform.SetParent(floors.transform); // parents each strip to the floor container
		}
		#endregion

		#region Roof
		var roofs = new GameObject("Ceilings");
		roofs.transform.SetParent(room.transform);

		var roofSpacing = -(((wallamount / 2) * 3) + 1.5f); //the starting offset for the roof
		for (int i = 0; i < wallamount; i++)
		{
			var lastLocation = -1.5f;
			var currentRoofStrip = new GameObject("RoofStrip");
			for (int q = 0; q < wallamount; q++)
			{

				var currentFloor = Instantiate(roof[Random.Range(0, roof.Length )], new Vector3(0, 0, lastLocation + 3), Quaternion.identity);
				lastLocation = currentFloor.transform.position.z;
				currentFloor.transform.SetParent(currentRoofStrip.transform);
			}
			currentRoofStrip.transform.position = new Vector3(roofSpacing + 3, RoomHeight-0.25f, -((RoomSize / 2) - 0.25f));
			roofSpacing = currentRoofStrip.transform.position.x;
			currentRoofStrip.transform.SetParent(floors.transform);
		}
		#endregion

		var objects = new GameObject("Objects");
		objects.transform.SetParent(room.transform);
	}
}
