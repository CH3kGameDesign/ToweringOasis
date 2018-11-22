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
            int level;

            if (GameManager.Instance.m_levelSet == 1)
                level = Random.Range(1, 21);
            else if (GameManager.Instance.m_levelSet == 2)
                level = Random.Range(22, 35);
            else if (GameManager.Instance.m_levelSet == 3)
                level = Random.Range(36, 49);
            else if (GameManager.Instance.m_levelSet == 4)
                level = Random.Range(50, 63);
            else if (GameManager.Instance.m_levelSet == 5)
                level = Random.Range(64, 67);
            else
                level = 0;

            if (!GameManager.Instance.m_nLevelsLoaded.Contains(level))
            {
                GameManager.Instance.m_nLevelsLoaded.Add(level);
                if(GameManager.Instance.m_nLevelsLoaded.Count == 3)
                {
                    GameManager.Instance.m_nLevelsLoaded.Clear();
                    if(GameManager.Instance.m_levelSet < 5)
                        GameManager.Instance.m_levelSet++;

                }
                GameManager.Instance.m_isLevelLoading = true;
                SceneManager.LoadScene(level);
                islevelLoaded = true;
                continue;
            }
            islevelLoaded = false;
        }

        islevelLoaded = false;
        GameManager.Instance.m_LevelWonPanel.SetActive(false);
        GameManager.Instance.m_stateName = GameStates.GAME;
        GameManager.Instance.ResetGame();
        GameManager.Instance.ResetGUI();
    }

    //Load Scene "MainScene" when button is pressed
    public void RestartButtonOnClick()
    {
        GameManager.Instance.ResetGame();
        GameManager.Instance.ResetGUI();
        GameManager.Instance.m_nLevelsLoaded.Clear();

        int level;

        level = Random.Range(1, 21);

        GameManager.Instance.m_nLevelsLoaded.Add(level);
        GameManager.Instance.m_isLevelLoading = true;
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
        GameManager.Instance.ResetGame();
        GameManager.Instance.ResetGUI();

        Destroy(GameManager.Instance.m_actions);

        GameManager.Instance.m_LevelWonPanel.SetActive(false);
        Destroy(transform.parent.gameObject);
        GameManager.Instance.m_isLevelLoading = true;
        SceneManager.LoadScene(0);
        GameManager.Instance.m_stateName = GameStates.MAINMENU;
    }

    //Quit Game when button is pressed
    public void QuitGameOnClick()
    {
        Application.Quit();
    }
}
