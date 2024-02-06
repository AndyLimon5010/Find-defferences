using UnityEngine;

public class AudioSourceScript : MonoBehaviour
{
    [SerializeField] private AudioType _audioType;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        SettingsMenu.VolumeChanged += Handle_SetVolume;
    }

    private void OnDisable()
    {
        SettingsMenu.VolumeChanged -= Handle_SetVolume;
    }

    private void Handle_SetVolume(float value, AudioType audioType)
    {
        if (audioType == _audioType)
        {
            _audioSource.volume = value;
        }
    }
}

public enum AudioType
{
    Music,
    Sound
}