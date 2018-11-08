using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelWon : BaseState
{
    bool islevelLoaded = false;

    private void Start()
    {
        GameManager.Instance.m_stateName = GameStates.LEVELWON;
    }

    private void FixedUpdate()
    {

    }

    public void NextLevel()
    {
        while (!islevelLoaded)
        {
            int level = Random.Range(1, SceneManager.sceneCountInBuildSettings);
            if (!GameManager.Instance.m_nLevelsLoaded.Contains(level))
            {
                GameManager.Instance.m_nLevelsLoaded.Add(level);
                SceneManager.LoadScene(level);
                islevelLoaded = true;
                continue;
            }
            islevelLoaded = false;
        }

        islevelLoaded = false;
        GameManager.Instance.m_LevelWonPanel.SetActive(false);
        GameManager.Instance.m_stateName = GameStates.GAME;
    }

    //Load Scene "MainScene" when button is pressed
    public void RestartButtonOnClick()
    {
        GameManager.Instance.m_nLevelsLoaded.Clear();

        int level = Random.Range(1, SceneManager.sceneCountInBuildSettings);
        GameManager.Instance.m_nLevelsLoaded.Add(level);
        SceneManager.LoadScene(level);

        GameManager.Instance.m_LevelWonPanel.SetActive(false);
        GameManager.Instance.m_bcontrolsAvailable = true;
        GameManager.Instance.m_stateName = GameStates.GAME;
    }

    //Switch Panel to Settings Panel
    public void SettingsButtonOnClick()
    {
        GameManager.Instance.m_PrevMenu = GameManager.Instance.m_GameOverPanel;
        GameManager.Instance.m_LevelWonPanel.SetActive(false);
        GameManager.Instance.m_SettingPanel.SetActive(true);
        GameManager.Instance.m_stateName = GameStates.SETTINGS;
    }

    //Quit Game when button is pressed
    public void MenuOnClick()
    {
        GameManager.Instance.m_LevelWonPanel.SetActive(false);
        Destroy(transform.parent.gameObject);
        SceneManager.LoadScene(0);
        GameManager.Instance.m_stateName = GameStates.MAINMENU;
    }

    //Quit Game when button is pressed
    public void QuitGameOnClick()
    {
        Application.Quit();
    }
}
