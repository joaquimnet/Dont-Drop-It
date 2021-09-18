using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillZone : MonoBehaviour
{
    public AudioClip gameOverSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            ScoreManager.Instance.score += 200;
        }
        if (other.CompareTag("Ball") || other.CompareTag("Player"))
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        SceneManager.LoadScene(1);
        SoundManager.Instance.Play(gameOverSound);
    }
}
