using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reseter : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ScoreManager.Instance.score = 0;
            SceneManager.LoadScene(0);
        }
        if (Input.GetButtonDown("Jump") && SceneManager.GetActiveScene().buildIndex == 1)
        {
            ScoreManager.Instance.score = 0;
            SceneManager.LoadScene(0);
        }
    }
}
