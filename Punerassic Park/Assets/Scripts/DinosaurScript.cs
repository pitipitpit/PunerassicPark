using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinosaurScript : MonoBehaviour
{
    public TimeScript timeScript;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Update()
    {

            transform.Rotate(new Vector3(0f,100f,0f) * Time.deltaTime);    
    }
}
