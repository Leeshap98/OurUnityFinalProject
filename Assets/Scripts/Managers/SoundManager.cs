using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [SerializeField] AudioMixer _MusicMixer;
    [SerializeField] AudioMixer _SFXMixer;

    private bool _VibrationEnabled;

    public bool VibrationEnabled { get => _VibrationEnabled;}

    private void Awake()
    {
        Instance = this;
    }
    public void SetMusicVolume(float volume)
    {
        _MusicMixer.SetFloat("volume", volume);
    }
    public void SetSFXVolume(float volume)
    {
        _SFXMixer.SetFloat("SFXvolume", volume);
    }
    public void SetSound(bool isFullScreen)
    {
        _MusicMixer.SetFloat("volume", 0);
        _SFXMixer.SetFloat("volume", 0);
    }
    public void SetVib(bool IsVib)
    {
        _VibrationEnabled = !_VibrationEnabled;
    }
}
