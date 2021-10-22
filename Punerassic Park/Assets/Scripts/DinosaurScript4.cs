using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DinosaurScript4 : MonoBehaviour
{
    public float timeMove = 1f;

    public float rotatePosx;
    public float rotatePosy;
    public float rotatePosz;
    public float movex;
    public float movey;

    // Start is called before the first frame update
    void Start()
    {
        rotatePosx = Random.Range(-100f, 100f);
        rotatePosy = Random.Range(-100f, 100f);
        rotatePosz = Random.Range(-100f, 100f);
        movex = Random.Range(gameObject.transform.position.x - 5f, gameObject.transform.position.x + 5f);
        movey = Random.Range(gameObject.transform.position.y - 5f, gameObject.transform.position.y + 5f);
    }

    // Update is called once per frame
    void Update()
    {

        transform.Rotate(new Vector3(rotatePosx, rotatePosy, rotatePosz) * Time.deltaTime);

        transform.position += new Vector3(movex * Time.deltaTime, movey * Time.deltaTime, 0f);
        timeMove -= Time.deltaTime;
        if (timeMove <= 0.0f)
        {
            movex = movex * -1f;
            movey = movey * -1f;
            timeMove = 2f;
        }

    }

}