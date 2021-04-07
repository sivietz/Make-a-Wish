using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    private const int maxStarCount = 20;
    [SerializeField]
    private TextMeshProUGUI scoreDisplay;

    void Start()
    {
        scoreDisplay.text = $"{PlayerPrefs.GetInt(scoreDisplay.name)}/{maxStarCount}";
    }
}
