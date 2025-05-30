using TMPro;
using UnityEngine;

public class DynamicScoreAndLevel : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI levelCompleteText;
    [SerializeField] TextMeshProUGUI finalScoreText;

    private void Awake()
    {
      
    }
    void Start()
    {
        levelCompleteText.text = $"LEVEL{GameManager.Instance.levelNo} COMPLETE";
        finalScoreText.text = $"{ScoreIncrementer.score}";
    }

   
}
