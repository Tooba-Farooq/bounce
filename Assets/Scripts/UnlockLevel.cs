using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UnlockLevel : MonoBehaviour
{
    [Header("Level Settings")]
    [SerializeField] private int levelNumber;

    [Header("UI References")]
    [SerializeField] private Button levelButton;
    [SerializeField] private TextMeshProUGUI levelButtonText;
    [SerializeField] private Image lockImage;
    [SerializeField] private Image[] greyStars;

    [Header("Sprites")]
    [SerializeField] private Sprite unlockedLevelSprite;

    int isPreviousLevelCompleted;

    private const int MAX_STARS = 3; 


   private void Awake()
   {
        isPreviousLevelCompleted = CompletedLevelAndStarsEarned.LoadCompletedLevel(levelNumber-1);
        if (isPreviousLevelCompleted == 1) // 1 means true
        {
            UnlockThisLevel();
        }
        
   }

    private void UnlockThisLevel()
    {  
        levelButton.interactable = true;
        levelButton.image.sprite = unlockedLevelSprite;
        lockImage.gameObject.SetActive(false);
        levelButtonText.gameObject.SetActive(true);

        for (int i = 0; i < MAX_STARS; i++)
        {
            greyStars[i].gameObject.SetActive(true);
        }
        
    }

}





