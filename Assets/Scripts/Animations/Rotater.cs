using DG.Tweening;
using UnityEngine;

public class Rotater : MonoBehaviour
{
    [SerializeField] private float durationRotate = 4f;
    [SerializeField] private Vector3 direction;

    private void Start()
    {
        transform.Rotate(new Vector3(0, Random.Range(0, 360), 0));
        transform.DOLocalRotate(direction, durationRotate, RotateMode.FastBeyond360)
            .SetRelative(true).SetEase(Ease.Linear).SetLoops(-1);
    }
}
