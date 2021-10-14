using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartScript : MonoBehaviour
{

    float currentTime = 0f;
    float startingTime = 3f;

    [SerializeField] GameObject GameName;
    [SerializeField] GameObject startButton;
    
    [SerializeField] Text CountdownText;
    

    void Start()
    {
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        CountdownText.text = currentTime.ToString("0");

        if (currentTime <=0){
            CountdownText.text = "GO!";
        }

    }

    public void hide() {
        GameName.SetActive(false);
        startButton.SetActive(false);
    }

}
