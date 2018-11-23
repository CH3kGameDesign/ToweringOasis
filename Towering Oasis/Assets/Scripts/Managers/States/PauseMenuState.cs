using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuState : BaseState
{
	private void Start()
	{
		GameManager.Instance.m_stateName = GameStates.PAUSED;
	}

	private void FixedUpdate()
	{
		
	}
	
	//Load Scene "MainScene" when button is pressed
	public void ResumeButtonOnClick()
	{
		GameManager.Instance.m_PauseMenuPanel.SetActive(false);
		GameManager.Instance.m_bcontrolsAvailable = true;
        GameManager.Instance.m_stateName = GameStates.GAME;
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

        GameManager.Instance.ResetVariables();
        GameManager.Instance.m_isLevelLoading = true;
        SceneManager.LoadScene(level);

		GameManager.Instance.m_PauseMenuPanel.SetActive(false);
        GameManager.Instance.m_stateName = GameStates.GAME;
    }

	//Switch Panel to Settings Panel
	public void SettingsButtonOnClick()
	{
		GameManager.Instance.m_PrevMenu = GameManager.Instance.m_PauseMenuPanel;
		GameManager.Instance.m_PauseMenuPanel.SetActive(false);
		GameManager.Instance.m_SettingPanel.SetActive(true);
    }

	//Quit Game when button is pressed
	public void MenuOnClick()
    {
        GameManager.Instance.ResetGame();
        GameManager.Instance.ResetGUI();

        if (!GameManager.Instance.m_actions.activeSelf)
        {
            GameManager.Instance.m_actions.transform.position = new Vector3(-70, -70, -70);
            GameManager.Instance.m_actions.SetActive(true);
        }

        GameManager.Instance.m_PauseMenuPanel.SetActive(false);
        GameManager.Instance.m_MainMenuPanel.SetActive(true);
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

