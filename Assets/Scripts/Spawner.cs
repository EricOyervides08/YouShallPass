using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] carPrefabs;
    public Vector3 spawnPoint;
    public int timeTilNextSpawn = 5;
    float timer = 0;

    void Start()
    {
        timer = 0;
        
    }

    private void Update()
    {
        timer += Time.deltaTime;
        Spawn();
    }

    void Spawn()
    {
        if (timer >= timeTilNextSpawn)
        {
            Instantiate(SelectACarPrefab(), spawnPoint, Quaternion.identity);
            timer = 0;
        }
    }

    private GameObject SelectACarPrefab()
    {
        int randfromIndex = Random.Range(0, carPrefabs.Length);
        return carPrefabs[randfromIndex];
    }
}