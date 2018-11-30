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

        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            
        }
    }

    private void FixedUpdate()
	{
		
	}
	
	//Load Scene "MainScene" when button is pressed
	public void PlayGameButtonOnClick()
	{
        GameManager.Instance.ResetGame();
        GameManager.Instance.ResetGUI();
        GameManager.Instance.m_levelSet = 1;
		int level = Random.Range(1, 21);
		//int level = Random.Range(1, SceneManager.sceneCount);
		GameManager.Instance.m_nLevelsLoaded.Add(level);
        GameManager.Instance.m_isLevelLoading = true;
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

    public void CreditsButtonOnClick()
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
        SceneManager.LoadScene(67);
        GameManager.Instance.m_stateName = GameStates.MAINMENU;
    }

        //Quit Game when button is pressed
        public void QuitGameOnClick()
    {
        Application.Quit();
    }
}
