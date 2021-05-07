using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cheat : MonoBehaviour
{
    private BoxCollider _collider;
    
    void Start()
    {
        _collider = GetComponent<BoxCollider>();
    }

    void Update()
    {
        LoadLevel();
        DisableCollision();
    }

    private void DisableCollision()
    {
        if (Input.GetKey(KeyCode.C))
        {
            _collider.enabled = false;
        }

        if (Input.GetKey(KeyCode.E))
        {
            _collider.enabled = true;
        }
    }

    private static void LoadLevel()
    {
        if (Input.GetKey(KeyCode.L))
        {
            int currentIndex = SceneManager.GetActiveScene().buildIndex;
            int nextScene = currentIndex + 1;
            if (nextScene == SceneManager.sceneCountInBuildSettings)
            {
                nextScene = 0;
            }

            SceneManager.LoadScene(nextScene);
        }
    }
}
