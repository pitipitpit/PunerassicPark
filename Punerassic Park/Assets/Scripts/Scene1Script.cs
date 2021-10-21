using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scene1Script : MonoBehaviour
{
    [SerializeField] GameObject goodComplete;
    [SerializeField] GameObject failMission;
    [SerializeField] GameObject greatComplete;
    [SerializeField] GameObject perfectComplete;

    [SerializeField] GameObject replayButton;
    [SerializeField] GameObject NextGameButton;
    [SerializeField] GameObject ExitButton;

    [SerializeField] GameObject arCamera;
    [SerializeField] GameObject dinosaurPrefab;
    [SerializeField] AudioSource dieSound;
    [SerializeField] int currentScore = 0;
    [SerializeField] TMPro.TextMeshProUGUI textScore;

    [SerializeField] Image timerBar;
    [SerializeField] float maxTime = 5f;
    float timeLeft;

    void Start()
    {
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
                if(hit.transform.name == "trex(Clone)"){
                    if (!dieSound.isPlaying)
                    {
                        dieSound.Play();
                        Debug.Log("sound on");
                    }
                    //playAudio();
                    Destroy(hit.transform.gameObject);
                    float a = Random.Range(-5f, 5f);
                    float b = Random.Range(-5f, 5f);
                    Instantiate(dinosaurPrefab, new Vector3(a, 0f, b), Quaternion.identity);
                    currentScore = currentScore + 1;
                    textScore.text = "Score : " + currentScore;
                    
                }
            }   
        }   
    } 
    


}
