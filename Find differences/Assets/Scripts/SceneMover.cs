using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMover : MonoBehaviour
{
    [SerializeField] private SceneName sceneName;

    public void Handle_ToMoveScene()
    {
        SceneManager.LoadScene(sceneName.ToString());
    }
}

public enum SceneName
{
    GameScene,
    MainMenuScene
}