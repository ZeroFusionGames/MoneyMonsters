﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallGenerator : MonoBehaviour
{
    private RoomTemplates templates;
    public bool hasColided = false;

    // Start is called before the first frame update
    void Start()
    {
        templates = GameObject.FindGameObjectWithTag("roomTemplate").GetComponent<RoomTemplates>();
        Invoke("GenWall", 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        hasColided = true;
    }

    void GenWall()
    {
        if(hasColided == false)
        {
            var rand = Random.Range(0, templates.closedRooms.Length);
            Instantiate(templates.closedRooms[rand], transform.position, Quaternion.identity);
        }
        else if(hasColided == true)
        {
            Destroy(this.gameObject);
        }
    }
}
