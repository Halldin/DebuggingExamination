using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Spawn : MonoBehaviour
{
    [Header("Organisms")]
    [SerializeField] GameObject redOrganism;

    //The precentage chances must add upp to exactly 1 for expected results!
    [SerializeField, Range(0,1)] float redSpawnChance;
    [SerializeField] GameObject blueOrganism;
    [SerializeField, Range(0,1)] float blueSpawnChance;
    [SerializeField] GameObject greenOrganism;
    [SerializeField, Range(0,1)] float greenSpawnChance;

    [Header("Cells")]
    [SerializeField] GameObject cell;

    [Header("Spawn Values")]
    [SerializeField] int cellsToSpawn;
    [SerializeField] float spawnRadious;
    [SerializeField] float spawnDelay, spawnFrequency;
    [SerializeField] float minDistanceFromPlayer;
    [SerializeField] Transform player;
    [SerializeField] Transform redPool, bluePool, greenPool, cellPool;
    
    void Start()
    {
        SpawnCells();
        InvokeRepeating("SpawnOrganism", spawnDelay, spawnFrequency);
    }

    void SpawnOrganism()
    {
        //Spawn an organism within the set radius, while not spawning it too close to the player.
        Vector3 point = player.position;
        while(Vector2.Distance(player.position, point) < minDistanceFromPlayer){
            point = Random.insideUnitCircle * spawnRadious;
        }   

        //Choose which organism to spawn.
        GameObject organism = null;
        Transform pool = null;

        float value = Random.value;

        //Choose the random organism.
        if(redSpawnChance >= value){
            organism = redOrganism;
            pool = redPool;
        }else if(blueSpawnChance + redSpawnChance >= value){
            organism = blueOrganism;
            pool = bluePool;
        }else if(greenSpawnChance + redSpawnChance + blueSpawnChance >=  value){
            organism = greenOrganism;
            pool = greenPool;
        }

        Instantiate(organism, point, Quaternion.identity, pool);
    }

    void SpawnCells(){
        //Spawn cells which populate the play area.
        for(int i = 0; i < cellsToSpawn; i++){
            Vector2 point = Random.insideUnitCircle * spawnRadious;
            Instantiate(cell, point, Quaternion.identity, cellPool);
        }
    }
}
