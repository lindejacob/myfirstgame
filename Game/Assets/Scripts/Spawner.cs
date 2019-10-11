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
    public int spawnedPatterns;
    public int PalmAmount;
    public float DistanceBeetwenPalms;
    public GameObject palms;

    private LaneControl playerScript;
    private float lastspawn;
    private float liftwall = 1;
    private float travelDistance;
    private float travelDistancepalms;
    private int spawnedRotes = 0;
    private int spawnedPalms = 0;
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
        for (int i = 1; i < PalmAmount; i++)
        {
            GameObject spawnedtrees = Instantiate(palms);
            spawnedtrees.transform.position = new Vector3(-17.5F, 0, player.transform.position.z) + (Vector3.forward * DistanceBeetwenPalms * i);
            spawnedPalms++;
        }
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
        travelDistancepalms += playerScript.speed * Time.deltaTime;
        if (travelDistancepalms > DistanceBeetwenPalms)
        {
            travelDistancepalms -= DistanceBeetwenPalms ;
            GameObject spawnedPalm = Instantiate(palms);
            spawnedPalm.transform.position = new Vector3(-17.5F, 0, player.transform.position.z) + (Vector3.forward * DistanceBeetwenPalms * this.spawnedPalms);
            this.spawnedPalms++;
        }

    }
}
