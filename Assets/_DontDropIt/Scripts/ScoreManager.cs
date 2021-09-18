using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TMPro.TMP_Text scoreText;
    public int score = 100;

    // Singleton instance.
    public static ScoreManager Instance = null;

    // Initialize the singleton instance.
    private void Awake()
    {
        // If there is not already an instance of ScoreManager, set it to this.
        if (Instance == null)
        {
            Instance = this;
        }
        //If an instance already exists, destroy whatever this object is to enforce the singleton.
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        //Set ScoreManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (scoreText == null)
        {
            scoreText = FindObjectOfType<TMPro.TMP_Text>();
        }
        if (scoreText != null)
        {
            scoreText.text = score.ToString();
        }
    }
}
