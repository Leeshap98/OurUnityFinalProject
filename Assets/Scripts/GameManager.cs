using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameAnalyticsSDK;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField]
    MazeGyro _mazeGyro;
    [SerializeField]
    Ball _ball;
    public bool GameIsPasued = false;

    private void Awake()
    {
        GameAnalytics.Initialize();
        Instance = this;

        Application.targetFrameRate = 60;
    }

    private void Start()
    {
        UIManager.Instance.ResumeGameMenu();
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Start, "World_1_Level1");
    }

    private void OnApplicationFocus(bool focus)
    {
        UIManager.Instance.PauseGameMenu();
    }

    public void LoadLevel()
    {
        _mazeGyro.gameObject.SetActive(true);
        _ball.gameObject.SetActive(true);
    }

    private void Update()
    {
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
