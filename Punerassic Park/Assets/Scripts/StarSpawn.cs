using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSpawn : MonoBehaviour
{
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] GameObject[] Stars;
    public int counter;

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

        yield return new WaitForSeconds(1);
            
            for (int i =0; i < 3; i++)
            {
                Instantiate(Stars[i], spawnPoints[i].position, Quaternion.identity); //spawn each dinosaur at each position
                counter++;
                
            }
        
        while(counter < 3){ //only spawn 3 dinosaurs
            StartCoroutine(StartSpawning());
        }
        
 
    }

    public void rerun()
    {

        StartCoroutine(StartSpawning());
    }
}
