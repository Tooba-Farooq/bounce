using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GateOpener : MonoBehaviour
{
    private Animator anim;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        anim.enabled = false;
        RingHandler.RingCollected += OpenGate;
    }

    private void OpenGate()
    {
        Debug.Log(RingHandler.collectedRingsCount);

        if (RingHandler.collectedRingsCount == RingHandler.totalRingsInLevel)
        {
            anim.enabled = true;
            gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        }
    }

    private void OnTriggerEnter2D()
    {
        SceneManager.LoadScene("Level2");
    }


}
