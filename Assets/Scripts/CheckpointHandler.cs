using System;
using UnityEngine;

public class CheckpointHandler : MonoBehaviour
{
    [SerializeField] Sprite arrow_sprite;

    private SpriteRenderer sr;
    private CircleCollider2D cc;

    public static Action CheckpointCollected;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        cc = GetComponent<CircleCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CheckpointCollected?.Invoke();
        sr.sprite = arrow_sprite;

        Ball.Instance.respawnPosition = transform.position;
        Ball.Instance.respawnBallSprite = Ball.Instance.GetComponent<SpriteRenderer>().sprite;
        Ball.Instance.respawnColliderRadius = Ball.Instance.GetComponent<CircleCollider2D>().radius;
        Ball.Instance.respawnColliderOffset = Ball.Instance.GetComponent <CircleCollider2D>().offset;

        cc.enabled = false;
    }
    
}
