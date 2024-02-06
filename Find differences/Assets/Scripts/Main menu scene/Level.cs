using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    public UnityEvent LevelActiviting;

    [SerializeField] private GameObject _lockGo;
    [SerializeField] private RawImage _image;
    [SerializeField] private int _number;
    
    private void Start()
    {
        if (_number <= GameInfo.LastOpenedLevel)
        {
            _lockGo.SetActive(false);
            Color color = new(1, 1, 1, 1);
            _image.color = color;
        }
    }

    public void Handle_CheckActivity()
    {
        if (_number <= GameInfo.LastOpenedLevel)
        {
            GameInfo.ActiveLevel = _number;
            LevelActiviting.Invoke();
        }
    }
}
