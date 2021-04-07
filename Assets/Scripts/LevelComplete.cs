using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    private const int menuSceneIndex = 2;
    private const int outroSceneIndex = 7;

    private int currentLevelSceneIndex;
    private string nextLevelUnlockedKey;
    private string currentLevelScoreKey;

    [SerializeField]
    Scene scene;
    [SerializeField]
    private bool isFinalLevel = false;

    void Start()
    {
        nextLevelUnlockedKey = $"{(Scene)(currentLevelSceneIndex + 1)} unlocked";
        currentLevelScoreKey = $"{scene} score";
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerPrefs.SetInt(nextLevelUnlockedKey, 1);
            Initiate.Fade(SceneUtility.GetScenePathByBuildIndex((int)scene + 1), Color.black, 2);

            if (StarCounter.Instance.StarCount > PlayerPrefs.GetInt(currentLevelScoreKey))
            {
                PlayerPrefs.SetInt(currentLevelScoreKey, StarCounter.Instance.StarCount);
            }
        }

        if(isFinalLevel)
        {
            if (HasCollectedAllPoints())
            {
                Initiate.Fade(SceneUtility.GetScenePathByBuildIndex(outroSceneIndex), Color.black, 2);
            }
            else
            {
                Initiate.Fade(SceneUtility.GetScenePathByBuildIndex(menuSceneIndex), Color.black, 2);
            }
        }
    }

    private bool HasCollectedAllPoints()
    {
        for (int i = 1; i <= (int)scene; i++)
        {
            if (PlayerPrefs.GetInt($"Level{i} score") != StarCounter.Instance.MaxStarsCount)
            {
                return false;
            }
        }
        return true;
    }
}
