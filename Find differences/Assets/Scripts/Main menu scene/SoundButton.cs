using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundButton : MonoBehaviour
{
    public static Action SoundMuted;

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
        if (GameInfo.IsSoundMute == false)
        {
            _image.sprite = _sprites[0];
        }
        else
        {
            _image.sprite = _sprites[1];
        }
    }

    public void Handle_MuteSound()
    {
        GameInfo.IsSoundMute = !GameInfo.IsSoundMute;
        SoundMuted?.Invoke();
        ChangeSprite();
    }
}
