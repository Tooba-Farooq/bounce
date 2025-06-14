using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LevelCompletionInfo : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI levelCompleteText;
    [SerializeField] TextMeshProUGUI finalScoreText;
    [SerializeField] Image[] stars;
    [SerializeField] Sprite goldStarSprite;

    [SerializeField] WaitForSeconds delayBeforeGoldStar = new WaitForSeconds(0.50f);

    private int NoOfStars;
    private int previousEarnedStars;
    // previousEarnedStars = How many stars earned when player played this level earlier

    private void Start()
    {
        previousEarnedStars = CompletedLevelAndStarsEarned.LoadStarsForLevel(GameManager.Instance.levelNo);
        levelCompleteText.text = $"Level{GameManager.Instance.levelNo} Complete";
        finalScoreText.text = $"{ScoreIncrementer.score + GameManager.Instance.extraFinalScore}";
        StartCoroutine(GoldStarRoutine());
        
    }

    private IEnumerator GoldStarRoutine()
    {
        yield return delayBeforeGoldStar;
        stars[0].sprite = goldStarSprite;
        NoOfStars++;
 
        if (Ball.Instance.EnemyCollisionsNo <= 1)
        {
            yield return delayBeforeGoldStar;
            stars[1].sprite = goldStarSprite;
            NoOfStars++;

        }

        if (Ball.Instance.EnemyCollisionsNo == 0)
        {
            yield return delayBeforeGoldStar;
            stars[2].sprite = goldStarSprite;
            NoOfStars++;

        }

        if (NoOfStars > previousEarnedStars)
        {
            CompletedLevelAndStarsEarned.SaveStarsForLevel(GameManager.Instance.levelNo, NoOfStars);
        }
    } 
}
