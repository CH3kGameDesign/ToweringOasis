using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

// For knowing which state is player in
public enum PLAYERMODE {
	ATTACK,
	MOVE,
	IDLE,
	MENU,

	COUNT
}

public class PlayerController : Controller
{
	public bool m_debug;
	public Transform m_walkableprefab; // Surface that actors are allowed to walk on
	public Transform m_attackprefab; // Attack Tile
	public PLAYERMODE m_playerMode; // Current player state
	public float m_fPlayerMovementSpeed; // Speed at which player moves
    public bool m_showHealth;
    public GameObject m_SelectedPrefab;

    public Actor m_Player; // current Player
	public Transform m_ring = null;
	private Vector3 m_v3PlayerTilePos; // at what tile player is present specifically its position
	private int m_nLeftClick = 0; // To keep track of button inputs
	public bool m_bshowUI; // Show and hide move/attack buttons
    public bool m_bMoveTransparent;
    public List<ObjectsTransparent> m_objectsTransparent;

    Vector2 m_v2UiPosition; // Position Ui will spawn at

	private void Start()
	{
		m_playerMode = PLAYERMODE.IDLE;

		// Assign tiles actors and obstacles are on
		Map.Instance.UpdateUnitOnTop();
        m_Player = UnitManager.Instance.m_Parent[0].GetChild(0).GetComponent<Actor>();
        m_objectsTransparent = new List<ObjectsTransparent>();
        m_showHealth = true;
	}

	private void Update()
    {
        if (m_showHealth && m_Player.m_nHealth > 0)
        {
            GameManager.Instance.m_HealthBar.SetActive(true);
            GameManager.Instance.m_healthText.text = m_Player.m_classType;
            GameManager.Instance.m_healthGUI.m_CurrentHP = m_Player.m_nHealth / 10;
			GameManager.Instance.m_character.texture = m_Player.m_CharacterPotrait;
        }

        if (m_bshowUI)
        {
            SpriteState temp = new SpriteState();
            if (m_Player.m_classType == "support")
            {
                GameManager.Instance.m_actions.transform.GetChild(1).gameObject.GetComponent<Image>().sprite = GameManager.Instance.HealButtons[0];
                temp.pressedSprite = GameManager.Instance.HealButtons[0];
                temp.disabledSprite = GameManager.Instance.HealButtons[1];
                temp.highlightedSprite = GameManager.Instance.HealButtons[2];
            }
            else
            {
                GameManager.Instance.m_actions.transform.GetChild(1).gameObject.GetComponent<Image>().sprite = GameManager.Instance.AttackButtons[0];
                temp.pressedSprite = GameManager.Instance.AttackButtons[0];
                temp.disabledSprite = GameManager.Instance.AttackButtons[1];
                temp.highlightedSprite = GameManager.Instance.AttackButtons[2];
            }
            GameManager.Instance.m_actions.transform.GetChild(1).gameObject.GetComponent<Button>().spriteState = temp;
            if (m_Player.m_bMoved)
            {
                GameManager.Instance.m_actions.transform.GetChild(0).gameObject.GetComponent<Button>().interactable = false;
            }
            else
            {
                GameManager.Instance.m_actions.transform.GetChild(0).gameObject.GetComponent<Button>().interactable = true;
            }

            if (m_Player.m_bAttack)
            {
                GameManager.Instance.m_actions.transform.GetChild(1).gameObject.GetComponent<Button>().interactable = false;
            }
            else
            {
                GameManager.Instance.m_actions.transform.GetChild(1).gameObject.GetComponent<Button>().interactable = true;
            }

            if (m_Player.m_bSkip)
            {
                for (int i = 0; i < GameManager.Instance.m_actions.transform.childCount; i++)
                {
                    GameManager.Instance.m_actions.transform.GetChild(i).gameObject.SetActive(false);
                }
            }

            if (!m_Player.m_bAttack || !m_Player.m_bMoved)
            {
                if (m_Player.m_classType == "support")
                {
                    GameManager.Instance.m_actions.transform.GetChild(1).transform.GetChild(0).GetComponent<Text>().text = "Heal";
                }
                if (m_Player.m_classType == "melee" || m_Player.m_classType == "ranged")
                {
                    GameManager.Instance.m_actions.transform.GetChild(1).transform.GetChild(0).GetComponent<Text>().text = "Attack";
                }
                GameManager.Instance.m_actions.SetActive(true);
                Vector3 pos = m_Player.transform.position;
                pos.x -= 2.6f;
                pos.y += 2.3f;
                pos.z += 1.0f;
                GameManager.Instance.m_actions.transform.position = pos;
            }
        }
    }

