using System.Collections;
using UnityEngine;

public class Sound : MonoBehaviour
{
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void Start()
    {
        DontDestroyOnLoad(gameObject);
        if (GameInfo.IsSoundMute == false)
        {
            _audioSource.Play();
        }
        StartCoroutine(DestroyPrefab());
    }

    private IEnumerator DestroyPrefab()
    {
        yield return new WaitForSeconds(_audioSource.clip.length);
        Destroy(gameObject);
    }
}
