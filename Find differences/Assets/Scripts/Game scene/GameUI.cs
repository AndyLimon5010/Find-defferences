using UnityEngine;

public class GameUI : MonoBehaviour
{
    [SerializeField] private GameObject _countersGo;

    private int _differencesCount;

    public void Start()
    {
        Handle_StartGame();
    }

    private void OnEnable()
    {
        Game.GameStarted += Handle_StartGame;
        Pair.DifferencesNumberCalculated += Handle_DifferencesNumberCalculated;
    }

    private void OnDisable()
    {
        Game.GameStarted -= Handle_StartGame;
        Pair.DifferencesNumberCalculated -= Handle_DifferencesNumberCalculated;
    }

    public void Handle_StartGame()
    {
        while (transform.childCount > 0)
        {
            DestroyImmediate(transform.GetChild(0).gameObject);
        }
        Instantiate(Resources.Load($"Pairs/Pair {GameInfo.ActiveLevel}"), transform);
    }

    private void Handle_DifferencesNumberCalculated(int value)
    {
        _differencesCount = value;

        while (_countersGo.transform.childCount > 0)
        {
            DestroyImmediate(_countersGo.transform.GetChild(0).gameObject);
        }
        Instantiate(Resources.Load($"Counters/Counters - {_differencesCount} dif"),
            _countersGo.transform);
    }
}
