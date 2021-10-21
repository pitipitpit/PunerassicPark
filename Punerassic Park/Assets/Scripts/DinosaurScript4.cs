using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DinosaurScript4 : MonoBehaviour
{
    public TimeScript timeScript;

    private Vector3 dinoBounds;
    // public float movementSpeed = 1f;
    
    // private bool isWandering = false;
    // private bool isWalking = false;
    
    public Rigidbody rb;
    float x;
    float y;



    // Start is called before the first frame update
    void Start()
    {
        dinoBounds = gameObject.transform.position;

   
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0f,100f,0f) * Time.deltaTime ); 
        

        x = Random.Range(dinoBounds.x -0.5f, dinoBounds.x + 0.5f);
        y = Random.Range(dinoBounds.y -0.5f, dinoBounds.y + 0.5f);

        transform.position += new Vector3(x* Time.deltaTime,y* Time.deltaTime,0);



               
    }

}
