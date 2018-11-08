using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverState : BaseState
{
	private void Start()
	{
		GameManager.Instance.m_stateName = GameStates.GAMEOVER;
	}

	private void FixedUpdate()
	{
		
	}

	//Load Scene "MainScene" when button is pressed
	public void RestartButtonOnClick()
	{
		GameManager.Instance.m_nLevelsLoaded.Clear();

		int level = Random.Range(1, SceneManager.sceneCountInBuildSettings);
		GameManager.Instance.m_nLevelsLoaded.Add(level);
		SceneManager.LoadScene(level);

		GameManager.Instance.m_GameOverPanel.SetActive(false);
		GameManager.Instance.m_bcontrolsAvailable = true;
		GameManager.Instance.m_isGameOver = false;
        GameManager.Instance.m_stateName = GameStates.GAME;
    }

	//Switch Panel to Settings Panel
	public void SettingsButtonOnClick()
	{
		GameManager.Instance.m_PrevMenu = GameManager.Instance.m_GameOverPanel;
		GameManager.Instance.m_GameOverPanel.SetActive(false);
		GameManager.Instance.m_SettingPanel.SetActive(true);
	}

	//Quit Game when button is pressed
	public void MenuOnClick()
	{
		GameManager.Instance.m_GameOverPanel.SetActive(false);
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