using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DynamicScoreLevelAndStars : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI levelCompleteText;
    [SerializeField] TextMeshProUGUI finalScoreText;
    [SerializeField] Image star1;
    [SerializeField] Image star2;
    [SerializeField] Image star3;
    [SerializeField] Sprite goldStarSprite;

    [SerializeField] WaitForSeconds delayBeforeGoldStar = new WaitForSeconds(0.40f);

    private void Awake()
    {
      
    }
    void Start()
    {
        levelCompleteText.text = $"Level{GameManager.Instance.levelNo} Complete";
        finalScoreText.text = $"{ScoreIncrementer.score+GameManager.Instance.extraFinalScore}";
        StartCoroutine(GoldStarRoutine());
    }

    private IEnumerator GoldStarRoutine()
    {
        yield return delayBeforeGoldStar;
        star1.sprite = goldStarSprite;
        //if (GameManager.Instance.levelNo == 1) 
        //{
        //    SavingCompletedLevel.SaveNoOfStars1(1);
        //}
        //else
        //{
        //    SavingCompletedLevel.SaveNoOfStars2(1);
        //}
        

        if (Ball.Instance.EnemyCollisionsNo <= 1)
        {
            yield return delayBeforeGoldStar;
            star2.sprite = goldStarSprite;
            //if (GameManager.Instance.levelNo == 1)
            //{
            //    SavingCompletedLevel.SaveNoOfStars1(2);
            //}
            //else
            //{
            //    SavingCompletedLevel.SaveNoOfStars2(2);
            //}
        }

        if (Ball.Instance.EnemyCollisionsNo == 0)
        {
            yield return delayBeforeGoldStar;
            star3.sprite = goldStarSprite;
            //if (GameManager.Instance.levelNo == 1)
            //{
            //    SavingCompletedLevel.SaveNoOfStars1(3);
            //}
            //else
            //{
            //    SavingCompletedLevel.SaveNoOfStars2(3);
            //}
        }

    }

   
}
