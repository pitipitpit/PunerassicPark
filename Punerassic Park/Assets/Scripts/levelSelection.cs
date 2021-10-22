using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class levelSelection : MonoBehaviour
{

    [SerializeField] private bool unlocked;
    public GameObject unlockedImage;
    public GameObject[] stars ;
    public Sprite starSprite;

    

    // Start is called before the first frame update
    void Update()
    {
        UpdateLevelImage();
        UpdateLevelStatus();
    }

    //// Update is called once per frame
    //private void Update()
    //{
        
    //}



    private void UpdateLevelStatus()
    {
        int prevLevelNum = int.Parse(gameObject.name) - 1;
        if(PlayerPrefs.GetInt("Lv" + prevLevelNum) > 0)
        {
            unlocked = true;
        }

    }

    private void UpdateLevelImage()
    {
        if (!unlocked) //if unlocked is false this level is locked --> enter this condition
        {
            unlockedImage.SetActive(true);
            for (int i = 0; i < stars.Length; i++)
            {
                stars[i].SetActive(false);
            }
        }
        else // if unlocked
        {
            unlockedImage.SetActive(false);
            for (int i = 0; i < stars.Length; i++)
            {
                stars[i].SetActive(true);
            }
            for (int i = 0; i < PlayerPrefs.GetInt("Lv" + gameObject.name); i++)
            {
                stars[i].GetComponent<Image>().sprite = starSprite;
            }
        }

    }

    public void PressSelection(string level)
    {
        if (unlocked)
        {

            SceneManager.LoadScene(level, LoadSceneMode.Single);
        }

    }



}

