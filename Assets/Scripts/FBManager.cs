using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Facebook.Unity;

public class FBManager : MonoBehaviour
{
    private void Awake()
    {
        // Initialize the Facebook SDK
        if (!FB.IsInitialized)
        {
            FB.Init(OnInitComplete, OnHideUnity);
        }
        else
        {
            FB.ActivateApp();
        }
    }

    private void OnInitComplete()
    {
        if (FB.IsInitialized)
        {
            FB.ActivateApp();
        }
        else
        {
            Debug.LogError("Failed to initialize the Facebook SDK");
        }
    }

    private void OnHideUnity(bool isGameShown)
    {
        if (!isGameShown)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void Login()
    {
        FB.LogInWithReadPermissions(callback: OnLoginComplete);
    }

    private void OnLoginComplete(ILoginResult result)
    {
        if (FB.IsLoggedIn)
        {
            // Access the user's access token
            AccessToken accessToken = AccessToken.CurrentAccessToken;
            string token = accessToken.TokenString;

            // Access the user's Facebook ID
            string userId = accessToken.UserId;

            Debug.Log("Logged in successfully!");
            Debug.Log("Access Token: " + token);
            Debug.Log("User ID: " + userId);

            // You can now use the access token and user ID to authenticate the user in your game or app
            // Call your own authentication API or perform any necessary actions here
        }
        else
        {
            Debug.Log("Failed to log in");
        }
    }
}