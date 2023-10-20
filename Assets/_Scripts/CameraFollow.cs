using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] float cameraBoundaries;
    [SerializeField] Transform target;
    
    void Update()
    {
        float y = Mathf.Clamp(target.position.y, -cameraBoundaries, cameraBoundaries);

        transform.position = new Vector3(0, y, -10);
    }
}
