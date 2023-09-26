using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] GameObject prefab;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Dothis", 1, .5f);
    }

    void Dothis()
    {
        Vector3 point = spawnPoints[Random.Range(0, spawnPoints.Length)].position;
        Instantiate(prefab, point, Quaternion.identity);
    }
}
