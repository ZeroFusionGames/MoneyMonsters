using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSetSpawner : MonoBehaviour
{
    public float spawnTimer = 5;
    [Range(0,100)]public int rarity = 50;
    public ObjectSet objectSet;

    void Start()
    {
        //if(spawnTimer <= 0)
        //{
        //    spawnTimer = 0.1f;
        //}
        Invoke("PlaceObject", spawnTimer);
    }

    [ContextMenu("SpawnObject")]
    void PlaceObject()
    {
        var objectnumber = Random.Range(0, objectSet.objects.Length);
        var rarenumber = Random.Range(0, 100);
        if (rarenumber <= rarity)
        {
            Instantiate(objectSet.objects[objectnumber], this.transform);
        }
        //Destroy(this.gameObject);
    }
}
