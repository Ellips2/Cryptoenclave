using UnityEngine;
using UnityEngine.Events;

public class TriggerByVIsion : MonoBehaviour
{
    [SerializeField] private UnityEvent action;

    private RectTransform _rectTransform;
    private Camera _camera;

    void Start()
    {
        _camera = Camera.main;
        _rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        if (_rectTransform.IsVisibleFrom(_camera))
        {
            action.Invoke();
            enabled = false;
        }
    }
}
