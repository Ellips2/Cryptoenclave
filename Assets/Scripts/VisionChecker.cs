using UnityEngine;

[RequireComponent(typeof(RectTransform))]
[RequireComponent(typeof(ColorChanger))]
[RequireComponent(typeof(CharsChanger))]
public class VisionChecker : MonoBehaviour
{
    private RectTransform _rectTransform;
    private CharsChanger _charsChanger;
    private ColorChanger _colorChanger;
    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
        _rectTransform = GetComponent<RectTransform>();
        _colorChanger = GetComponent<ColorChanger>();
        _charsChanger = GetComponent<CharsChanger>();
    }

    private void Update()
    {
        if (_rectTransform.IsVisibleFrom(_camera))
        {
            _charsChanger.StartFX();
            _colorChanger.StartChange();
            enabled = false;
        }
    }
}
