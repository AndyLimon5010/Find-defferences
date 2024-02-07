using System;
using UnityEngine;
using UnityEngine.UI;

public class CircleButton : MonoBehaviour
{
    public static Action DifferenceFound;
    public static Action<int> HintShowed;

    [SerializeField] private GameObject _pair;
    [SerializeField] private GameObject _hint;
    [SerializeField] private int _number;
    [SerializeField] private int _imageId;

    private CircleButton _pairCircleButton;

    private Image _myImage;
    private Image _pairImage;

    private Button _myButton;
    private Button _pairButton;

    private RectTransform _myRectTransform;
    private RectTransform _pairRectTransform;

    private void Awake()
    {
        _myImage = GetComponent<Image>();
        _pairImage = _pair.GetComponent<Image>();

        _myButton = GetComponent<Button>();
        _pairButton = _pair.GetComponent<Button>();

        _myRectTransform = GetComponent<RectTransform>();
        _pairRectTransform = _pair.GetComponent<RectTransform>();

        _pairCircleButton = _pair.GetComponent<CircleButton>();
    }

    private void Start()
    {
        _hint.SetActive(false);

        Color color = new(_myImage.color.r, _myImage.color.g, _myImage.color.b, 0);
        _myImage.color = color;

        _myButton.interactable = true;

        if (_imageId == 0)
        {
            transform.localPosition = _pair.transform.localPosition;
            _myRectTransform.sizeDelta = _pairRectTransform.sizeDelta;
        }
    }

    private void OnEnable()
    {
        Hint.HintGiving += Handle_GetHint;
    }

    private void OnDisable()
    {
        Hint.HintGiving -= Handle_GetHint;
    }

    public void Handle_ShowCircles()
    {
        _hint.SetActive(false);
        _pairCircleButton._hint.SetActive(false);

        Color color = new(_myImage.color.r, _myImage.color.g, _myImage.color.b, 1);
        _myImage.color = color;
        _pairImage.color = color;

        _myButton.interactable = false;
        _pairButton.interactable = false;

        HintShowed?.Invoke(_number - 1);
        DifferenceFound?.Invoke();
    }

    private void Handle_GetHint(int index)
    {
        if (index + 1 == _number)
        {
            _hint.SetActive(true);
            HintShowed?.Invoke(index);
        }
    }
}
