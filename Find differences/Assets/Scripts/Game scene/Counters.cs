using System.Collections.Generic;
using UnityEngine;

public class Counters : MonoBehaviour
{
    [SerializeField] private List<Animator> _animators;

    private AudioSource _audioSource;

    private int _score;
    
    private void OnEnable()
    {
        Game.GameStarted += Handle_StartGame;
        CircleButton.DifferenceFound += Handle_DifferenceFound;
    }

    private void OnDisable()
    {
        Game.GameStarted -= Handle_StartGame;
        CircleButton.DifferenceFound -= Handle_DifferenceFound;
    }

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Handle_StartGame()
    {
        _score = 0;

        for (int i = 0; i < _animators.Count; i++)
        {
            _animators[i].Play("Start");
        }
    }

    private void Handle_DifferenceFound()
    {
        if (GameInfo.IsSoundMute == false)
        {
            _audioSource.Play();

        }

        _animators[_score].Play("Flash");
        _score++;
    }
}
