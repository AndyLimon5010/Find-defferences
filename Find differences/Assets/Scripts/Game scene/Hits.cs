using System.Collections.Generic;
using UnityEngine;

public class Hits : MonoBehaviour
{
    [SerializeField] private List<Animator> _animators;

    private AudioSource _audioSource;

    private int _count;

    private void OnEnable()
    {
        Game.GameStarted += Handle_StartGame;
        ImageOfPair.MissClicked += Handle_HitsAreDiminishing;
    }

    private void OnDisable()
    {
        Game.GameStarted -= Handle_StartGame;
        ImageOfPair.MissClicked -= Handle_HitsAreDiminishing;
    }

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Handle_StartGame()
    {
        _count = _animators.Count;

        for (int i = 0; i < _count; i++)
        {
            _animators[i].Play("Start");
        }
    }

    private void Handle_HitsAreDiminishing()
    {
        if (_count == 0)
        {
            return;
        }

        if (GameInfo.IsSoundMute == false)
        {
            _audioSource.Play();

        }

        _count--;

        _animators[_count].Play("Broke");

        if (_count == 0)
        {
            Game.GameLost?.Invoke();
        }
    }
}
