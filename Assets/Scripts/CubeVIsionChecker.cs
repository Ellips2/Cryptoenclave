using UnityEngine;

public class CubeVIsionChecker : MonoBehaviour
{
    private RectTransform _rectTransform;
    private Mover _mover;
    private Camera _camera;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _mover = GetComponent<Mover>();
    }

    private void Update()
    {
        if (_rectTransform.IsVisibleFrom(_camera))
        {
            _mover.enabled = true;
            enabled = false;
        }
    }
}
