using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreIncreaser : MonoBehaviour
{
    public int amount = 10;

    private void Start()
    {
        InvokeRepeating("IncreaseScore", 0f, 0.3f);
    }

    public void IncreaseScore()
    {
        ScoreManager.Instance.score += amount;
    }
}
