using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public float Timer 
    { 
        get; 
        set; 
    } = 0;
    public float Score { get; private set; } = 0;

    [Header("UI")]
    [SerializeField] Button pauseButton;
    [SerializeField] Button resumeButton;
    [SerializeField] GameObject pausePanel;
    [SerializeField] TextMeshProUGUI timeLeft;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] GameObject optionsPanel;
    //[SerializeField] AudioMixer MusicMixer;
    //[SerializeField] AudioMixer SFXMixer;


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
            timeLeft.text = $"Time: {timer.ToString()}s";
        }
    }

    public void AddScore(int addedScore)
    {
        Score += addedScore;
        scoreText.text = $"Score: {Score.ToString()}";
    }

    public void ResetScore()
    {
        Score = 0;
        scoreText.text = $"Score: {Score.ToString()}";
    }

    public void RestTimer()
    {
        Timer = 0;
        int timer = System.Convert.ToInt32(Timer);
        timeLeft.text = $"Time: {timer.ToString()}s";
    }
    public void PauseGameMenu()
    {
        pausePanel.SetActive(true);
        optionsPanel.SetActive(false);
        GameManager.Instance.GameIsPasued = true;
        pauseButton.gameObject.SetActive(false);
        resumeButton.gameObject.SetActive(true);
    }

    public void ResumeGameMenu()
    {
        pausePanel.SetActive(false);
        optionsPanel.SetActive(false);
        GameManager.Instance.GameIsPasued = false;
        pauseButton.gameObject.SetActive(true);
        resumeButton.gameObject.SetActive(false);
    }

    //public void StartGame()
    //{
    //    GameManager.Instance.StartGame();

    //  /*  GameManager.Instance.LoadLevel();
    //    GameManager.Instance.GameStarted = true;
    //    GameManager.Instance.GameIsPasued = false;
    //    _pauseButton.gameObject.SetActive(true);
    //    _startMenu.gameObject.SetActive(false);
    //    _timeLeft.gameObject.SetActive(true);
    //    _scoreText.gameObject.SetActive(true);*/
    //}
    public void QuitGame()
    {
        SceneManager.LoadScene("OpenScene");
    }
    public void optionsOn()
    {
       optionsPanel.SetActive(true);
        pausePanel.SetActive(false);
    }
    //public void SetMusicVolume(float volume)
    //{
    //    MusicMixer.SetFloat("volume", volume);
    //}
    //public void SetSFXVolume(float volume)
    //{
    //    SFXMixer.SetFloat("volume", volume);
    //}
    //public void SetSound(bool isFullScreen)
    //{
    //    MusicMixer.SetFloat("volume", 0);
    //    SFXMixer.SetFloat("volume", 0);
    //}
    ////public void SetVib(bool IsVib)
    ////{

    ////}
}
