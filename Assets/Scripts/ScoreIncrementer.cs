using System;
using TMPro;
using UnityEngine;

public class ScoreIncrementer : MonoBehaviour
{
    private TextMeshProUGUI TMP;
    public static int score;


    private void IncrementScore1000()
    {
        score += 1000;
        Debug.Log(score);
        TMP.text = score.ToString("D7");
    }

    void Awake()
    {

        RingHandler.RingCollected += IncrementScore500;
        LifeCollectionInformer.LifeCollected += IncrementScore1000;
        CheckpointHandler.CheckpointCollected += IncrementScore500;

        TMP = GetComponent<TextMeshProUGUI>();
        score = 0;
        Debug.Log(score);
    }

    void OnDestroy()
    {

        RingHandler.RingCollected -= IncrementScore500;
        LifeCollectionInformer.LifeCollected -= IncrementScore1000;
        CheckpointHandler.CheckpointCollected -= IncrementScore500;

        TMP = GetComponent<TextMeshProUGUI>();
        score = 0;
        Debug.Log(score);
    }

    private void IncrementScore500()
    {
        score += 500;
        Debug.Log(score);
        TMP.text = score.ToString("D7");    
    }

    
}
