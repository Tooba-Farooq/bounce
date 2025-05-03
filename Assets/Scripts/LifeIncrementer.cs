using TMPro;
using UnityEngine;

public class LifeIncrementer : MonoBehaviour
{
    [SerializeField] int lifeCount = 3;

    [SerializeField] TextMeshProUGUI lifeCountValue;
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        lifeCount++;
        lifeCountValue.text = $"X{lifeCount}";
        Destroy(gameObject);
    }
}
