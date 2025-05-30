using UnityEngine;

public class SpiderMover : MonoBehaviour
{
    private float direction = 1;
    private const int GROUND_LAYER_INDEX = 3;

    [SerializeField] float speed;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate()
    {
        rb.linearVelocityY = direction * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == GROUND_LAYER_INDEX)
        {
            direction *= -1;
        }
    }
}
