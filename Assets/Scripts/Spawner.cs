using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    //array de prefabs de carros
    public GameObject[] carPrefabs;

    //tiempo entre cada spawn
    public int timeTilNextSpawn = 5;

    //temporizador
    float timer = 0;

    void Start()
    {
        timer = 0;
    }

    private void Update()
    {
        //contar tiempo, y llamar funcion spawn
        timer += Time.deltaTime;
        Spawn();
    }

    void Spawn()
    {
        //si ya pasamos el tiempo establecido
        if (timer >= timeTilNextSpawn)
        {
            //instanciar un nuevo carro dentro de la lista con la posicion y rotacion del spawner
            Instantiate(SelectACarPrefab(), transform.position, transform.rotation);

            //resetear tiempo
            timer = 0;
        }
    }

    private GameObject SelectACarPrefab()
    {
        //dentro del array, elegir un carro al azar
        int randfromIndex = Random.Range(0, carPrefabs.Length);
        return carPrefabs[randfromIndex];
    }
}