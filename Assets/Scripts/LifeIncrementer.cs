using TMPro;
using UnityEngine;
using System;

public class LifeIncrementer : MonoBehaviour
{
    public int lifeCount = 3;

    [SerializeField] TextMeshProUGUI lifeCountValue;
    public static Action LifeCollected;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        lifeCount++;
        LifeCollected?.Invoke();
        lifeCountValue.text = $"X{lifeCount}";
        Destroy(gameObject);
    }
}
