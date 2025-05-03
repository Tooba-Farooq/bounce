using UnityEngine;
using System;

public class RingHandler : MonoBehaviour
{
    [SerializeField] Sprite greyRingSprite;

    private SpriteRenderer sr;
    private CapsuleCollider2D cc;

    public static Action OnRingCollected;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        cc = GetComponent<CapsuleCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnRingCollected?.Invoke();
        sr.sprite = greyRingSprite;
        cc.enabled = false;

    }
}
