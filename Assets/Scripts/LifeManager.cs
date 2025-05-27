using TMPro;
using UnityEngine;
using System;

public class LifeManager : MonoBehaviour
{
    public static int lifeCount { get; private set; }

    [SerializeField] TextMeshProUGUI lifeCountValue;
    public static Action LifeCollected;

    private void Awake()
    {
        lifeCount = 3;
        //Ball.EnemyCollision += DecrementLife;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        lifeCount++;
        LifeCollected?.Invoke();
        lifeCountValue.text = $"X{lifeCount}";
        Destroy(gameObject);
    }

    //private void DecrementLife()
    //{
    //    lifeCount--;
    //    lifeCountValue.text = $"X{lifeCount}";
    //}
}
