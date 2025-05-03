using System;
using TMPro;
using UnityEngine;

public class ScoreIncrementer : MonoBehaviour
{
    private TextMeshProUGUI TMP;
    private int score;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        RingHandler.OnRingCollected += IncrementScore;
    }

    void Awake()
    {
        TMP = GetComponent<TextMeshProUGUI>();
    }

    private void IncrementScore()
    {
        score += 500;
        TMP.text = score.ToString("D7");    
    }

    
}
