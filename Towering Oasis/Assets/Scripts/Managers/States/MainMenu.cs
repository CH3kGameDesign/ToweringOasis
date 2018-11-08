using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : BaseState
{
	private void Start()
	{
		GameManager.Instance.m_stateName = GameStates.MAINMENU;
	}

    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            GameManager.Instance.m_MainMenuPanel.SetActive(false);
        }
    }

    private void FixedUpdate()
	{
		
	}
	
	//Load Scene "MainScene" when button is pressed
	public void PlayGameButtonOnClick()
	{
		int level = Random.Range(1, SceneManager.sceneCountInBuildSettings);
		GameManager.Instance.m_nLevelsLoaded.Add(level);
		SceneManager.LoadScene(level);
        GameManager.Instance.m_stateName = GameStates.GAME;
    }

    //Switch Panel to Settings Panel
    public void SettingsButtonOnClick()
	{
		GameManager.Instance.m_PrevMenu = GameManager.Instance.m_MainMenuPanel;
		GameManager.Instance.m_MainMenuPanel.SetActive(false);
		GameManager.Instance.m_SettingPanel.SetActive(true);
    }
        
    //Quit Game when button is pressed
    public void QuitGameOnClick()
    {
        Application.Quit();
    }
}
