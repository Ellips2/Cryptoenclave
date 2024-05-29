using DG.Tweening;
using UnityEngine;

public class SpawnScale : MonoBehaviour
{
    [SerializeField] private float durationScale = 2f;

    private Vector3 _targetScale;

    private void Start()
    {
        _targetScale = transform.localScale;
        transform.localScale = Vector3.zero;
        transform.DOScale(_targetScale, durationScale).SetEase(Ease.OutElastic).SetDelay(Random.Range(0, 1f));
    }
}
