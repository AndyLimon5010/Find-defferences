using System;
using UnityEngine;
using UnityEngine.Events;
using YG;

public class Game : MonoBehaviour
{
    public UnityEvent GameEnded;

    public static Action GameStarted;
    public static Action GameWon;
    public static Action GameLost;

    [SerializeField] private YandexGame _yG;

    private int _score;
    private int _differencesCount;

    private void Start()
    {
        Handle_StartGame();
    }

    private void OnEnable()
    {
        CircleButton.DifferenceFound += Handle_AddScore;
        Pair.DifferencesNumberCalculated += Handle_DifferencesNumberCalculated;
    }

    private void OnDisable()
    {
        CircleButton.DifferenceFound -= Handle_AddScore;
        Pair.DifferencesNumberCalculated -= Handle_DifferencesNumberCalculated;
    }

    public void Handle_StartGame()
    {
        GameStarted?.Invoke();
        _score = 0;
    }

    public void Handl_StartNewLevel()
    {
        if (GameInfo.ActiveLevel != GameInfo.ImagesCount)
        {
            GameInfo.ActiveLevel++;
            Handle_StartGame();
        }
        else
        {
            GameEnded.Invoke();
        }
    }

    public void Handle_AddScore()
    {
        _score++;
        if (_score == _differencesCount)
        {
            if (GameInfo.LastOpenedLevel == GameInfo.ActiveLevel &&
                GameInfo.ActiveLevel != GameInfo.ImagesCount)
            {
                GameInfo.LastOpenedLevel++;

                YandexGame.savesData.LastOpenedLevel = GameInfo.LastOpenedLevel;
                YandexGame.SaveProgress();
            }

            GameWon?.Invoke();
        }
    }

    private void Handle_DifferencesNumberCalculated(int value)
    {
        _differencesCount = value;
    }
}
