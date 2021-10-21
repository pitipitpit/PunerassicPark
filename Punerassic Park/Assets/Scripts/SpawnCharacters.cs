using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCharacters : MonoBehaviour
{
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] GameObject[] Dinosaurs;
    [SerializeField] int counter;

    public void Rerun()
    {

        StartCoroutine(StartSpawning());
    }

    IEnumerator StartSpawning()
    {

        yield return new WaitForSeconds(1);

        for (int i = 0; i < 3; i++)
        {
            Instantiate(Dinosaurs[i], spawnPoints[i].position, Quaternion.identity); //spawn each dinosaur at each position
            counter++;

        }

        while (counter < 3)
        { //only spawn 3 dinosaurs
            StartCoroutine(StartSpawning());
        }


    }
}
