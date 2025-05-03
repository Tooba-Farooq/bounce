using UnityEngine;

public class CheckpointHandler : MonoBehaviour
{
    [SerializeField] Sprite arrow_sprite;

    private SpriteRenderer sr;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        sr.sprite = arrow_sprite;
        Ball.Instance.respawnPosition = transform.position;
    }
    
}
