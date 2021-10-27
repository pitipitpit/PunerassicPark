using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class StartScript : MonoBehaviour
{

    [SerializeField] GameObject logo;
    [SerializeField] GameObject startButton;
    [SerializeField] GameObject howto;
    [SerializeField] GameObject level;
    [SerializeField] GameObject box;



    [SerializeField] VideoPlayer video;
    [SerializeField] AudioSource run;

    public void hide() {
        video.Play();
        run.Play();
        StartCoroutine(PlayVid());
        box.SetActive(false);
        logo.SetActive(false);
        startButton.SetActive(false);
        howto.SetActive(false);
        level.SetActive(false);
    }


    IEnumerator PlayVid()
    {
        
        yield return new WaitForSeconds(3.65F);

        SceneManager.LoadScene("Scene 1");


    }

}
