using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seek : MonoBehaviour
{
    Transform target;
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, 0.005f);
    }
}
