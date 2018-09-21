﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Seizon
{
    public class MainMenu : MonoBehaviour
    {
        //Get Panels for Switching
        public GameObject m_MainMenuPanel;
        public GameObject m_SettingPanel;

        //Load Scene "MainScene" when button is pressed
        public void PlayGameButtonOnClick()
        {
            SceneManager.LoadScene("Main");
        }

        //Switch Panel to Settings Panel
        public void SettingsButtonOnClick()
        {
            m_MainMenuPanel.SetActive(false);
            m_SettingPanel.SetActive(true);
        }
        
        //Quit Game when button is pressed
        public void QuitGameOnClick()
        {
            Application.Quit();
        }
    }
}
