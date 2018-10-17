using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameStates
{
	MAINMENU,
	SETTINGS,
	PAUSED,
	GAME,
	GAMEOVER,

	COUNT
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
	public GameStates m_currentState;

	public List<int> m_nLevelsLoaded;
	public int m_nPlayerMoves;
    public bool m_bcontrolsAvailable;
	public bool m_isGameOver;

	public GameObject m_MainMenuPanel;
	public GameObject m_PauseMenuPanel;
	public GameObject m_SettingPanel;
	public GameObject m_GameOverPanel;
	public GameObject m_PrevMenu;

	private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);

		m_nLevelsLoaded = new List<int>();
		m_bcontrolsAvailable = true;

		if (SceneManager.GetActiveScene().buildIndex != 0)
			DontDestroyOnLoad(transform.gameObject);
	}

	private void Update()
	{
		if(m_nPlayerMoves >= 4)
		{
			m_bcontrolsAvailable = false;
			Transform Player = UnitManager.Instance.m_Parent[0];

			for (int i = 0; i < Player.childCount; i++)
			{
				Actor p = Player.GetChild(i).GetComponent<Actor>();
				p.m_bAttack = false;
				p.m_bMoved = false;
			}
		}
	}

	public void OnApplicationQuit()
	{
		Instance = null;
	}
}
