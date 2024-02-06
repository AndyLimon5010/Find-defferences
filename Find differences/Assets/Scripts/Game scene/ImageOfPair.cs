using System;
using UnityEngine;

public class ImageOfPair : MonoBehaviour
{
    public static Action MissClicked;

    public void Handle_MissClicked()
    {
        MissClicked?.Invoke();
    }
}
