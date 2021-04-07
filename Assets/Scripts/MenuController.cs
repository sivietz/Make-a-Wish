using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEditor;

public class MenuController : MonoBehaviour
{
    public void PlayGame()
    {
        Initiate.Fade(SceneUtility.GetScenePathByBuildIndex(2), Color.black, 2);
    }

    public void ResetProgress()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
