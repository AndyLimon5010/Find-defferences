using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public static Action<float, AudioType> VolumeChanged;

    [SerializeField] private Slider _musicSlider;
    [SerializeField] private Slider _soundSlider;
    [SerializeField] private TMP_Dropdown _languageDropdownText;

    private void Start()
    {
        _musicSlider.value = GameSettings.MusicVolume;
        _soundSlider.value = GameSettings.SoundVolume;
        _languageDropdownText.value = GameSettings.Language;
    }

    public void Handle_MusicVolumeChange()
    {
        GameSettings.MusicVolume = _musicSlider.value;
        SetVolume(_musicSlider.value, AudioType.Music);
    }

    public void Handle_SoundVolumeChange()
    {
        GameSettings.SoundVolume = _soundSlider.value;
        SetVolume(_soundSlider.value, AudioType.Sound);
    }

    private void SetVolume(float value, AudioType audioType)
    {
        VolumeChanged?.Invoke(value, audioType);
    }

    public void Handle_LanguageChange()
    {
        GameSettings.Language = _languageDropdownText.value;
        StartCoroutine(SetLanguage());
    }

    private IEnumerator SetLanguage()
    {
        yield return LocalizationSettings.InitializationOperation;
        LocalizationSettings.SelectedLocale = 
            LocalizationSettings.AvailableLocales.Locales[_languageDropdownText.value];
    }
}
