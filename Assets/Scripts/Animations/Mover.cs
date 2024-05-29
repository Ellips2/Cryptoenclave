using DG.Tweening;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float durationMove = 3f;
    [SerializeField] private Vector3 targetPoint;
    [SerializeField] private bool isLoop;

    private void Start()
    {
        if (isLoop)
            transform.DOLocalMove(targetPoint, durationMove).
                SetEase(Ease.InOutCubic).SetLoops(-1, LoopType.Yoyo).SetDelay(Random.Range(0, 1f));
        else
            transform.DOLocalMove(targetPoint, durationMove).
                SetEase(Ease.Linear);
    }
}
