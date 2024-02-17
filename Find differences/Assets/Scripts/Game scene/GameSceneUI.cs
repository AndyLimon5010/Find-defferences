using System.Collections;
using UnityEngine;

public class GameSceneUI : MonoBehaviour
{
    [SerializeField] private GameObject _victoryMenu;
    [SerializeField] private GameObject _defeatMenu;

    private void Start()
    {
        Handle_StartGame();
    }

    private void OnEnable()
    {
        Game.GameStarted += Handle_StartGame;
        Game.GameWon += Handle_GameWon;
        Game.GameLost += Handle_GameLost;
    }

    private void OnDisable()
    {
        Game.GameStarted -= Handle_StartGame;
        Game.GameWon -= Handle_GameWon;
        Game.GameLost -= Handle_GameLost;
    }

    private void Handle_StartGame()
    {
        _victoryMenu.SetActive(false);
        _defeatMenu.SetActive(false);
    }

    private void Handle_GameWon()
    {
        StartCoroutine(Timer(true));
    }

    private void Handle_GameLost()
    {
        StartCoroutine(Timer(false));
    }

    private IEnumerator Timer(bool isVictory)
    {
        yield return new WaitForSeconds(0.4f);
        
        if (isVictory == true)
        {
            _victoryMenu.SetActive(true);
        }
        else
        {
            _defeatMenu.SetActive(true);
        }
    }
}
