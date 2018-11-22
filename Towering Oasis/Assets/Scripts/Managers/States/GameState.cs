using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState : BaseState
{
	private void Start()
	{
		GameManager.Instance.m_stateName = GameStates.GAME;
		GameManager.Instance.m_PauseMenuPanel.SetActive(false);
		GameManager.Instance.m_SettingPanel.SetActive(false);
		GameManager.Instance.m_GameOverPanel.SetActive(false);
	}

	private void LateUpdate()
	{
        if (SceneManager.GetActiveScene().buildIndex != 0 && GameManager.Instance.m_stateName == GameStates.GAME && !GameManager.Instance.m_isLevelLoading)
        {
            if (UnitManager.Instance.m_nPlayersAlive <= 0)
            {
                GameManager.Instance.m_GameOverPanel.SetActive(true);
                GameManager.Instance.m_isGameOver = true;
                GameManager.Instance.m_stateName = GameStates.GAMEOVER;
                GameManager.Instance.m_GameGUI.SetActive(false);
                GameManager.Instance.ResetVariables();
            }

            else if (UnitManager.Instance.m_nPlayersAtExit == UnitManager.Instance.m_nPlayersAlive)
            {
                GameManager.Instance.m_LevelWonPanel.SetActive(true);
                GameManager.Instance.ResetVariables();
                GameManager.Instance.m_stateName = GameStates.LEVELWON;
                GameManager.Instance.m_GameGUI.SetActive(false);
            }

            else if (UnitManager.Instance.m_Parent[1].childCount <= 0)
            {
                GameManager.Instance.m_LevelWonPanel.SetActive(true);
                GameManager.Instance.ResetVariables();
                GameManager.Instance.m_stateName = GameStates.LEVELWON;
                GameManager.Instance.m_GameGUI.SetActive(false);
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                GameManager.Instance.m_PauseMenuPanel.SetActive(true);
            }
        }
	}
}