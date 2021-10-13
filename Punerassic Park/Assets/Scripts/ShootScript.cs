using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour
{
    public GameObject arCamera;
    public GameObject dinosaurPrefab;
    public AudioSource dinoDie;
    
    public void Shoot() {
        RaycastHit hit;

        if(Physics.Raycast(arCamera.transform.position, arCamera.transform.forward, out hit)){
            if(hit.transform.name == "trex(Clone)"){
                // dinoDie.Play();
                Destroy(hit.transform.gameObject);
                float a = Random.Range(-5f, 5f);
                float b = Random.Range(-5f, 5f);
                Instantiate(dinosaurPrefab, new Vector3(a, 0f, b), Quaternion.identity);
                // dinoDie.Stop();
            }
        }
    }
}