    public override void myUpdate()
    {
        base.myUpdate();

		if (EventSystem.current.IsPointerOverGameObject())
			return;

		// Cast a ray and assign a hit variable
		RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

		if (m_Player != null)
		{
			m_ring = GameManager.Instance.GetChildObject(m_Player.transform, "Ring").GetChild(0);
			m_ring.gameObject.SetActive(true);
			if (m_Player.m_bMoved && m_Player.m_bAttack)
			{
				m_ring.GetComponent<MeshRenderer>().sharedMaterial = GameManager.Instance.m_redRing;
				//.material.SetTexture("RedRing", GameManager.Instance.m_redRing);
			}
			else
			{
				m_ring.GetComponent<MeshRenderer>().sharedMaterial = GameManager.Instance.m_whiteRing;
			}
		}

		// If ray hits something
		if (Physics.Raycast(ray, out hit))
        {
            // If its a player and leftclick is performed while m_nleftclick is 0
            if (hit.transform.CompareTag("Player") && Input.GetMouseButtonDown(0) && m_nLeftClick == 0 && !GameManager.Instance.m_isMoving)
            {
                if (m_Player != null)
                {
                    GameObject temp = m_Player.gameObject.transform.GetChild(2).gameObject;
                    if (temp.activeSelf == true)
                        temp.SetActive(false);
                }
				
				for (int i = 0; i < GameManager.Instance.m_actions.transform.childCount; i++)
				{
					GameManager.Instance.m_actions.transform.GetChild(i).gameObject.SetActive(true);
				}

				// Get its actor component, initialise its actorpos
				m_Player = hit.transform.GetComponent<Actor>();
                GameManager.Instance.m_currentActor = m_Player;
                m_v3PlayerTilePos = m_Player.m_ActorPos;
                m_v3PlayerTilePos.y = 0.1f;

                // Get the Player Pos
                m_v2UiPosition = Vector2.zero;
                m_v2UiPosition.x = Input.mousePosition.x;
                m_v2UiPosition.y = Screen.height - Input.mousePosition.y;

                // Show UI(attack/move buttons)
                if (m_Player != null)
                    m_bshowUI = true;

				m_playerMode = PLAYERMODE.MENU;

				m_SelectedPrefab = m_Player.gameObject.transform.GetChild(2).gameObject;
                m_showHealth = true;
            }

			if(!hit.transform.CompareTag("Player") && m_playerMode == PLAYERMODE.MENU && Input.GetMouseButtonDown(0) && m_nLeftClick == 0 && m_bshowUI == true)
			{
				m_bshowUI = false;

				m_playerMode = PLAYERMODE.IDLE;
				GameManager.Instance.m_actions.SetActive(false);
				m_SelectedPrefab.SetActive(false);
				m_showHealth = false;
				m_Player = null;
			}

            // If the hit is MoveableTile and leftclick is performed and m_nleftclick is 1
            if (hit.transform.CompareTag("MovableTile") && Input.GetMouseButtonDown(0) && m_nLeftClick == 1)
            {
				// We calculate the angle between mouse position and player position
				float angle = -Mathf.Atan2(m_v3PlayerTilePos.z - hit.transform.position.z, m_v3PlayerTilePos.x - hit.transform.position.x) * Mathf.Rad2Deg;
				if (angle < 0)
					angle += 360;

				//Debug.Log(angle);

				if (angle >= 180 && angle <= 350)
					m_Player.m_playAnimUP = true;
				else
					m_Player.m_playAnimUP = false;

				// Find the path from player to the tile that is clicked
				Pathfinding.Instance.FindPath(m_v3PlayerTilePos, hit.transform.position);

                m_Player.Move(Pathfinding.Instance.path);

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

				if(!m_debug)
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

                m_showHealth = false;
                GameManager.Instance.m_HealthBar.SetActive(false);
			}

			if (!hit.transform.CompareTag("MovableTile") && m_playerMode == PLAYERMODE.MOVE && Input.GetMouseButtonDown(0) && m_nLeftClick == 1)
			{
				// After we have reached the endTile destroy all moveable tiles
				for (int i = 0; i < GameManager.Instance.MoveableTileHolder.transform.childCount; i++)
				{
					Destroy(GameManager.Instance.MoveableTileHolder.transform.GetChild(i).gameObject);
				}

				// Assign tiles actors and obstacles are on
				Map.Instance.UpdateUnitOnTop();

				// Set player mode to idle and m_nLeftClick back to 0 
				m_playerMode = PLAYERMODE.IDLE;
				m_nLeftClick--;

				m_showHealth = false;
				GameManager.Instance.m_HealthBar.SetActive(false);
                m_bMoveTransparent = false;

            }

			// If player is in attack mode and we left click while m_nLeftClick is 1
			if (m_playerMode == PLAYERMODE.ATTACK && Input.GetMouseButtonDown(0) && m_nLeftClick == 1)
            {
                if (m_Player.m_whoWasAttacked != null)
                    m_Player.Attack();

				m_Player.m_attackAnimPlayed = false;
                GameObject[] temp = GameObject.FindGameObjectsWithTag("AttackTile");

                // we want to destroy previous spawned attack tiles
                for (int i = 0; i < temp.Length; i++)
                {
                    Destroy(temp[i]);
                }

				if (!m_debug)
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

                m_showHealth = false;
                GameManager.Instance.m_HealthBar.SetActive(false);
            }

            // If hold down the right click and m_player is not null
            if (m_Player != null)
            {
                if (m_SelectedPrefab != null)
                {
                    if (!m_SelectedPrefab.activeSelf)
                        m_SelectedPrefab.SetActive(true);
                }
                // Get the player position from screen
                Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(GameManager.Instance.GetChildObject(m_Player.transform, "Ring").transform.position);

                // and the mose position on the screen
                Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);

                // We calculate the angle between mouse position and player position
                float angle = Mathf.Atan2(positionOnScreen.y - mouseOnScreen.y, positionOnScreen.x - mouseOnScreen.x) * Mathf.Rad2Deg;

                // Set players rotation to that angle
                GameManager.Instance.GetChildObject(m_Player.transform, "Ring").rotation = Quaternion.Euler(new Vector3(0f, -angle, 0f));

                // Draw a line to debug player front
                Debug.DrawRay(GameManager.Instance.GetChildObject(m_Player.transform, "Ring").transform.position, GameManager.Instance.GetChildObject(m_Player.transform, "Ring").transform.forward * 5, Color.red);

				Vector3 tempPos = GameManager.Instance.GetChildObject(m_Player.transform, "Ring").position + GameManager.Instance.GetChildObject(m_Player.transform, "Ring").forward;

				m_Player.GetAttackTiles(
                    Map.Instance.GetNodeFromPosition(tempPos),
                    Map.Instance.GetNodeFromPosition(m_Player.m_ActorPos),
                    true);

				float angleA = -Mathf.Atan2(m_Player.m_ActorPos.z - tempPos.z, m_Player.m_ActorPos.x - tempPos.x) * Mathf.Rad2Deg;
				if (angleA < 0)
					angleA += 360;

				//Debug.Log(angleA);

				if (angleA >= 180 && angleA <= 350)
					m_Player.m_playAnimUP = true;
				else
					m_Player.m_playAnimUP = false;

				// If player is in attack mode
				if (m_playerMode == PLAYERMODE.ATTACK && m_Player.m_prevDirec != m_Player.m_lookingDirec)
                {
					m_Player.m_whoWasAttacked.Clear();
                    m_Player.SpawnAttackTiles(m_attackprefab, GameManager.Instance.AttackTileHolder);
                }
            }
        }

