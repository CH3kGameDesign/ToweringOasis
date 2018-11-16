﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum GameStates
{
	MAINMENU,
	SETTINGS,
	PAUSED,
	GAME,
	GAMEOVER,
    LEVELWON,

	COUNT
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameStates m_stateName;
    public Transform MoveableTileHolder; // Empty object to hold moveable tiles
	public Transform AttackTileHolder; // Empty object to hold attack tiles
    public EnemyController enemyController;
    public PlayerController playerController;
    public Boss m_boss;

    public List<int> m_nLevelsLoaded;
    public Actor m_currentActor;
    public int m_nPlayerMoves;
	public int m_nEnemiesMoves;
	public bool m_nEnemiesAttacked;
	public bool m_bcontrolsAvailable;
	public bool m_isGameOver;
	public bool m_isMoving;
	public bool m_isAttacking;
    public Material m_whiteRing;
    public Material m_redRing;
    public bool m_bossTurned;
    public int m_LevelsPerSet;
    public int m_levelSet;

    public GameObject m_GameGUI;
    public HealthBar m_healthGUI;
	public RawImage m_character;
    public Text m_healthText;
    public Text m_EnemiesNumber;
    public Text m_Turn;

    public ButtonActor[] ButtonActor;

    public GameObject m_MainMenuPanel;
	public GameObject m_PauseMenuPanel;
	public GameObject m_SettingPanel;
	public GameObject m_GameOverPanel;
	public GameObject m_LevelWonPanel;
	public GameObject m_HealthBar;
    public GameObject m_actions;
    public GameObject m_PrevMenu;

	private void Awake()
    {
        m_bossTurned = false;
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);

        m_actions.SetActive(false);

		// Initalise defaults
		MoveableTileHolder = new GameObject("MoveableTileHolder").transform;
		AttackTileHolder = new GameObject("AttackTileHolder").transform;
        m_healthGUI = m_HealthBar.GetComponentInChildren<HealthBar>();
        m_healthText = m_HealthBar.GetComponentInChildren<Text>();

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
        m_boss = FindObjectOfType<Boss>();

        if (enemyController == null)
        {
            enemyController = FindObjectOfType<EnemyController>();
        }
        else if (playerController == null)
        {
            playerController = FindObjectOfType<PlayerController>();
        }

        if (m_GameGUI.activeSelf)
        {
            for (int i = 0; i < UnitManager.Instance.m_Parent.Count; i++)
            {
                ButtonActor[i].m_ActorNumber = i;
            }
        }
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            if (m_GameGUI.activeSelf == false)
                m_GameGUI.SetActive(true);

            m_EnemiesNumber.text = "Enemies: " + UnitManager.Instance.m_Parent[1].childCount;

            if (m_bcontrolsAvailable)
                m_Turn.text = "Player's Turn";
            else if(!m_bcontrolsAvailable)
                m_Turn.text = "Enemies Turn";

            if (Input.GetKeyDown(KeyCode.P))
                m_bcontrolsAvailable = !m_bcontrolsAvailable;

            if (Input.GetKeyDown(KeyCode.I))
            {
                Actor[] players = playerController.GetComponentsInChildren<Actor>();
                foreach (Actor p in players)
                {
                    p.m_nDamage = 100;
                }
            }

            if (Input.GetKeyDown(KeyCode.U))
            {
                Actor[] enemies = enemyController.GetComponentsInChildren<Actor>();
                foreach (Actor e in enemies)
                {
                    e.m_nHealth = -10;
                }
            }

            if (Input.GetKeyDown(KeyCode.O))
            {
                Actor[] players = playerController.GetComponentsInChildren<Actor>();
                foreach (Actor p in players)
                {
                    p.m_nHealth = -10;
                    UnitManager.Instance.m_nPlayersAlive--;
                    m_isGameOver = true;
                }
            }

            if (Input.GetKeyDown(KeyCode.Y))
            {
                UnitManager.Instance.m_Parent[0].GetChild(0).GetComponent<Actor>().m_nHealth = 0;
            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                UnitManager.Instance.m_nPlayersAtExit = 4;
            }

            if (m_bcontrolsAvailable && playerController != null)
            {
                m_bossTurned = false;
                playerController.myUpdate();
            }
            else if (!m_bcontrolsAvailable && enemyController != null && !m_isGameOver)
            {
                if (!m_bossTurned && m_boss != null)
                {
                    m_boss.myUpdate();
                    m_bossTurned = true;
                }
                enemyController.myUpdate();
            }
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

    public void ResetVariables()
    {
        m_bcontrolsAvailable = true;
        m_nEnemiesAttacked = false;
        m_nPlayerMoves = 0;
        m_nEnemiesMoves = 0;
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

    public void GUIReset()
    {
        ButtonActor[UnitManager.Instance.m_Parent.Count].gameObject.SetActive(false);
    }
}
