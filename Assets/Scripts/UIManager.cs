using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField]
    Slider _clampXSlider;
    [SerializeField]
    Slider _clampYSlider; 
    [SerializeField]
    Slider _clampZSlider;

    public float clampX { get; private set; } = 30;
    public float clampY { get; private set; } = 30;
    public float clampZ { get; private set; } = 30;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _clampXSlider.onValueChanged.AddListener(HandleSliderValueChangeX);
        _clampYSlider.onValueChanged.AddListener(HandleSliderValueChangeY);
        _clampZSlider.onValueChanged.AddListener(HandleSliderValueChangeZ);
    }

    private void HandleSliderValueChangeX(float value)
    {
        clampX = value;
    }
    private void HandleSliderValueChangeY(float value)
    {
        clampY = value;
    }
    private void HandleSliderValueChangeZ(float value)
    {
        clampZ = value;
    }
}
