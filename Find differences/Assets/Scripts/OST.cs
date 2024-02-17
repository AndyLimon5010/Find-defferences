using UnityEngine;

public class OST : MonoBehaviour
{
    public static OST Instance = null;

    private AudioSource _audioSource;

    private void Awake()
    {
        if (Instance == null)
        {
            _audioSource = GetComponent<AudioSource>();
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    private void OnEnable()
    {
        MusicButton.MusicMuted += Handle_MusicMuted;
    }

    private void OnDisable()
    {
        MusicButton.MusicMuted -= Handle_MusicMuted;
    }

    public void Handle_MusicMuted()
    {
        _audioSource.mute = GameInfo.IsMusicMute;
    }
}