        if (m_bMoveTransparent)
        {
			GameObject parentObject = GameObject.Find("ObstacleModels");
			List<MeshRenderer> rend = new List<MeshRenderer>();

			for (int i = 0; i < parentObject.transform.childCount; i++)
			{
				MeshRenderer r;
				if (parentObject.transform.GetChild(i).GetComponent<MeshRenderer>() != null)
					r = parentObject.transform.GetChild(i).GetComponent<MeshRenderer>();
				else
					r = parentObject.transform.GetChild(i).GetComponentInChildren<MeshRenderer>();

				if (r.gameObject.name != "polySurface1" && r.gameObject.name != "polySurface2")
				{
					rend.Add(r);

					r.material.shader = GameManager.Instance.transparent;
					Color tmp = r.material.color;
					tmp.a = 0.3f;
					Collider tempCol;
					if (r.gameObject.GetComponent<Collider>() != null)
					{
						tempCol = r.gameObject.GetComponent<Collider>();
						tempCol.enabled = false;
					}
					else
						tempCol = null;

					m_objectsTransparent.Add(new ObjectsTransparent(parentObject.transform.GetChild(i).transform, r, tempCol, r.material.color));
					r.material.color = tmp;
				}
			}

			for (int j = 0; j < UnitManager.Instance.m_Parent[0].childCount; j++)
			{
				UnitManager.Instance.m_Parent[0].GetChild(j).GetComponent<Collider>().enabled = false;
			}

			for (int j = 0; j < UnitManager.Instance.m_Parent[1].childCount; j++)
			{
				UnitManager.Instance.m_Parent[1].GetChild(j).GetComponent<Collider>().enabled = false;
			}
			//RaycastHit temphit;
			//Ray tempRay = Camera.main.ScreenPointToRay(Input.mousePosition);
			//if (Physics.Raycast(tempRay, out temphit))
			//{
			//    if (m_objectsTransparent.Count > 0 && !hit.transform.CompareTag("MovableTile"))
			//    {
			//        for (int i = 0; i < m_objectsTransparent.Count; i++)
			//        {
			//            m_objectsTransparent[i].m_rend.material.shader = Shader.Find("Standard");
			//            m_objectsTransparent[i].m_rend.material.color = m_objectsTransparent[i].m_color;
			//            m_objectsTransparent[i].m_col.enabled = true;
			//            m_objectsTransparent.RemoveAt(i);
			//        }
			//    }
			//}

			////int layerMask = 1 << LayerMask.NameToLayer("Walkable");
			//int layerMask = ~LayerMask.GetMask("Walkable");// & ~LayerMask.GetMask("Walkable");

			//if (Physics.Raycast(tempRay, out temphit, 1000.0f, layerMask))
			//{
			//    Debug.Log(hit.collider.gameObject);
			//    if (temphit.transform != m_Player.transform && !hit.transform.CompareTag("MovableTile"))
			//    {
			//        MeshRenderer rend;
			//        if (temphit.transform.GetComponent<MeshRenderer>() != null)
			//            rend = temphit.transform.GetComponent<MeshRenderer>();
			//        else
			//            rend = temphit.transform.GetComponentInChildren<MeshRenderer>();

			//        rend.material.shader = Shader.Find("Transparent/Diffuse");
			//        Color tmp = rend.material.color;
			//        tmp.a = 0.3f;
			//        m_objectsTransparent.Add(new ObjectsTransparent(temphit.transform, rend, temphit.transform.GetComponent<Collider>(), rend.material.color));
			//        rend.material.color = tmp;
			//        temphit.transform.GetComponent<Collider>().enabled = false;
			//    }
			//}
		}
		else
		{
			if(m_objectsTransparent.Count > 0)
			{
				for (int i = 0; i < m_objectsTransparent.Count; i++)
				{
					m_objectsTransparent[i].m_rend.material.shader = GameManager.Instance.standard;
					m_objectsTransparent[i].m_rend.material.color = m_objectsTransparent[i].m_color;

					if(m_objectsTransparent[i].m_col != null)
						m_objectsTransparent[i].m_col.enabled = true;

					m_objectsTransparent.RemoveAt(i);
				}

				for (int j = 0; j < UnitManager.Instance.m_Parent[0].childCount; j++)
				{
					UnitManager.Instance.m_Parent[0].GetChild(j).GetComponent<Collider>().enabled = true;
				}

				for (int j = 0; j < UnitManager.Instance.m_Parent[1].childCount; j++)
				{
					UnitManager.Instance.m_Parent[1].GetChild(j).GetComponent<Collider>().enabled = true;
				}
			}
		}
	}

    public void Skip()
    {
        if (!m_Player.m_bSkip || (!m_Player.m_bAttack && !m_Player.m_bMoved))
        {
            m_Player.m_bMoved = true;
            m_Player.m_bAttack = true;
            m_Player.m_bSkip = true;
            m_bshowUI = false;
            GameManager.Instance.m_nPlayerMoves++;
        }
        GameManager.Instance.m_actions.SetActive(false);
        m_bshowUI = false;
        GameManager.Instance.m_HealthBar.SetActive(false);
    }

    public void Attack()
    {

        if (!m_Player.m_bAttack)
        {
            m_Player.SpawnAttackTiles(m_attackprefab, GameManager.Instance.AttackTileHolder);

            // Set mode to attack and turn of the UI and m_nLeftCLick to 1
            // Also calls the players attack
            m_playerMode = PLAYERMODE.ATTACK;
            m_bshowUI = false;
            m_nLeftClick++;
        }
        GameManager.Instance.m_actions.SetActive(false);
        m_bshowUI = false;
    }

    public void Move()
    {
        if (!m_Player.m_bMoved)
        {
            // Get the neighbours out player can move on
            List<Node> tiles = GetMovementTiles(Map.Instance.GetNodeFromPosition(m_v3PlayerTilePos), m_Player.m_nHowManyTiles);

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
            m_bMoveTransparent = true;
            m_playerMode = PLAYERMODE.MOVE;
            m_bshowUI = false;
            m_nLeftClick++;
        }

        GameManager.Instance.m_actions.SetActive(false);
        m_bshowUI = false;
    }   

    public List<Node> GetMovementTiles(Node node, int nHowManyNeighbourIteration = 1)
    {
        int i = 0;
        int gcost = 1;
        List<Node> moveTiles = new List<Node>();

        Heap<Node> openList = new Heap<Node>((int)Map.Instance.m_nGridSizeX * (int)Map.Instance.m_nGridSizeY);

        // Nodes we have already searched
        HashSet<Node> closedList = new HashSet<Node>();

        // Add our starting point on the openlist
        openList.Add(node);

        while (openList.Count > 0)
        {
            Node currentNode = openList.RemoveFirst();

            closedList.Add(currentNode);

            if (currentNode.m_nGCost > nHowManyNeighbourIteration || !currentNode.m_bWalkable)
                continue;

			if(currentNode != node)
				moveTiles.Add(currentNode);

			List<Node> Neighbours = Map.Instance.GetNeighbours(currentNode);

            foreach (Node neighbour in Neighbours)
            {
				if (!closedList.Contains(neighbour))
				{
					if (openList.Contains(neighbour))
					{
						if (!neighbour.m_bWalkable || neighbour.m_bIsUnitOnTop)
							continue;
						int tempGcost = currentNode.m_nGCost + gcost;

						if (tempGcost < neighbour.m_nGCost)
						{
							neighbour.m_parent = currentNode;
							neighbour.m_nGCost = tempGcost;
						}
					}
					else
					{
						if (neighbour != null)
						{
							if (!neighbour.m_bWalkable || neighbour.m_bIsUnitOnTop)
								continue;
							if (currentNode.m_nGCost + gcost > nHowManyNeighbourIteration)
								continue;
							neighbour.m_parent = currentNode;
							neighbour.m_nGCost = currentNode.m_nGCost + gcost;
							openList.Add(neighbour);
						}
					}
				}

				{
					//if (!neighbour.m_bWalkable || neighbour.m_bIsUnitOnTop || !closedList.Contains(neighbour))
					//	continue;

					//int newMovementCostToNeighbour = currentNode.m_nGCost + gcost;
					//if (newMovementCostToNeighbour < neighbour.m_nGCost || !openList.Contains(neighbour))
					//{
					//	neighbour.m_parent = currentNode;
					//	neighbour.m_nGCost = newMovementCostToNeighbour;
					//}

					//if (neighbour != null)
					//{
					//	if (currentNode.m_nGCost + gcost > nHowManyNeighbourIteration)
					//		continue;

					//	neighbour.m_nGCost = newMovementCostToNeighbour;
					//	neighbour.m_nHCost = currentNode.m_nGCost + gcost;
					//	neighbour.m_parent = currentNode;

					//	if (!openList.Contains(neighbour))
					//		openList.Add(neighbour);
					//	else
					//		openList.UpdateItem(neighbour);
					//}
				}
			}
		}

		i++;

		foreach (Node n in closedList)
		{
			n.m_nHCost = 0;
			n.m_nGCost = 0;
		}

		return moveTiles;
    }
}

