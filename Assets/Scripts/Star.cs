using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    private bool isCollected = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isCollected)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                StarCounter.Instance.ChangeScore();
                Destroy(this.gameObject);
                isCollected = true;
            }
        }
    }
}
