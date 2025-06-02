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
        levelCompleteText.text = $"Level{GameManager.Instance.levelNo} Complete";
        finalScoreText.text = $"{ScoreIncrementer.score}";
    }

   
}
