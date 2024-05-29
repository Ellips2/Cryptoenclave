using DG.Tweening;
using UnityEngine;

public class Scaler : MonoBehaviour
{
    [SerializeField] private float durationScale = 2f;

    private void Start()
    {
        transform.DOScale(transform.localScale * Random.Range(1f, 1.3f), durationScale)
            .SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo).SetDelay(1f);
    }
}
