using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingMenu : MonoBehaviour
{
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        if (GameInfo.IsSoundMute == false)
        {
            _audioSource.Play();
        }
    }
}
