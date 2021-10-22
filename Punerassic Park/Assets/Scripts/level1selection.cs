using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class level1selection : MonoBehaviour
{

    public GameObject[] stars;
    public Sprite starSprite;



    // Start is called before the first frame update
    void Update()
    {
        UpdateLevelImage();
    }



 
    private void UpdateLevelImage()
    {
        for (int i = 0; i < PlayerPrefs.GetInt("Lv" + gameObject.name); i++)
        {
            stars[i].GetComponent<Image>().sprite = starSprite ;
        }
     }

   

    public void PressSelection(string level)
    { 
        SceneManager.LoadScene(level, LoadSceneMode.Single);
        
    }



}

