using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinosaurScript : MonoBehaviour
{
    public float rotatePosx;
    public float rotatePosy;
    public float rotatePosz;

    // Start is called before the first frame update
    void Start()
    {
        rotatePosx = Random.Range(-100f, 100f);
        rotatePosy = Random.Range(-100f, 100f);
        rotatePosz = Random.Range(-100f, 100f);
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Rotate(new Vector3(rotatePosx,rotatePosy,rotatePosz) * Time.deltaTime ); 
      
    }
}
