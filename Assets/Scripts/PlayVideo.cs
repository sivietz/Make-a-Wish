using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class PlayVideo : MonoBehaviour
{
    private const int menuSceneIndex = 2;

    [SerializeField]
    private VideoPlayer videoPlayer;

    private void Start()
    {
        videoPlayer.loopPointReached += FadeToMenu;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Initiate.Fade(SceneUtility.GetScenePathByBuildIndex(menuSceneIndex), Color.white, 2);
        }
    }

    private void FadeToMenu(VideoPlayer video)
    {
        Initiate.Fade(SceneUtility.GetScenePathByBuildIndex(menuSceneIndex), Color.white, 2);
    }
}
