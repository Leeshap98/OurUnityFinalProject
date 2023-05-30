using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("UI")]
    [SerializeField]
    GameObject _startMenu;
    [SerializeField]
    GameObject _background;
    [SerializeField]
    Button _pauseButton;
    [SerializeField]
    Button _resumeButton;
    [SerializeField]
    GameObject _pauseMenu;

    [Header("Clamp Slider")]

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
        _pauseButton.gameObject.SetActive(false);

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

    public void PauseGameMenu()
    {
        _background.SetActive(true);
        _pauseMenu.SetActive(true);
        GameManager.Instance.GameIsPasued = true;
        _pauseButton.gameObject.SetActive(false);
        _resumeButton.gameObject.SetActive(true);
    }

    public void ResumeGameMenu()
    {
        _background.SetActive(false);
        _pauseMenu.SetActive(false);
        GameManager.Instance.GameIsPasued = false;
        _pauseButton.gameObject.SetActive(true);
        _resumeButton.gameObject.SetActive(false);
    }

    public void StartGame()
    {
        _pauseButton.gameObject.SetActive(true);
        _startMenu.gameObject.SetActive(false);
        GameManager.Instance.LoadLevel();
    }

    }
