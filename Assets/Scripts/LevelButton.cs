using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelButton : MonoBehaviour
{
    [SerializeField]
    private Button button;
    [SerializeField]
    private Scene scene;

    public Button Button => button;
    public Scene Scene => scene;

    private void OnEnable()
    {
        SetButtonState();
    }

    public void SetButtonState()
    {
        if (PlayerPrefs.GetInt($"{scene} unlocked") == 1)
        {
            button.interactable = true;
        }
    }

    public void OnButtonClick()
    {
        Initiate.Fade(SceneUtility.GetScenePathByBuildIndex((int)scene), Color.black, 2);
    }
}
