using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject startPanel;
    [SerializeField] GameObject optionsPanel;
    [SerializeField] GameObject creditsPanel;
    [SerializeField] AudioMixer MusicMixer;
    [SerializeField] AudioMixer SFXMixer;

  

    public void startOn()
    {
        startPanel.SetActive(true);
        optionsPanel.SetActive(false);
        creditsPanel.SetActive(false);
    }
    public void optionsOn()
    {
        startPanel.SetActive(false);
        optionsPanel.SetActive(true);
        creditsPanel.SetActive(false);
    }
    public void creditsOn()
    {
        startPanel.SetActive(false);
        optionsPanel.SetActive(false);
        creditsPanel.SetActive(true);
    }
    public void SetMusicVolume(float volume)
    {
        MusicMixer.SetFloat("volume", volume);
    }
    public void SetSFXVolume(float volume)
    {
        SFXMixer.SetFloat("volume", volume);
    }
    public void SetSound(bool isFullScreen)
    {
        MusicMixer.SetFloat("volume", 0);
        SFXMixer.SetFloat("volume", 0);
    }
    //public void SetVib(bool IsVib)
    //{

    //}
}
