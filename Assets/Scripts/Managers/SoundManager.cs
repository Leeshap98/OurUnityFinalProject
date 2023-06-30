using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [SerializeField] AudioMixer _MusicMixer;
    [SerializeField] AudioMixer _SFXMixer;
    [SerializeField] Slider _MusicSlider;
    [SerializeField] Slider _SFXSlider;

    private bool _VibrationEnabled;

    public bool VibrationEnabled { get => _VibrationEnabled; }

    private void Awake()
    {
        Instance = this;
    }

    public void SetMusicVolume()
    {
        float volume = _MusicSlider.value;
        _MusicMixer.SetFloat("MusicVol", volume);
    }
    public void SetSFXVolume()
    {
        float volume = _SFXSlider.value;
        _SFXMixer.SetFloat("SFXVol", volume);
    }
    public void SetVib()
    {
        _VibrationEnabled = !_VibrationEnabled;
    }
}
