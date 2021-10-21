using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scene5Script : MonoBehaviour
{
     public GameObject goodComplete;
    public GameObject failMission;
    public GameObject greatComplete;
    public GameObject perfectComplete;

    public GameObject replayButton;
    public GameObject NextGameButton;
    public GameObject ExitButton;
    public float time;
    
    public float trexTime;
    public float triTime;
    public float longTime;

    public GameObject arCamera;
    public GameObject trexPrefab;
    public GameObject longPrefab;
    public GameObject triPrefab;
    public GameObject starPrefab;
    public GameObject dynamitePrefab;
    // public GameObject explode;
    public GameObject explodeEffect;
    public AudioSource dieSound;
    public int currentScore = 0;
    public TMPro.TextMeshProUGUI textScore;
    public bool dinoDie;

    public Image timerBar;
    public float maxTime = 5f;
    float timeLeft;

    public GameObject criteria;
    public GameObject ok;

    public GameObject[] Dinosaurs;
    public int counter;
    public GameObject star;

    private bool canRun = false;
    private bool canShoot = false;


    public void Run()
    {
        trexTime = 3;
        Time.timeScale = 1;
        canRun = true;
        canShoot = true;
        timeLeft = maxTime;
        criteria.SetActive(false);
        ok.SetActive(false);
        perfectComplete.SetActive(false);
        greatComplete.SetActive(false);
        goodComplete.SetActive(false);
        failMission.SetActive(false);
        replayButton.SetActive(false);
        NextGameButton.SetActive(false);
        ExitButton.SetActive(false);
        StartCoroutine(StartSpawning());
    }

    // Update is called once per frame
    void Update()
    {
        if (canRun) {
            if (timeLeft > 0) {
                timeLeft -= Time.deltaTime;
                timerBar.fillAmount = timeLeft / maxTime;
                
            } else {
                Time.timeScale = 0;
                if (currentScore >= 30) {
                    perfectComplete.SetActive(true);
                    replayButton.SetActive(true);
                    NextGameButton.SetActive(true);
                    ExitButton.SetActive(true);

                } else if (currentScore >= 20) {
                    greatComplete.SetActive(true);
                    replayButton.SetActive(true);
                    NextGameButton.SetActive(true);
                    ExitButton.SetActive(true);

                } else if ( currentScore >= 10) {
                    goodComplete.SetActive(true);
                    replayButton.SetActive(true);
                    NextGameButton.SetActive(true);
                    ExitButton.SetActive(true);

                } else if (currentScore < 10) {
                    failMission.SetActive(true);
                    replayButton.SetActive(true);
                    ExitButton.SetActive(true);
                }
                canRun = false;
            }
        }  
       
    }

    public void Shoot() {
        if (canShoot) {
            RaycastHit hit;
            if (timeLeft > 0){
                if(Physics.Raycast(arCamera.transform.position, arCamera.transform.forward, out hit)){
                    if(hit.transform.name == "trex5(Clone)"){
                        if (!dieSound.isPlaying)
                            {
                                dieSound.Play();
                                Debug.Log("sound on");
                            }
                        playAudio();
                        Destroy(hit.transform.gameObject);
                        float a = Random.Range(-5f, 5f);
                        float b = Random.Range(-5f, 5f);
                        Instantiate(trexPrefab, new Vector3(a, 0f, b), Quaternion.identity);
                        currentScore = currentScore + 1;
                        textScore.text = "Score : " + currentScore;
                        // dinoDie.Stop();
                    }
                    
                    if(hit.transform.name == "tri5(Clone)"){
                        if (!dieSound.isPlaying)
                        {
                            dieSound.Play();
                            Debug.Log("sound on");
                        }
                        playAudio();
                        Destroy(hit.transform.gameObject);
                        float a = Random.Range(-5f, 5f);
                        float b = Random.Range(-5f, 5f);
                        Instantiate(triPrefab, new Vector3(a, 0f, b), Quaternion.identity);
                        if (timeLeft > 2){
                            timeLeft = timeLeft - 2;
                        } else {
                            timeLeft = 0;
                        }
                        
                        currentScore = currentScore + 2;
                        textScore.text = "Score : " + currentScore;
                        // dinoDie.Stop();
                    }
                    if(hit.transform.name == "long5(Clone)"){
                        if (!dieSound.isPlaying)
                        {
                            dieSound.Play();
                            Debug.Log("sound on");
                        }
                        playAudio();
                        Destroy(hit.transform.gameObject);
                        float a = Random.Range(-5f, 5f);
                        float b = Random.Range(-5f, 5f);
                        Instantiate(longPrefab, new Vector3(a, 0f, b), Quaternion.identity);
                        if (timeLeft > 3){
                            timeLeft = timeLeft - 3;
                        } else {
                            timeLeft = 0;
                        }
                        currentScore = currentScore + 3;
                        textScore.text = "Score : " + currentScore;
                        // dinoDie.Stop();
                    }
                    if(hit.transform.name == "stars5(Clone)"){
                        if (!dieSound.isPlaying)
                        {
                            dieSound.Play();
                            Debug.Log("sound on");
                        }
                        playAudio();
                        Destroy(hit.transform.gameObject);
                        float a = Random.Range(-5f, 5f);
                        float b = Random.Range(-5f, 5f);
                        Instantiate(starPrefab, new Vector3(a, 0f, b), Quaternion.identity);
                        currentScore = currentScore - 1;
                        textScore.text = "Score : " + currentScore;
                        // dinoDie.Stop();
                    }
                    if(hit.transform.name == "dynamite5(Clone)"){
                        if (!dieSound.isPlaying)
                        {
                            dieSound.Play();
                            Debug.Log("sound on");
                        }
                        playAudio();
                        Destroy(hit.transform.gameObject);
                        float a = Random.Range(-5f, 5f);
                        float b = Random.Range(-5f, 5f);
                        Instantiate(explodeEffect, hit.transform.position, Quaternion.identity);
                        canShoot = false;
                        StartCoroutine(Explode());
                        Instantiate(dynamitePrefab, new Vector3(0f, 0f, 0f), Quaternion.identity);
                        currentScore = currentScore - 2;
                        textScore.text = "Score : " + currentScore; 
                        // dinoDie.Stop();
                    }
                }   
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

    IEnumerator StartSpawning()
    {

        yield return new WaitForSeconds(1);
            
            for (int i =0; i < Dinosaurs.Length; i++)
            {
                float a = Random.Range(-5f, 5f);
                float b = Random.Range(-5f, 5f);
                Instantiate(Dinosaurs[i], new Vector3(a, 0f, b), Quaternion.identity); //spawn each dinosaur at each position
                
                
                counter++;
                
            }
            
            
             for (int i =0; i < Dinosaurs.Length*2; i++) 
            {
                float c = Random.Range(-5f, 5f);
                float d = Random.Range(-5f, 5f);
                Instantiate(star, new Vector3(c, 0f, d), Quaternion.identity);
                float e = Random.Range(-5f, 5f);
                float f = Random.Range(-5f, 5f);
                Instantiate(dynamitePrefab, new Vector3(e, 0f, f), Quaternion.identity);
            }
        
        while(counter < 3){ //only spawn 3 dinosaurs
            StartCoroutine(StartSpawning());
        }
        
 
    }

    public void rerun()
    {

        StartCoroutine(StartSpawning());
    }

    IEnumerator Explode()
    {
        yield return new WaitForSeconds(3);
        canShoot = true;
    }
}
