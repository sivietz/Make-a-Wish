using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseMenuWindow;

    private bool isGamePaused = false;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    void TogglePause()
    {
        pauseMenuWindow.SetActive(isGamePaused);
        Time.timeScale = isGamePaused ? 0f : 1f;
        isGamePaused = !isGamePaused;
    }

    public void Quit()
    {
        Initiate.Fade(SceneUtility.GetScenePathByBuildIndex(2), Color.black, 2);
        TogglePause();
    }
}
