using System;
using UnityEngine;
using UnityEngine.UI;

public class UIRingDisabler : MonoBehaviour
{
    [SerializeField] private Image[] UIRingImages;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        RingHandler.RingCollected += DisableUIRing;
    }

    private void DisableUIRing()
    {
        if (RingHandler.collectedRingsCount <= UIRingImages.Length && UIRingImages[RingHandler.collectedRingsCount-1] != null)
        {
            Destroy(UIRingImages[RingHandler.collectedRingsCount-1].gameObject);
            UIRingImages[RingHandler.collectedRingsCount-1] = null; 
        }
    }

}
