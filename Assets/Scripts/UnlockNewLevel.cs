using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UnlockNewLevel : MonoBehaviour
{
    int completedLevelNumber = 1;

    [SerializeField] TextMeshProUGUI level2ButtonText;
    [SerializeField] Image star1;
    [SerializeField] Image star2;
    [SerializeField] Image star3;
    [SerializeField] Image lockImage;
    [SerializeField] Sprite unlockedLevelSprite;
    [SerializeField] Button level2Button;
   private void Awake()
   {
        Debug.Log(SavingCompletedLevel.LoadCompletedLevel());
        if (SavingCompletedLevel.LoadCompletedLevel() == completedLevelNumber)
        {
            level2Button.image.sprite = unlockedLevelSprite;
            level2Button.interactable = true;
            level2ButtonText.gameObject.SetActive(true);
            star1.gameObject.SetActive(true);
            star2.gameObject.SetActive(true);
            star3.gameObject.SetActive(true);
            lockImage.gameObject.SetActive(false);


        }
        
   }
    
}
