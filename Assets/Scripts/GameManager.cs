using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameAnalyticsSDK;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] MazeGyro _mazeGyro;
    [SerializeField] Ball _ball;

    public bool RestartGame = false;
    public bool GameIsPasued = false;
    public bool GameStarted = false;

    private void Awake()
    {
        Instance = this;
        GameAnalytics.Initialize();
        Application.targetFrameRate = 60;
    }

    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            return;
        }

        UIManager.Instance.ResumeGameMenu();
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Start, "World_1_Level1");
    }

    private void OnApplicationFocus(bool focus)
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            return;
        }
        UIManager.Instance.PauseGameMenu();
    }

    public void StartGame()
    {
        Debug.Log("sad");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadLevel()
    {
        _mazeGyro.gameObject.SetActive(true);
        _ball.gameObject.SetActive(true);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void EndLevel()
    {
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, "World_1");
        GameAnalytics.NewResourceEvent(GAResourceFlowType.Source, "Coins", UIManager.Instance.Score, "Coins", "Coins");
        GameAnalytics.NewResourceEvent(GAResourceFlowType.Source, "Time", UIManager.Instance.Timer, "Time", "Time");
    }

    private void Update()
    {
        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            return;
        }

        if (GameIsPasued)
        {
            _mazeGyro.GyroIsEnabled = false;
            _ball.SetKinematic(true);
        }
        else
        {
            _mazeGyro.GyroIsEnabled = true;
            _ball.SetKinematic(false);
        }
    }
}
