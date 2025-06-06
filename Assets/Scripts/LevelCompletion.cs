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

    private Vector2 openGateColliderOffset = new Vector2(0.04248928f, 0f);
    private Vector2 openGateColliderSize = new Vector2(0.3627881f, 2f);

    private BoxCollider2D bc;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        anim.enabled = false;
        RingHandler.RingCollected += OpenGate;
        bc = GetComponent<BoxCollider2D>();

        closeGateColliderSize = bc.size;
        closeGateColliderOffset = bc.offset;
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
            bc.size = openGateColliderSize;
            bc.offset = openGateColliderOffset;

            CompletedLevelAndStarsEarned.SaveCompletedLevel(GameManager.Instance.levelNo, 1); // 1 for true since playerprefs cant save boolean value
        }
    }

}
