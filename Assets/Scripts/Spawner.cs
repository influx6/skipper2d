using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public Transform[] spawnPoints;
    public GameObject[] hazards;
    public GameObject player;

    public float decrease;
    private float timeBetweenSpawns;
    public float startTimeBtwnSpawns;
    public float minTimeBetweenSpawns;

    // Update is called once per frame
    void Update()
    {
        if (player != null) {
            if (timeBetweenSpawns <= 0) {
                // spawn new hazards
                Transform randomSpawn = spawnPoints[Random.Range(0, spawnPoints.Length)];
                GameObject randomHazard = hazards[Random.Range(0, hazards.Length)];

                Instantiate(randomHazard, randomSpawn.position, Quaternion.identity);

                if (startTimeBtwnSpawns > minTimeBetweenSpawns){
                    startTimeBtwnSpawns -= decrease;
                }

                timeBetweenSpawns = startTimeBtwnSpawns;
                return;
            }

            timeBetweenSpawns -= Time.deltaTime;
        }
    }
}
