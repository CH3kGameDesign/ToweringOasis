using System.Collections;
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
    public bool m_isLevelLoading;

    public HealthBar m_healthGUI;
	public RawImage m_character;
    public Text m_healthText;
    public Text m_EnemiesNumber;
    public Text m_Turn;

    public ButtonActor[] ButtonActor;

    public Sprite[] AttackButtons;
    public Sprite[] HealButtons;

    public GameObject m_MainMenuPanel;
	public GameObject m_PauseMenuPanel;
	public GameObject m_SettingPanel;
	public GameObject m_GameOverPanel;
	public GameObject m_LevelWonPanel;
	public GameObject m_HealthBar;
    public GameObject m_actions;
    public GameObject m_PrevMenu;
    public GameObject m_GameGUI;

    public List<AudioClip> levelMusic;
    public List<AudioClip> levelAmbience;

    private void Awake()
    {
        m_bossTurned = false;
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);

        m_isLevelLoading = false;
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
	}

    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            enemyController = FindObjectOfType<EnemyController>();
            playerController = FindObjectOfType<PlayerController>();
        }
        else
        {
            GetComponent<AudioSource>().clip = levelMusic[Random.Range(0, 4)];
            GetComponent<AudioSource>().Play();
        }
    }

    private void Update()
    {
        if (m_actions == null)
        {
            m_actions = GameObject.Find("Actions");
        }

        m_boss = FindObjectOfType<Boss>();

        if (enemyController == null)
        {
            enemyController = FindObjectOfType<EnemyController>();
        }

        else if (playerController == null)
        {
            playerController = FindObjectOfType<PlayerController>();
        }

        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
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
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
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

    public void ResetGame()
    {
        m_currentActor = null;
        m_nPlayerMoves = 0;
        m_nEnemiesMoves = 0;
        m_nEnemiesAttacked = false;
        m_bcontrolsAvailable = true;
        m_isGameOver = false;
        m_isMoving = false;
        m_isAttacking = false;
    }

    public void ResetGUI()
    {
        m_GameGUI.SetActive(false);
        m_GameOverPanel.SetActive(false);
        m_LevelWonPanel.SetActive(false);
        m_HealthBar.SetActive(false);
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

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        List<GameObject> temp = new List<GameObject>();
        temp.AddRange(GameObject.FindGameObjectsWithTag("AttackTile"));
        temp.AddRange(GameObject.FindGameObjectsWithTag("MovableTile"));

        // we want to destroy previous spawned attack tiles
        for (int i = 0; i < temp.Count; i++)
        {
            Destroy(temp[i]);
        }

        for (int i = 0; i < ButtonActor.Length; i++)
        {
			if (UnitManager.Instance.m_Parent[0] != null)
			{
				ButtonActor[i].GetComponent<Button>().interactable = true;
				ButtonActor[i].GetActor();
			}
        }
		m_actions.transform.position = new Vector3(-70, -70, -70);
        ResetGame();
        ResetGUI();

		if (UnitManager.Instance.m_Parent[0] != null)
			m_GameGUI.SetActive(true);
        AudioSource[] aSources = GetComponents<AudioSource>();
        
        if (aSources[0].clip != levelMusic[m_levelSet - 1])
        {
            aSources[0].clip = levelMusic[m_levelSet - 1];
            aSources[0].Play();
            aSources[1].clip = levelAmbience[m_levelSet - 1];
            aSources[1].Play();
        }
		m_isLevelLoading = false;
    }

    public Transform GetChildObject(Transform parent, string _tag)
    {
        for (int i = 0; i < parent.childCount; i++)
        {
            Transform child = parent.GetChild(i);
            if (child.tag == _tag)
            {
                return parent.GetChild(i);
            }
        }

        return null;
    }
}
