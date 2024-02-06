using System;
using UnityEngine;

public class Pair : MonoBehaviour
{
    public static Action<int> DifferencesNumberCalculated;

    [SerializeField] private GameObject ImageGo;

    private int _differencesCount;

    private void Start()
    {
        _differencesCount = ImageGo.transform.childCount;
        DifferencesNumberCalculated?.Invoke(_differencesCount);
    }
}
