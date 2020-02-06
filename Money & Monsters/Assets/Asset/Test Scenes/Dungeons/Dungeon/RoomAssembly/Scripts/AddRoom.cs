﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRoom : MonoBehaviour
{
    private RoomTemplates templates;
    [SerializeField] private bool wayPoint = true;
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
}