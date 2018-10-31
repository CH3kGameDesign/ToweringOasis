using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// For knowing which state is player in
public enum PLAYERMODE {
	ATTACK,
	MOVE,
	IDLE,

	COUNT
}

public class PlayerController : Controller
{
	public Transform m_walkableprefab; // Surface that actors are allowed to walk on
	public Transform m_attackprefab; // Attack Tile
	public PLAYERMODE m_playerMode; // Current player state
	public float m_fPlayerMovementSpeed; // Speed at which player moves

	public Actor m_Player; // current Player
	private Vector3 m_v3PlayerTilePos; // at what tile player is present specifically its position
	private int m_nLeftClick = 0; // To keep track of button inputs
	private bool m_bshowUI; // Show and hide move/attack buttons
	Vector2 m_v2UiPosition; // Position Ui will spawn at

	private void Start()
	{
		m_playerMode = PLAYERMODE.IDLE;

		// Assign tiles actors and obstacles are on
		Map.Instance.UpdateUnitOnTop();

	}

	private void Update()
	{

	}

    public override void myUpdate()
    {
        base.myUpdate();

        if (Input.GetKeyDown(KeyCode.O))
        {
            Actor[] players = GetComponentsInChildren<Actor>();
            foreach (Actor p in players)
            {
                p.m_nHealth = -10;
                UnitManager.Instance.m_nPlayersAlive--;
            }
        }

        // Cast a ray and assign a hit variable
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // If ray hits something
        if (Physics.Raycast(ray, out hit))
        {
            // If its a player and leftclick is performed while m_nleftclick is 0
            if (hit.transform.CompareTag("Player") && Input.GetMouseButtonDown(0) && m_nLeftClick == 0 && !GameManager.Instance.m_isMoving)
            {
                // Get its actor component, initialise its actorpos
                m_Player = hit.transform.GetComponent<Actor>();
                m_v3PlayerTilePos = m_Player.m_ActorPos;
                m_v3PlayerTilePos.y = 0.1f;

                // Get the Player Pos
                m_v2UiPosition = Vector2.zero;
                m_v2UiPosition.x = Input.mousePosition.x;
                m_v2UiPosition.y = Screen.height - Input.mousePosition.y;

                // Show UI(attack/move buttons)
                if (m_Player != null)
                    m_bshowUI = true;
            }

            // If the hit is MoveableTile and leftclick is performed and m_nleftclick is 1
            if (hit.transform.CompareTag("MovableTile") && Input.GetMouseButtonDown(0) && m_nLeftClick == 1)
            {
                // Find the path from player to the tile that is clicked
                Pathfinding.Instance.FindPath(m_v3PlayerTilePos, hit.transform.position);

                // Move to next node after seconds assigned as m_fPlayerMovementSpeed
                for (int i = 0; i < Pathfinding.Instance.path.Count; i++)
                {
                    m_Player.Move(Pathfinding.Instance.path);
                }

                // After we have reached the endTile destroy all moveable tiles
                for (int i = 0; i < GameManager.Instance.MoveableTileHolder.transform.childCount; i++)
                {
                    Destroy(GameManager.Instance.MoveableTileHolder.transform.GetChild(i).gameObject);
                }

                // If we wanna debug the path taken we draw it again after destroying every moveable tile
                if (Pathfinding.Instance.m_DebugPath)
                {
                    foreach (Node n in Pathfinding.Instance.path)
                    {
                        Vector3 tempPos = n.m_v3WorldPosition;
                        tempPos.y = 0.1f;
                        Transform tempWalkableTile = Instantiate(
                            m_walkableprefab,
                            tempPos,
                            Quaternion.Euler(Vector3.zero));

                        tempWalkableTile.parent = GameManager.Instance.MoveableTileHolder.transform;
                    }
                }

                m_Player.m_bMoved = true;

                if (m_Player != null && m_Player.m_bMoved && m_Player.m_bAttack)
                {
                    GameManager.Instance.m_nPlayerMoves++;
                }

                // Assign tiles actors and obstacles are on
                Map.Instance.UpdateUnitOnTop();

                // Set player mode to idle and m_nLeftClick back to 0 
                m_playerMode = PLAYERMODE.IDLE;
                m_nLeftClick--;
            }

            // If player is in attack mode and we left click while m_nLeftClick is 1
            if (m_playerMode == PLAYERMODE.ATTACK && Input.GetMouseButtonDown(0) && m_nLeftClick == 1)
            {
                if (m_Player.m_whoWasAttacked != null)
                    m_Player.Attack();

                GameObject[] temp = GameObject.FindGameObjectsWithTag("AttackTile");

                // we want to destroy previous spawned attack tiles
                for (int i = 0; i < temp.Length; i++)
                {
                    Destroy(temp[i]);
                }

                m_Player.m_bAttack = true;

                if (m_Player.m_bMoved && m_Player.m_bAttack)
                {
                    GameManager.Instance.m_nPlayerMoves++;
                }

                // Assign tiles actors and obstacles are on
                Map.Instance.UpdateUnitOnTop();
                
                // Set player mode to idle and m_nLeftClick back to 0 
                m_playerMode = PLAYERMODE.IDLE;
                m_nLeftClick--;
            }

            // If hold down the right click and m_player is not null
            if (m_Player != null)
            {
                // Get the player position from screen
                Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(m_Player.gameObject.transform.position);

                // and the mose position on the screen
                Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);

                // We calculate the angle between mouse position and player position
                float angle = Mathf.Atan2(positionOnScreen.y - mouseOnScreen.y, positionOnScreen.x - mouseOnScreen.x) * Mathf.Rad2Deg;

                // Set players rotation to that angle
                m_Player.gameObject.transform.rotation = Quaternion.Euler(new Vector3(0f, -angle, 0f));

                // Draw a line to debug player front
                Debug.DrawRay(m_Player.gameObject.transform.position, m_Player.gameObject.transform.forward * 5, Color.red);

                m_Player.GetAttackTiles(
                    Map.Instance.GetNodeFromPosition(m_Player.transform.position + m_Player.transform.forward),
                    Map.Instance.GetNodeFromPosition(m_Player.m_ActorPos),
                    true);

                // If player is in attack mode
                if (m_playerMode == PLAYERMODE.ATTACK && m_Player.m_prevDirec != m_Player.m_lookingDirec)
                {
                    m_Player.SpawnAttackTiles(m_attackprefab, GameManager.Instance.AttackTileHolder);
                }
            }
        }
    }

    private void OnGUI()
	{
		// If showUI is true
		if (m_bshowUI)
		{
			if (!m_Player.m_bMoved)
			{
				// Creates button and waits for input
				if (GUI.Button(new Rect(m_v2UiPosition.x, m_v2UiPosition.y, 100, 35), "Move"))
				{
					// Get the neighbours out player can move on
					List<Node> tiles = Map.Instance.GetNeighbours(Map.Instance.GetNodeFromPosition(m_v3PlayerTilePos), m_Player.m_nHowManyTiles);

					// Spawn a moveable tile on each node
					foreach (Node n in tiles)
					{
						Vector3 tempPos = n.m_v3WorldPosition;
						tempPos.y = 0.1f;
						Transform tempWalkableTile = Instantiate(
							m_walkableprefab,
							tempPos,
							Quaternion.Euler(Vector3.zero));
						tempWalkableTile.parent = GameManager.Instance.MoveableTileHolder.transform;
					}

					// Set mode to move and turn of the UI and m_nLeftCLick to 1
					m_playerMode = PLAYERMODE.MOVE;
					m_bshowUI = false;
					m_nLeftClick++;
				}
			}

			if (!m_Player.m_bAttack)
			{
				if (GUI.Button(new Rect(m_v2UiPosition.x, m_v2UiPosition.y + 40, 100, 35), "Attack"))
				{
					m_Player.SpawnAttackTiles(m_attackprefab, GameManager.Instance.AttackTileHolder);

					// Set mode to attack and turn of the UI and m_nLeftCLick to 1
					// Also calls the players attack
					m_playerMode = PLAYERMODE.ATTACK;
					m_bshowUI = false;
					m_nLeftClick++;
				}
			}

            if (!m_Player.m_bSkip)
            {
                if (GUI.Button(new Rect(m_v2UiPosition.x, m_v2UiPosition.y + 80, 100, 35), "Skip"))
                {
                    m_Player.m_bMoved = true;
                    m_Player.m_bAttack = true;
                    m_Player.m_bSkip = true;
                    m_bshowUI = false;
                    GameManager.Instance.m_nPlayerMoves++;
                }
            }
        }
	}
}

