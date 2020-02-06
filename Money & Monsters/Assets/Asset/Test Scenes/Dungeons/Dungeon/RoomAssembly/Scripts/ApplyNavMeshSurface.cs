using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ApplyNavMeshSurface : MonoBehaviour
{
    public GameObject[] navmeshCollection;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("ApplyNavMesh", 4.5f);
    }

    void ApplyNavMesh()
    {

        navmeshCollection = GameObject.FindGameObjectsWithTag("NavMesh");
        Bake();
    }
    void Bake()
    {
        foreach (var item in navmeshCollection)
        {
            item.transform.SetParent(this.transform);
        }
        this.GetComponent<NavMeshSurface>().BuildNavMesh();
    }
}
