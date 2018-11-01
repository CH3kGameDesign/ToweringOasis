﻿using System.Collections;
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
	public Transform MoveableTileHolder; // Empty object to hold moveable tiles
	public Transform AttackTileHolder; // Empty object to hold attack tiles
    public EnemyController enemyController;
    public PlayerController playerController;

    public List<int> m_nLevelsLoaded;
	public int m_nPlayerMoves;
	public int m_nEnemiesMoves;
	public bool m_nEnemiesAttacked;
	public bool m_bcontrolsAvailable;
	public bool m_isGameOver;
	public bool m_isMoving;
	public bool m_isAttacking;

    public GameObject m_MainMenuPanel;
	public GameObject m_PauseMenuPanel;
	public GameObject m_SettingPanel;
	public GameObject m_GameOverPanel;
	public GameObject m_actions;
    public GameObject m_PrevMenu;

	private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);

        m_actions.SetActive(false);

		// Initalise defaults
		MoveableTileHolder = new GameObject("MoveableTileHolder").transform;
		AttackTileHolder = new GameObject("AttackTileHolder").transform;

        MoveableTileHolder.parent = transform;
        AttackTileHolder.parent = transform;

        m_nLevelsLoaded = new List<int>();
		m_bcontrolsAvailable = true;
        
	    DontDestroyOnLoad(transform.gameObject);
	}

    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            enemyController = FindObjectOfType<EnemyController>();
            playerController = FindObjectOfType<PlayerController>();
        }
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex != 0)
        { 
            if (Input.GetKeyDown(KeyCode.P))
                m_bcontrolsAvailable = !m_bcontrolsAvailable;

            if(enemyController == null)
            {
                enemyController = FindObjectOfType<EnemyController>();
            }
            else if (playerController == null)
            {
                playerController = FindObjectOfType<PlayerController>();
            }

            if (m_bcontrolsAvailable && playerController != null)
                playerController.myUpdate();
            else if (!m_bcontrolsAvailable && enemyController != null)
                enemyController.myUpdate();
        }
    }

    private void LateUpdate()
	{
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            if (UnitManager.Instance.m_Parent.Count == 0)
                return;

            if (m_nPlayerMoves == UnitManager.Instance.m_Parent[0].childCount && !m_isMoving && m_bcontrolsAvailable)
            {
                Transform Player = UnitManager.Instance.m_Parent[0];

                for (int i = 0; i < Player.childCount; i++)
                {
                    Actor p = Player.GetChild(i).GetComponent<Actor>();

                    StartCoroutine(Wait(p));
                }

                m_bcontrolsAvailable = false;
                m_nEnemiesAttacked = false;
                m_nPlayerMoves = 0;
                m_nEnemiesMoves = 0;
            }
            // this happens before attacktile trigger enter
            if (m_nEnemiesMoves == UnitManager.Instance.m_Parent[1].childCount && m_nEnemiesAttacked && !m_bcontrolsAvailable)
            {
                Transform Enemies = UnitManager.Instance.m_Parent[1];
                for (int i = 0; i < Enemies.childCount; i++)
                {
                    Actor e = Enemies.GetChild(i).GetComponent<Actor>();

                    e.m_bAttack = false;
                    e.m_bMoved = false;
                }

                m_bcontrolsAvailable = true;
                m_nEnemiesAttacked = false;
                m_nPlayerMoves = 0;
                m_nEnemiesMoves = 0;
            }
        }
	}

	public void OnApplicationQuit()
	{
		Instance = null;
	}

	IEnumerator Wait(Actor p)
	{
		yield return new WaitForSeconds(0.3f);
        p.m_bAttack = false;
        p.m_bMoved = false;
        p.m_bSkip = false;
    }
}
