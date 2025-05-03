using UnityEngine;
using System;

public class RingHandler : MonoBehaviour
{
    public static int totalRingsInLevel {get; private set;}
    public static int collectedRingsCount {  get; private set; }

    [SerializeField] Sprite greyRingSprite;

    private SpriteRenderer sr;
    private CapsuleCollider2D cc;

    public static Action RingCollected;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        cc = GetComponent<CapsuleCollider2D>();
        totalRingsInLevel = 6;
        collectedRingsCount = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collectedRingsCount++;
        RingCollected?.Invoke();
        sr.sprite = greyRingSprite;
        cc.enabled = false;

    }
}
