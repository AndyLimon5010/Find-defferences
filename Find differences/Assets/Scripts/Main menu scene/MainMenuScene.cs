using UnityEngine;
using YG;

public class MainMenuScene : MonoBehaviour
{
    private void OnEnable()
    {
        YandexGame.GetDataEvent += Handle_LoadData;
    }

    private void OnDisable()
    {
        YandexGame.GetDataEvent -= Handle_LoadData;
    }

    private void Handle_LoadData()
    {
        GameInfo.LastOpenedLevel = YandexGame.savesData.LastOpenedLevel;
    }
}
