using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicButton : MonoBehaviour
{
    public static Action MusicMuted;

    [SerializeField] private List<Sprite> _sprites;

    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    private void Start()
    {
        ChangeSprite();
    }

    private void ChangeSprite()
    {
        if (GameInfo.IsMusicMute == false)
        {
            _image.sprite = _sprites[0];
        }
        else
        {
            _image.sprite = _sprites[1];
        }
    }

    public void Handle_MuteMusic()
    {
        GameInfo.IsMusicMute = !GameInfo.IsMusicMute;
        MusicMuted?.Invoke();
        ChangeSprite();
    }
}
