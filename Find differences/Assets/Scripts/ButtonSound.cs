using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    [SerializeField] private GameObject _soundPrefab;

    public void Handle_PlaySound()
    {
        if (GameInfo.IsSoundMute == false)
        {
            Instantiate(_soundPrefab);
        }
    }
}
