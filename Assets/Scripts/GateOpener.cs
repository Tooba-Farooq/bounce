using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GateOpener : MonoBehaviour
{
    private Animator anim;
    [SerializeField] string leveltoLoad;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        anim.enabled = false;
        RingHandler.RingCollected += OpenGate;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene(leveltoLoad);
    }

    private void OnDestroy()
    {
        RingHandler.RingCollected -= OpenGate;
    }

    private void OpenGate()
    {
        Debug.Log(RingHandler.collectedRingsCount);
        Debug.Log(RingHandler.totalRingsInLevel);

        if (RingHandler.collectedRingsCount == RingHandler.totalRingsInLevel)
        {
            anim.enabled = true;
            gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        }
    }
}
