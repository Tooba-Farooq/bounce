using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int totalRingsInLevel;

    [HideInInspector] public int lifeCount;
    public int levelNo;

    [SerializeField] TextMeshProUGUI lifeCountValue;

    
    private void Awake()
    {
        lifeCount = 3;
        Instance = this;
        LifeCollectionInformer.LifeCollected += IncrementLife;
        Ball.EnemyCollision += DecrementLife;
    }

    private void IncrementLife()
    {
        lifeCount++;
        lifeCountValue.text = $"X{lifeCount}";
    }

    private void DecrementLife()
    {
        lifeCount--;
        lifeCountValue.text = $"X{lifeCount}";
    }
    
    
}
