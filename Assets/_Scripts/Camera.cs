using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] float cameraBoundaries;
    void Update()
    {
        Transform player = GameObject.FindWithTag("Player").transform;
        float y = Mathf.Clamp(player.position.y, -cameraBoundaries, cameraBoundaries);

        transform.position = new Vector3(0, y, -10);
    }
}
