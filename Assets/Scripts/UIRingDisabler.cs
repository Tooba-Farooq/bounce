using System;
using UnityEngine;
using UnityEngine.UI;

public class UIRingDisabler : MonoBehaviour
{
    private int collectedRingsCount;
    [SerializeField] private Image[] UIRingImages;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        RingHandler.OnRingCollected += DisableUIRing;
    }

    private void DisableUIRing()
    {
        collectedRingsCount++;
        if (collectedRingsCount <= UIRingImages.Length && UIRingImages[collectedRingsCount-1] != null)
        {
            Destroy(UIRingImages[collectedRingsCount-1].gameObject);
            UIRingImages[collectedRingsCount-1] = null; 
        }
    }

}
