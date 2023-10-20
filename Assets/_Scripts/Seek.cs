using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seek : MonoBehaviour
{
    [SerializeField] float movementSpeed;
    Transform target;
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
    }

    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, movementSpeed);
    }
}
