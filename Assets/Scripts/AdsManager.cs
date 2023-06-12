using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour
{
    private const string ANDROID_GAME_ID = "5308669";
    private const string IOS_GAME_ID = "5308668";

    void Start()
    {
       // Advertisement.Initialize(GetPlatformGameCode);
    }

    //string GetPlatformGameCode()
    //{
      //  #if UNITY_IOS
      //     _gameId = _iOSGameId;
      //  #elif UNITY_ANDROID
      //  _gameId = _androidGameId;
      //  #elif UNITY_EDITOR
    //}
}
