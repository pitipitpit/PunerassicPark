using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scene4Script : MonoBehaviour
{
    public GameObject goodComplete;
    public GameObject failMission;
    public GameObject greatComplete;
    public GameObject perfectComplete;

    public GameObject replayButton;
    public GameObject NextGameButton;
    public GameObject ExitButton;

    public GameObject arCamera;
    public GameObject trexPrefab;
    public GameObject longPrefab;
    public GameObject triPrefab;
    public GameObject starPrefab;
    public AudioSource dieSound;
    public int currentScore = 0;
    public TMPro.TextMeshProUGUI textScore;
    public bool dinoDie;

    public Image timerBar;
    public float maxTime = 5f;
    float timeLeft;
    public GameObject timesUpText;

    public GameObject[] Dinosaurs;
    public int counter;
    public GameObject star;

    void Start()
    {
        timesUpText.SetActive(false);
        // timerBar = GetComponent<Image>();
        timeLeft = maxTime;
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
        if (timeLeft > 0) {
            timeLeft -= Time.deltaTime;
            timerBar.fillAmount = timeLeft / maxTime;
            
        } else {
            timesUpText.SetActive(true);
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
        }
    }

    public void Shoot() {
        RaycastHit hit;
        if (timeLeft > 0){
            if(Physics.Raycast(arCamera.transform.position, arCamera.transform.forward, out hit)){
                if(hit.transform.name == "trex4(Clone)"){
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
                if(hit.transform.name == "tri4(Clone)"){
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
                if(hit.transform.name == "long4(Clone)"){
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
                if(hit.transform.name == "stars(Clone)"){
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
