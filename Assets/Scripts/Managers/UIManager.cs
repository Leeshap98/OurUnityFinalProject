using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("UI")]
    [SerializeField] Button _pauseButton;
    [SerializeField] Button _resumeButton;
    [SerializeField] GameObject _pausePanel;
    [SerializeField] TextMeshProUGUI _timeLeft;
    [SerializeField] TextMeshProUGUI _scoreText;
    [SerializeField] GameObject _optionsPanel;
    

    public float Timer { get; set; } = 0;
    public float Score { get; private set; } = 0; 

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (!GameManager.Instance.GameIsPasued && GameManager.Instance.BallHasSpawnd)
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
        _pausePanel.SetActive(true);
        _optionsPanel.SetActive(false);
        GameManager.Instance.GameIsPasued = true;
        _pauseButton.gameObject.SetActive(false);
        _resumeButton.gameObject.SetActive(true);
    }

    public void ResumeGameMenu()
    {
        _pausePanel.SetActive(false);
        _optionsPanel.SetActive(false);
        GameManager.Instance.GameIsPasued = false;
        _pauseButton.gameObject.SetActive(true);
        _resumeButton.gameObject.SetActive(false);
    }
    public void QuitGame()
    {
        SceneManager.LoadScene("OpenScene");
    }
    public void optionsOn()
    {
       _optionsPanel.SetActive(true);
        _pausePanel.SetActive(false);
    }
}
