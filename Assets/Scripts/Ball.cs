using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using System;

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
    [SerializeField] Sprite smallBallSprite;
    [SerializeField] Sprite bigBallSprite;

    [HideInInspector] public Vector3 respawnPosition;
    [HideInInspector] public Sprite respawnBallSprite;
    [HideInInspector] public Vector2 respawnColliderOffset;
    [HideInInspector] public float respawnColliderRadius;

    [SerializeField] WaitForSeconds delayBeforeRespawn = new WaitForSeconds(0.75f);

    private bool isJumpPressed;
    private bool isOnGround;
    private bool isHoldingKey = false;
    private bool isBallBig;

    private float horizontalInput;
    private float currentSpeedX = 0f;

    private Vector2 smallColliderOffset;
    private float smallColliderRadius;

    private Vector2 bigColliderOffset = new Vector2(-0.005817673f, 0.182369f);
    private float bigColliderRadius = 0.6755558f;

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private CircleCollider2D cc;


    public static Action EnemyCollision;

    public static Ball Instance { get; private set; }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        cc = GetComponent<CircleCollider2D>();

        respawnPosition = transform.position;
        respawnColliderOffset = cc.offset;
        respawnColliderRadius = cc.radius;
        respawnBallSprite = sr.sprite;

        smallColliderOffset = cc.offset;
        smallColliderRadius = cc.radius;
    }

    private void Start()
    {
        Instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, maxRayDistance, mask);
        isOnGround = hit.collider != null;

        horizontalInput = Input.GetAxisRaw("Horizontal");
        isJumpPressed = Input.GetKeyDown(KeyCode.UpArrow);

        if (isJumpPressed && isOnGround)
        {
            //rb.linearVelocityY = jumpForce;
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    private void FixedUpdate()
    {
        if (rb.bodyType == RigidbodyType2D.Static)
            return; 

        Move(horizontalInput, maxSpeed, acceleration);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            EnemyCollision?.Invoke();
            if (GameManager.Instance.lifeCount == 0)
            {
                return;
            }
            StartCoroutine(RespawnRoutine());
        }

        if (collision.gameObject.tag == "Pump")
        {
            isBallBig = true;
            sr.sprite = bigBallSprite;
            cc.radius = bigColliderRadius;
            cc.offset = bigColliderOffset;
        }

        if (collision.gameObject.tag == "Vaccum")
        {
            isBallBig = false;
            sr.sprite = smallBallSprite;
            cc.radius = smallColliderRadius;
            cc.offset = smallColliderOffset;
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


    private IEnumerator RespawnRoutine()
    {
        cc.enabled = false;
        transform.rotation = Quaternion.Euler(0, 0, 0);
        sr.sprite = poppedBallSprite;
        rb.bodyType = RigidbodyType2D.Static;
      

        yield return delayBeforeRespawn;

        transform.position = respawnPosition;
        rb.bodyType = RigidbodyType2D.Dynamic;
        cc.enabled = true;
        sr.sprite = respawnBallSprite;
        cc.radius = respawnColliderRadius;
        cc.offset = respawnColliderOffset;
    }
}
