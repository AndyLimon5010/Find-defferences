using TMPro;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;

    private int _differencesCount;

    public void Start()
    {
        Handle_StartGame();
    }

    private void OnEnable()
    {
        Game.ScoreAdded += Handle_UpdateScoreText;
        Game.GameStarted += Handle_StartGame;
        Pair.DifferencesNumberCalculated += Handle_DifferencesNumberCalculated;
    }

    private void OnDisable()
    {
        Game.ScoreAdded -= Handle_UpdateScoreText;
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

    public void Handle_UpdateScoreText(int score)
    {
        _scoreText.text = $"{score}/{_differencesCount}";
    }

    private void Handle_DifferencesNumberCalculated(int value)
    {
        _differencesCount = value;
        Handle_UpdateScoreText(0);
    }
}
