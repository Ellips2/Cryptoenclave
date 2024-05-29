using DG.Tweening;
using UnityEngine;

public class Scaler : MonoBehaviour
{
    [SerializeField] private float durationScale = 2f;
    [SerializeField] private float scaleMultiplier = 2f;
    [SerializeField] private Ease ease = Ease.InOutCubic;

    private void Start()
    {
        transform.DOScale(transform.localScale * scaleMultiplier, durationScale)
            .SetEase(ease).SetLoops(-1, LoopType.Yoyo).SetDelay(Random.Range(0, 1f));
    }
}
