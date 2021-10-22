using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class countStars : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI stars;
    // Start is called before the first frame update
    void Start()
    {
        UpdateStarsUI();
    }


    private void UpdateStarsUI()
    {
        int sum = 0;
        for(int i=1; i<=5; i++)
        {
            sum += PlayerPrefs.GetInt("Lv" + i.ToString());
        }

        stars.text = sum + "/" + 15;
    }
}
