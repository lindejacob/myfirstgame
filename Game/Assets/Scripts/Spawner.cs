using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] SpawnPatterns;
    public GameObject pattern;
    public float spawnrate;
    public Vector3 spawnoffset;
    public GameObject player;
    public GameObject Road;
    private LaneControl playerScript;
    private float lastspawn;
    private int spawnedPatterns = 5;
    private float liftwall = 1;
    private float travelDistance;
    private int spawnedRotes = 0;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 1; i < spawnedPatterns; i++)
        {
            GameObject pattern = SpawnPatterns[Random.Range(0, SpawnPatterns.Length)];
            GameObject spawnedpattern = Instantiate(pattern);
            lastspawn = 0;
            spawnedpattern.transform.position = new Vector3(0, liftwall, player.transform.position.z) + spawnoffset* i;
        }
        playerScript = player.GetComponent<LaneControl>();
    }

    // Update is called once per frame
    void Update()
    {
        lastspawn += Time.deltaTime;
        if (lastspawn > spawnrate) 
        {
            GameObject pattern = SpawnPatterns[Random.Range(0, SpawnPatterns.Length)];
            GameObject spawnedpattern = Instantiate(pattern);
            lastspawn = 0;
            spawnedpattern.transform.position = new Vector3(0, liftwall, player.transform.position.z) + spawnoffset * spawnedPatterns;
        }
        travelDistance += playerScript.speed * Time.deltaTime;
        if (travelDistance > 50) {
            GameObject spawnedRoad = Instantiate(Road);
            spawnedRoad.transform.position = Vector3.forward * (50 + (100 * spawnedRotes));
            spawnedRotes++;
            travelDistance -= 100;
        }
    }
}
