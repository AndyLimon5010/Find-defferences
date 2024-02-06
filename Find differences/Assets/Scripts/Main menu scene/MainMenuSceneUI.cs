using UnityEngine;

public class MainMenuSceneUI : MonoBehaviour
{
    [SerializeField] private GameObject MenuMenuGo;
    [SerializeField] private GameObject LevelMenuGo;
    [SerializeField] private GameObject SettingsMenuGo;

    private void Start()
    {
        MenuMenuGo.SetActive(true);
        LevelMenuGo.SetActive(false);
        SettingsMenuGo.SetActive(false);
    }
}
