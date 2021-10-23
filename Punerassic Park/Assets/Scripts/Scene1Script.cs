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
    [SerializeField] GameObject criteria;
    [SerializeField] GameObject ok;

    [SerializeField] GameObject replayButton;
    [SerializeField] GameObject NextGameButton;
    [SerializeField] GameObject ExitButton;

    [SerializeField] GameObject arCamera;
    [SerializeField] GameObject Dinosaurs;
    [SerializeField] AudioSource dieSound;
    [SerializeField] int currentScore = 0;
    [SerializeField] TMPro.TextMeshProUGUI textScore;

    [SerializeField] Image timerBar;
    [SerializeField] float maxTime = 5f;
    float timeLeft;
    private bool canRun = false;
    public int levelIndex = 1;

    // Update is called once per frame
    void Update()
    {
        if (canRun)
        {
            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
                timerBar.fillAmount = timeLeft / maxTime;

            }
            else
            {
                Time.timeScale = 0;
                if (currentScore >= 30)
                {
                    UpdateStar(3);
                    perfectComplete.SetActive(true);
                    replayButton.SetActive(true);
                    NextGameButton.SetActive(true);
                    ExitButton.SetActive(true);

                }
                else if (currentScore >= 20)
                {
                    UpdateStar(2);
                    greatComplete.SetActive(true);
                    replayButton.SetActive(true);
                    NextGameButton.SetActive(true);
                    ExitButton.SetActive(true);

                }
                else if (currentScore >= 10)
                {
                    UpdateStar(1);
                    goodComplete.SetActive(true);
                    replayButton.SetActive(true);
                    NextGameButton.SetActive(true);
                    ExitButton.SetActive(true);

                }
                else if (currentScore < 10)
                {
                    UpdateStar(0);
                    failMission.SetActive(true);
                    replayButton.SetActive(true);
                    ExitButton.SetActive(true);
                }

                canRun = false;
            }

        }
        
    }

    public void Run()
    {
        Time.timeScale = 1;
        canRun = true;
        // timerBar = GetComponent<Image>();
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
                        hit.transform.gameObject.SetActive(false);
                        float a = Random.Range(-5f, 5f);
                        float b = Random.Range(-5f, 5f);
                        hit.transform.position = new Vector3(a, b, 0f);
                        hit.transform.gameObject.SetActive(true);
                        currentScore = currentScore + 1;
                        textScore.text = "Score : " + currentScore;
                        // dinoDie.Stop();
                    
                }
            }   
        }   
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
                        
    }

    private void UpdateStar(int _starsNum)
    {
        if(_starsNum > PlayerPrefs.GetInt("Lv" + levelIndex))
        {
            PlayerPrefs.SetInt("Lv" + levelIndex, _starsNum);
        }

    }
    


}
