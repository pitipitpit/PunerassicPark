using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scene2Script : MonoBehaviour
{
    public GameObject goodComplete;
    public GameObject failMission;
    public GameObject greatComplete;
    public GameObject perfectComplete;

    public GameObject replayButton;
    public GameObject NextGameButton;
    public GameObject ExitButton;

    public GameObject arCamera;

    public AudioSource dieSound;
    public AudioSource glassSound;

    public int currentScore = 0;
    public TMPro.TextMeshProUGUI textScore;
    public bool dinoDie;

    public Image timerBar;
    public float maxTime = 45f;
    float timeLeft;

    public GameObject Dinosaurs;
    public GameObject Stars;

    public GameObject criteria;
    public GameObject OK;

    public bool running = false;
    public int levelIndex = 2;

    public void Run()
    {
        Time.timeScale = 1;
        running = true;
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

        criteria.SetActive(false);
        OK.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if(running){
        if (timeLeft > 0) {
            timeLeft -= Time.deltaTime;
            timerBar.fillAmount = timeLeft / maxTime;
            
        } else {
            Time.timeScale = 0;
            if (currentScore >= 30) {
                UpdateStar(3);
                perfectComplete.SetActive(true);
                replayButton.SetActive(true);
                NextGameButton.SetActive(true);
                ExitButton.SetActive(true);

            } else if (currentScore >= 20) {
                UpdateStar(2);
                greatComplete.SetActive(true);
                replayButton.SetActive(true);
                NextGameButton.SetActive(true);
                ExitButton.SetActive(true);

            } else if ( currentScore >= 10) {
                UpdateStar(1);
                goodComplete.SetActive(true);
                replayButton.SetActive(true);
                NextGameButton.SetActive(true);
                ExitButton.SetActive(true);

            } else if (currentScore < 10) {
                UpdateStar(0);
                failMission.SetActive(true);
                replayButton.SetActive(true);
                ExitButton.SetActive(true);
            }
        }
        }
        
    }

    public void Shoot() {
        RaycastHit hit;
        if (timeLeft > 0){
            
            if(Physics.Raycast(arCamera.transform.position, arCamera.transform.forward, out hit)){
                if(hit.transform.name == "trex(Clone)"){
                        Debug.Log("trex5 got hit");
                        if (!dieSound.isPlaying)
                            {
                                dieSound.Play();
                                Debug.Log("sound on");
                            }
                        playAudio();
                        hit.transform.gameObject.SetActive(false);
                        float a = Random.Range(-5f, 5f);
                        float b = Random.Range(-5f, 5f);
                        hit.transform.position = new Vector3(a, b, 0f);
                        hit.transform.gameObject.SetActive(true);
                        currentScore = currentScore + 1;
                        textScore.text = "Score : " + currentScore;
                        // dinoDie.Stop();
                    }

                 if(hit.transform.name == "stars(Clone)"){
                        Debug.Log("stars5 got hit");
                        if (!dieSound.isPlaying)
                            {
                                dieSound.Play();
                                Debug.Log("sound on");
                            }
                        playAudio();
                        hit.transform.gameObject.SetActive(false);
                        float a = Random.Range(-5f, 5f);
                        float b = Random.Range(-5f, 5f);
                        hit.transform.position = new Vector3(a, b, 0f);
                        hit.transform.gameObject.SetActive(true);

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
        
            for (int i = 0; i < 3; i++)
            {
                float a = Random.Range(-5f, 5f);
                float b = Random.Range(-5f, 5f);
                Instantiate(Dinosaurs, new Vector3(a, 0f, b), Quaternion.identity);    
            }
                        
            for (int i =0; i < 6; i++) 
            {
                float c = Random.Range(-10f, 10f);
                float d = Random.Range(-10f, 10f);
                Instantiate(Stars, new Vector3(c, 0f, d), Quaternion.identity);
            }
        
    }

    public void rerun()
    {

        StartCoroutine(StartSpawning());
    }


    private void UpdateStar(int _starsNum)
    {
        if (_starsNum > PlayerPrefs.GetInt("Lv" + levelIndex))
        {
            PlayerPrefs.SetInt("Lv" + levelIndex, _starsNum);
        }

    }

}
