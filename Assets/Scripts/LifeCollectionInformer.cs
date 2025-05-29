using TMPro;
using UnityEngine;
using System;

public class LifeCollectionInformer : MonoBehaviour
{
    
    public static Action LifeCollected;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        LifeCollected?.Invoke();    
        Destroy(gameObject);
    }
}
