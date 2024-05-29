using UnityEngine;
using TMPro;
using System.Collections;

public class ColorChanger : MonoBehaviour
{
    [SerializeField] private Color startColor;
    [SerializeField] private Color targetColor;
    [SerializeField] private float duration = 1.0f;
    [SerializeField] private float delayToReturn = 0.5f;
    [SerializeField] private bool withReturnToStartColor;

    private TextMeshProUGUI _textMesh;

    private void Awake() => _textMesh = GetComponent<TextMeshProUGUI>();

    public void StartChange() => StartCoroutine(ChangeColor(startColor, targetColor, withReturnToStartColor));

    private IEnumerator ChangeColor(Color from, Color to, bool withReturn)
    {
        var elapsedTime = 0.0f;
        
        while (elapsedTime < duration)
        {
            Color currentColor = Color.Lerp(from, to, elapsedTime / duration);
            _textMesh.color = currentColor;
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        _textMesh.color = to;

        if (withReturn && from != to)
        {
            yield return new WaitForSeconds(delayToReturn);
            StartCoroutine(ChangeColor(to, from, false));
        }
    }
}