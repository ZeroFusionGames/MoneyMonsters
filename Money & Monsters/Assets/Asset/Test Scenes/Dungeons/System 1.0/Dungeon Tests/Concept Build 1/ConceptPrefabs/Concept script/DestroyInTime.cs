using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyInTime : MonoBehaviour
{
    public float waitTime;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, waitTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
