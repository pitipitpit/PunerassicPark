using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartScript : MonoBehaviour
{

    float currentTime = 0f;
    float startingTime = 3f;

    [SerializeField] GameObject logo;
    [SerializeField] GameObject startButton;
    [SerializeField] GameObject howto;
    [SerializeField] GameObject level;
    
    [SerializeField] Text CountdownText;
    
    public string lvltoload;

    void Start()
    {
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        CountdownText.text = currentTime.ToString("0");

        if (currentTime <= 0){
            CountdownText.text = "GO!";
            Application.LoadLevel(lvltoload);
        }

    }

    public void hide() {
        logo.SetActive(false);
        startButton.SetActive(false);
        howto.SetActive(false);
        level.SetActive(false);
    }

}
