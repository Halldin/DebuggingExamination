using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    [SerializeField] float randomStepSize;
    void FixedUpdate()
    {
        transform.position = transform.position + new Vector3(Random.Range(-randomStepSize, randomStepSize), Random.Range(-randomStepSize, randomStepSize));
    }
}