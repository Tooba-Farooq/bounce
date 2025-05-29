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
        RingHandler.RingCollected += IncrementScore500;
        LifeCollectionInformer.LifeCollected += IncrementScore1000;
        CheckpointHandler.CheckpointCollected += IncrementScore500;
    }

    private void IncrementScore1000()
    {
        score += 1000;
        TMP.text = score.ToString("D7");
    }

    void Awake()
    {
        TMP = GetComponent<TextMeshProUGUI>();
    }

    private void IncrementScore500()
    {
        score += 500;
        TMP.text = score.ToString("D7");    
    }

    
}
