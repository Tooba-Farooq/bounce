using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompletion : MonoBehaviour
{
    private Animator anim;

    [SerializeField] Canvas gameFinishCanvas;

    private Vector2 closeGateColliderOffset;
    private Vector2 closeGateColliderSize;

    private Vector2 openGateColliderOffset = new Vector2(-0.03104189f, 0f);
    private Vector2 openGateColliderSize = new Vector2(0.9755434f, 2f);

    private BoxCollider2D collider;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        anim.enabled = false;
        RingHandler.RingCollected += OpenGate;
        collider = GetComponent<BoxCollider2D>();

        closeGateColliderSize = collider.size;
        closeGateColliderOffset = collider.offset;
}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameFinishCanvas.gameObject.SetActive(true);
        Ball.Instance.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
    }

    private void OnDestroy()
    {
        RingHandler.RingCollected -= OpenGate;
    }

    private void OpenGate()
    {
        if (RingHandler.collectedRingsCount == GameManager.Instance.totalRingsInLevel)
        {
            anim.enabled = true;

            gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
            collider.size = openGateColliderSize;
            collider.offset = openGateColliderOffset;

            SavingCompletedLevel.SaveCompletedLevel(GameManager.Instance.levelNo);
        }
    }

}
