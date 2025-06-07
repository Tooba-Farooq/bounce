using DG.Tweening;
using UnityEngine;

public class Bouncer : MonoBehaviour
{
    [SerializeField] float initialBounceHeight = 2f;
    [SerializeField] float bounceDuration = 0.3f;

    [SerializeField] float fallDistance = 5f;
    [SerializeField] float fallDuration = 0.6f;

    private Vector3 originalPosition;

    private void Start()
    {
        originalPosition = transform.position;

        transform.position += Vector3.up * fallDistance;

        transform.DOMoveY(originalPosition.y, fallDuration)
            .SetEase(Ease.InQuad)
            .OnComplete(PlayBounce); 
    }

    void PlayBounce()
    {
        Sequence bounceSequence = DOTween.Sequence();

        float height = initialBounceHeight;
        float dampingFactor = 0.5f; 

        for (int i = 0; i < 4; i++)
        {
            bounceSequence.Append(transform.DOMoveY(transform.position.y + height, bounceDuration)
                .SetEase(Ease.OutQuad));
            bounceSequence.Append(transform.DOMoveY(transform.position.y, bounceDuration)
                .SetEase(Ease.InQuad));

            height *= dampingFactor; 
        }

        bounceSequence.SetLoops(-1);
    }
}


