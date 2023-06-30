using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject _StartPanel;
    [SerializeField] GameObject _OptionsPanel;
    [SerializeField] GameObject _CreditsPanel;
  

    public void startOn()
    {
        _StartPanel.SetActive(true);
        _OptionsPanel.SetActive(false);
        _CreditsPanel.SetActive(false);
    }
    public void optionsOn()
    {
        _StartPanel.SetActive(false);
        _OptionsPanel.SetActive(true);
        _CreditsPanel.SetActive(false);
    }
    public void creditsOn()
    {
        _StartPanel.SetActive(false);
        _OptionsPanel.SetActive(false);
        _CreditsPanel.SetActive(true);
    }
}
