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
        Invoke("PlaceObject", spawnTimer);
    }

    void PlaceObject()
    {
        var objectnumber = Random.Range(0, objectSet.objects.Length);
        var rarenumber = Random.Range(0, 100);
        if (rarenumber < rarity)
        {
            Instantiate(objectSet.objects[objectnumber],this.transform.position, Quaternion.identity);
        }
        Destroy(this.gameObject);
    }
}
