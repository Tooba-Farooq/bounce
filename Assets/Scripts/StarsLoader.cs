using UnityEngine;
using UnityEngine.UI;

public class StarsLoader : MonoBehaviour
{
    [SerializeField] private int levelNumber;
    [SerializeField] Image[] greyStars;
    [SerializeField] Sprite goldStarSprite;

    int isThisLevelCompleted;
    private int starsEarned;

    private void Awake()
    {
        isThisLevelCompleted = CompletedLevelAndStarsEarned.LoadCompletedLevel(levelNumber);
        if (isThisLevelCompleted == 1)
        {
            LoadEarnedStars();
        }
    }

    private void LoadEarnedStars()
    {
        starsEarned = CompletedLevelAndStarsEarned.LoadStarsForLevel(levelNumber);
        for (int i = 0; i < starsEarned; i++)
        {
            greyStars[i].sprite = goldStarSprite;
        }
    }

}
