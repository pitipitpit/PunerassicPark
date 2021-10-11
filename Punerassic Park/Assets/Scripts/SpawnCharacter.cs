using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCharacter : MonoBehaviour
{
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] GameObject[] Dinosaurs;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartSpawning());

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator StartSpawning()
    {

        yield return new WaitForSeconds(4);

        for (int i =0; i < 3; i++)
        {
            Instantiate(Dinosaurs[i], spawnPoints[i].position, Quaternion.identity);
        }

        StartCoroutine(StartSpawning());

 
    }
}
