using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class TopPanelNode : MonoBehaviour
{
    [SerializeField] private Transform chaptersContainer;
    [SerializeField] private Transform buttonsContainer;
    [SerializeField] private ChapterButton buttonPrefab;
    [SerializeField] private ScrollView scrollView;
    [SerializeField] private Scrollbar scrollbar;
    [SerializeField] private Button languageButton;
    [SerializeField] private TextMeshProUGUI languageButtonLabel;
    [SerializeField] private Button exitButton;
    [SerializeField] private Button buttonDown;
    [SerializeField] private Button buttonUp;

    private List<ChapterButton> _buttons = new();
    private int _previousChapterNumber = 1;
    private bool _isEnglish;
    private bool isSwitchFromButtons;

    private const float DurationAutoScroll = 0.25f;

    private void Start()
    {
        chaptersContainer.GetChildren().ForEach(chapter =>
        {
            var chapterButton = Instantiate(buttonPrefab, buttonsContainer);
            chapterButton.Init(chapter);
            _buttons.Add(chapterButton);
        });
        SwitchCurrentChapter(_buttons[0]);
        Subscribe();
    }

    private void OnDestroy() => Unsubscribe();

    private void Subscribe()
    {
        _buttons.ForEach(b => b.OnClick += SwitchCurrentChapter);
        languageButton.onClick.AddListener(OnChangeLanguage);
        exitButton.onClick.AddListener(OnExit);
        buttonDown.onClick.AddListener(() => SwitchCurrentChapter(_buttons[^1]));
        buttonUp.onClick.AddListener(() => SwitchCurrentChapter(_buttons[0]));
        scrollbar.onValueChanged.AddListener(x => UpdateButtonsSelect(_buttons[GetCurrentButton(x)]));
    }

    private void Unsubscribe()
    {
        _buttons.ForEach(b => b.OnClick -= SwitchCurrentChapter);
        languageButton.onClick.RemoveAllListeners();
        exitButton.onClick.RemoveAllListeners();
        buttonDown.onClick.RemoveAllListeners();
        buttonUp.onClick.RemoveAllListeners();
        scrollbar.onValueChanged.RemoveAllListeners();
    }

    private void SwitchCurrentChapter(ChapterButton selectedButton)
    {
        UpdateButtonsSelect(selectedButton);

        var targetChapterId = _buttons.IndexOf(selectedButton);
        var targetChapterNumber = targetChapterId + 1;

        var startValue = scrollbar.value;
        var targetValue = 1f - targetChapterId / (_buttons.Count - 1f);
        var delta = Mathf.Abs(targetChapterNumber - _previousChapterNumber);
        DOVirtual.Float(startValue, targetValue, DurationAutoScroll * delta, (value) => scrollbar.value = value);

        _previousChapterNumber = targetChapterNumber;
        isSwitchFromButtons = true;
    }

    private void UpdateButtonsSelect(ChapterButton selectedButton)
    {
        if (isSwitchFromButtons) {isSwitchFromButtons = false; return;}
        _buttons.ForEach(b => b.ChangeSelectStatus(true));
        selectedButton.ChangeSelectStatus(false);
    }

    private int GetCurrentButton(float scrollValue) => Mathf.RoundToInt((_buttons.Count - 1f) * (1f - scrollValue));

    private void OnChangeLanguage()
    {
        _isEnglish = !_isEnglish;
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[_isEnglish ? 0 : 1];
        languageButtonLabel.text = _isEnglish ? "Ru" : "Eng";
    }

    private void OnExit() => Application.Quit();
}
