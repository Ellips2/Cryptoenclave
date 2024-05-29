using System.Collections;
using System.Linq;
using TMPro;
using UnityEngine;

public class CharsChanger : MonoBehaviour
{
    private TextMeshProUGUI _textMeshProUGUI;
    private int _changesAtTime;

    private const float Duration = 0.5f;
    private const float MinDelay = 0.05f;

    public void StartFX() 
    {
        _textMeshProUGUI = GetComponent<TextMeshProUGUI>();
        var randomizedChars = Enumerable.Range(0, _textMeshProUGUI.text.Length).Select(_ => GetRandomChar()).ToArray();
        var shuffledIndices = Enumerable.Range(0, _textMeshProUGUI.text.Length).OrderBy(x => Random.value).ToArray();
        StartCoroutine(GraduallyChangeStringChars(_textMeshProUGUI.text, randomizedChars, shuffledIndices, true));
    }

    private char GetRandomChar()
    {
        var chars = Enumerable.Range(33, 127).Select(c => (char)c).ToArray();
        var randomIndex = Random.Range(0, chars.Length);
        return chars[randomIndex];
    }

    private IEnumerator GraduallyChangeStringChars(string originalString, char[] targetChars, int[] shuffledIndices, bool withReset)
    {
        var chars = originalString.ToCharArray();

        _changesAtTime = Mathf.RoundToInt(shuffledIndices.Length / Duration * MinDelay);
        var stepCount = shuffledIndices.Length / Mathf.Max(_changesAtTime, 1);
        var parts = new int[stepCount][];

        for (var i = 0; i < stepCount; i++)
        {
            parts[i] = shuffledIndices.Skip(i * _changesAtTime).Take(_changesAtTime).ToArray();
        }

        foreach (var part in parts)
        {
            foreach (var index in part)
            {
                chars[index] = targetChars[index];
                _textMeshProUGUI.text = new string(chars);
            }
            yield return new WaitForSeconds(MinDelay);
        }


        if (withReset)
            StartCoroutine(GraduallyChangeStringChars(_textMeshProUGUI.text, originalString.ToCharArray(), shuffledIndices, false));
    }
}
