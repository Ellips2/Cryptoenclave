using DG.Tweening;
using UnityEngine;

public class LogoAnimator : MonoBehaviour
{
    [SerializeField] private Transform front;
    [SerializeField] private Transform back;

    private void Start() 
    {
        DOTween.Sequence().AppendInterval(5f).Append(front.DORotate(new Vector3(0, 90f, 0), 0.25f))
                                                .Append(back.DORotate(new Vector3(0, 180f, 0), 0.25f))
                                                .AppendInterval(5f)
                                                .Append(back.DORotate(new Vector3(0, 90f, 0), 0.25f))
                                                .Append(front.DORotate(new Vector3(0, 0, 0), 0.25f))
                                                .SetLoops(-1).SetEase(Ease.Linear);
    }
}
