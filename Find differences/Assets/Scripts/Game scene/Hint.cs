using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hint : MonoBehaviour
{
    [SerializeField] private Button _hintButton;

    public static Action<int> HintGiving;

    private List<bool> _hints = new();
    private int _hintCount;

    private void Awake()
    {
        _hintButton = GetComponent<Button>();
    }

    private void Start()
    {
        Handle_StartGame();
    }

    private void OnEnable()
    {
        CircleButton.HintShowed += Handle_SetHint;
        Game.GameStarted += Handle_StartGame;
        Pair.DifferencesNumberCalculated += Handle_DifferencesNumberCalculated;
    }

    private void OnDisable()
    {
        CircleButton.HintShowed -= Handle_SetHint;
        Game.GameStarted -= Handle_StartGame;
        Pair.DifferencesNumberCalculated -= Handle_DifferencesNumberCalculated;
    }

    private void Handle_StartGame()
    {
        _hintButton.interactable = true;
    }

    public void Handle_ChooseHint()
    {
        bool isChose = false;
        int hintIndex = 0;

        while (isChose == false)
        {
            hintIndex = UnityEngine.Random.Range(0, _hints.Count);
            if (_hints[hintIndex] == false)
            {
                isChose = true;
            }
        }

        HintGiving?.Invoke(hintIndex);
    }

    private void Handle_SetHint(int index)
    {
        if (_hints[index] == false)
        {
            _hints[index] = true;
            _hintCount--;

            if (_hintCount == 0)
            {
                _hintButton.interactable = false;
            }
        }
    }

    private void Handle_DifferencesNumberCalculated(int value)
    {
        _hintCount = value;
        _hints.Clear();
        for (int i = 0; i < _hintCount; i++)
        {
            _hints.Add(false);
        }
    }
}
