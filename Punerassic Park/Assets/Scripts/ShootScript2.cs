using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootScript2 : MonoBehaviour
{
    public GameObject goodComplete;
    public GameObject failMission;
    public GameObject greatComplete;
    public GameObject perfectComplete;

    public GameObject replayButton;
    public GameObject NextGameButton;
    public GameObject ExitButton;

    public GameObject arCamera;

    public GameObject dinosaurPrefab;
    public GameObject starPrefab;

    public AudioSource dieSound;

    public int currentScore = 0;
    public TMPro.TextMeshProUGUI textScore;
    public bool dinoDie;

    public Image timerBar;
    public float maxTime = 45f;
    float timeLeft;
    public GameObject timesUpText;

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
                if(hit.transform.name == "trex2(Clone)"){
                    Debug.Log("hit");
                    // if (!dieSound.isPlaying)
                    //     {
                    //         dieSound.Play();
                    //         Debug.Log("sound on");
                    //     }
                    // playAudio();
                    Destroy(hit.transform.gameObject);
                    float a = Random.Range(-5f, 5f);
                    float b = Random.Range(-5f, 5f);
                    Instantiate(dinosaurPrefab, new Vector3(a, 0f, b), Quaternion.identity);
                    currentScore = currentScore + 1;
                    textScore.text = "Score : " + currentScore;
                    // dinoDie.Stop();
                }

                if(hit.transform.name == "stars(Clone)"){
                    Debug.Log("wowowowowowowoww");
                    Destroy(hit.transform.gameObject);
                    float a = Random.Range(-5f, 5f);
                    float b = Random.Range(-5f, 5f);
                    Instantiate(starPrefab, new Vector3(a, 0f, b), Quaternion.identity);
                    currentScore = currentScore - 1;
                    if(currentScore < 0){
                        currentScore = 0;
                    }
                    textScore.text = "Score : " + currentScore;
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
    
    


}