using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] float spawnDelay, spawnFrequency;
    [SerializeField] GameObject prefab;
    
    void Start()
    {
        InvokeRepeating("SpawnOrganism", spawnDelay, spawnFrequency);
    }

    void SpawnOrganism()
    {
        Vector3 point = spawnPoints[Random.Range(0, spawnPoints.Length)].position;
        Instantiate(prefab, point, Quaternion.identity);
    }
}
