using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Respawn : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    { 
        if (collision.transform.CompareTag("Player"))
        {
            Initiate.Fade(SceneManager.GetActiveScene().name, Color.white, 0.5f);
        }
    }
}
