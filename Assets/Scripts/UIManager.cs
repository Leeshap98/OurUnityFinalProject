using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("UI")]
    [SerializeField] GameObject _startMenu;
    [SerializeField] GameObject _background;
    [SerializeField] Button _pauseButton;
    [SerializeField] Button _resumeButton;
    [SerializeField] GameObject _pauseMenu;
    [SerializeField] TextMeshProUGUI _timeLeft;
    [SerializeField] TextMeshProUGUI _scoreText;

    public float Timer { get; private set; } = 0;
    public float Score { get; private set; } = 0; 

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (!GameManager.Instance.GameIsPasued)
        {
            Timer += Time.deltaTime;
            int timer = System.Convert.ToInt32(Timer);
            _timeLeft.text = $"Time: {timer.ToString()}s";
        }
    }

    public void AddScore(int addedScore)
    {
        Score += addedScore;
        _scoreText.text = $"Score: {Score.ToString()}";
    }

    public void ResetScore()
    {
        Score = 0;
        _scoreText.text = $"Score: {Score.ToString()}";
    }

    public void RestTimer()
    {
        Timer = 0;
        int timer = System.Convert.ToInt32(Timer);
        _timeLeft.text = $"Time: {timer.ToString()}s";
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
        GameManager.Instance.StartGame();

      /*  GameManager.Instance.LoadLevel();
        GameManager.Instance.GameStarted = true;
        GameManager.Instance.GameIsPasued = false;
        _pauseButton.gameObject.SetActive(true);
        _startMenu.gameObject.SetActive(false);
        _timeLeft.gameObject.SetActive(true);
        _scoreText.gameObject.SetActive(true);*/
    }

    }
