using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StarCounter : MonoBehaviour
{
    public static StarCounter Instance;

    [SerializeField]
    private TextMeshProUGUI scoreDisplay;

    private int starCount;
    private int maxStarsCount = 20;

    public int StarCount => starCount;
    public int MaxStarsCount => maxStarsCount;

    void Start()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    public void ChangeScore()
    {
        starCount++;
        scoreDisplay.text = starCount.ToString();
    }
}
