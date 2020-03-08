using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRoom : MonoBehaviour
{
    private RoomTemplates templates;
    [SerializeField] private bool wayPoint = true;
    [Header("Openings")]
    public bool leftDoor;
    public bool rightDoor;
    public bool topDoor;
    public bool bottomDoor;
    public bool upDoor;
    public bool downDoor;
    [Header("Crouch Room Components")]
    public bool crouchLeftRooms;
    public bool crouchRightRooms;
    public bool crouchTopRooms;
    public bool crouchBottomRooms;
    // Start is called before the first frame update
    void Start()
    {
        templates = GameObject.FindGameObjectWithTag("roomTemplate").GetComponent<RoomTemplates>();
        templates.rooms.Add(this.gameObject);
        Invoke("addWaypoint", 2f);
    }

    public void addWaypoint()
    {
        if (this.tag != "wall" && wayPoint)
        {
            GameObject.FindGameObjectWithTag("Main Manager").GetComponent<WaypointManagement>().waypoints.Add(this.transform);
        }
        
    }

    private void OnDestroy()
    {
        templates.rooms.Remove(this.gameObject);
    }
}
