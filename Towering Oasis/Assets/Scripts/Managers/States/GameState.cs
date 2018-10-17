using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState : BaseState
{
	bool islevelLoaded = false;

	private void Start()
	{
		m_stateName = GameStates.GAME;
		GameManager.Instance.m_PauseMenuPanel.SetActive(false);
		GameManager.Instance.m_SettingPanel.SetActive(false);
		GameManager.Instance.m_GameOverPanel.SetActive(false);
	}

	private void FixedUpdate()
	{
		if (!GameManager.Instance.m_isGameOver)
		{
			if (UnitManager.Instance.m_nPlayersAtExit == 4)
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
			}
			else if (UnitManager.Instance.m_nPlayersAlive <= 0)
			{
				GameManager.Instance.m_GameOverPanel.SetActive(true);
				GameManager.Instance.m_isGameOver = true;
			}

			if (Input.GetKeyDown(KeyCode.Escape))
			{
				GameManager.Instance.m_PauseMenuPanel.SetActive(true);
				GameManager.Instance.m_bcontrolsAvailable = false;
			}
		}
	}
}