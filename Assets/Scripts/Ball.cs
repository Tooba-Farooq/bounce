using System.Collections;
using JetBrains.Annotations;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Ball : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float maxSpeed = 5f;
    [SerializeField] float jumpForce = 7f;
    [SerializeField] float acceleration;
    [SerializeField] float maxSpeedPercent;

    [Header("Ground detection")]
    [SerializeField] float maxRayDistance = 1f;
    [SerializeField] LayerMask mask;

    [Header("Ball Sprites")]
    [SerializeField] Sprite poppedBallSprite;
    [SerializeField] Sprite normalBallSprite;

    [SerializeField] WaitForSeconds delayBeforeRespawn = new WaitForSeconds(0.75f);

    private bool isJumpPressed;
    private bool isOnGround;
    private bool isHoldingKey = false;

    private float horizontalInput;
    private float currentSpeedX = 0f;

    private Rigidbody2D rb;
    private SpriteRenderer sr;

    public static Ball Instance { get; private set; }
    [HideInInspector] public Vector3 respawnPosition;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        respawnPosition = transform.position;
    }

    private void Start()
    {
        Instance = this;
    }

    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, maxRayDistance, mask);
        isOnGround = hit.collider != null;
        Debug.DrawRay(transform.position, Vector2.down, Color.yellow);

        horizontalInput = Input.GetAxisRaw("Horizontal");
        isJumpPressed = Input.GetKeyDown(KeyCode.UpArrow);

        Debug.Log(isOnGround);
        if (isJumpPressed && isOnGround)
        {
            //rb.linearVelocityY = jumpForce;
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    private void FixedUpdate()
    { 
        Move(horizontalInput, maxSpeed, acceleration);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            StartCoroutine(RespawnRoutine());
        }

    }

    public void Move(float direction, float maxSpeed, float acceleration)
    {
        // No input: stop immediately
        if (direction == 0)
        {
            currentSpeedX = 0f;
            rb.linearVelocityX = 0;
            isHoldingKey = false;
        }
        else
        {
            if (!isHoldingKey)
            {
                // First key press: apply burst
                currentSpeedX = direction * (maxSpeed * 0.2f); // 40% of max speed as instant burst
                isHoldingKey = true;
            }

            // Gradually move towards max speed
            currentSpeedX = Mathf.MoveTowards(currentSpeedX, direction * maxSpeed, acceleration * Time.fixedDeltaTime);
            rb.linearVelocityX = currentSpeedX;
        }
    }

    /*public void Move(float direction, float speed, float acceleration)
    {
            rb.linearVelocityX = horizontalInput * speed;
        }
    }*/

    private IEnumerator RespawnRoutine()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
        sr.sprite = poppedBallSprite;
        rb.bodyType = RigidbodyType2D.Static;

        yield return delayBeforeRespawn;

        transform.position = respawnPosition;
        rb.bodyType = RigidbodyType2D.Dynamic;
        sr.sprite = normalBallSprite;
    }
}
