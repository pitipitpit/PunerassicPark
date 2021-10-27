using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyExplode : MonoBehaviour
{
    public float timeLeft;

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

    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0.0f)
        {
            Destroy(this.gameObject);
        }
    }
}