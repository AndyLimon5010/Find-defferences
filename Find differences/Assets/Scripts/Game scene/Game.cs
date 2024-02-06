using System;
using System.Collections;
using UnityEngine;
using YG;

public class Game : MonoBehaviour
{
    public static Action<int> ScoreAdded;
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

    public void Handle_AddScore()
    {
        _score++;
        ScoreAdded?.Invoke(_score);
        if (_score == _differencesCount)
        {
            if (GameInfo.ActiveLevel != GameInfo.ImagesCount)
            {
                GameInfo.ActiveLevel++;

                if (GameInfo.LastOpenedLevel < GameInfo.ActiveLevel)
                {
                    GameInfo.LastOpenedLevel = GameInfo.ActiveLevel;
                }
            }
            else
            {
                //Временное решение
                GameInfo.ActiveLevel = 1;
            }
            GameWon?.Invoke();
        }
    }

    private void Handle_DifferencesNumberCalculated(int value)
    {
        _differencesCount = value;
    }
}
