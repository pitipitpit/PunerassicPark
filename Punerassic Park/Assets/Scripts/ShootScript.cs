using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootScript : MonoBehaviour
{
    public GameObject arCamera;
    public GameObject dinosaurPrefab;
    public AudioSource dieSound;
    public int currentScore = 0;
    public TMPro.TextMeshProUGUI textScore;
    public bool dinoDie;

    public void Shoot() {
        RaycastHit hit;
            if(Physics.Raycast(arCamera.transform.position, arCamera.transform.forward, out hit)){
                if(hit.transform.name == "trex(Clone)"){
                    // if (!dieSound.isPlaying)
                    //     {
                    //         dieSound.Play();
                    //         Debug.Log("sound on");
                    //     }
                    playAudio();
                    Destroy(hit.transform.gameObject);
                    float a = Random.Range(-5f, 5f);
                    float b = Random.Range(-5f, 5f);
                    Instantiate(dinosaurPrefab, new Vector3(a, 0f, b), Quaternion.identity);
                    currentScore = currentScore + 1;
                    textScore.text = "Score : " + currentScore;
                    // dinoDie.Stop();
                }
        }   
    }
    IEnumerator playAudio()
    {
        //Play Audio
        dieSound.Play();

        //Wait until it's done playing
        while (dieSound.isPlaying)
            yield return null;
        Debug.Log("sound on");
    }
    
    


}
