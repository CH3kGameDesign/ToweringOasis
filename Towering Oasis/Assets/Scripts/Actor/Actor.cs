using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DirectionEnum
{
	UPDOWN,
	RIGHTLEFT,
	DIAGNOL
}

public class Actor : MonoBehaviour
{
	// Health popup text and animation
	public Transform m_HealthDropPrefab;
    public Transform m_HealthDropBorderPrefab;
	[HideInInspector]
	public Transform m_ActorPrefab;
	[HideInInspector]
	public Renderer m_ActorRenderer;
	[HideInInspector]
	public Vector3 m_ActorPos;
	public string m_classType;
	public bool m_playAnimUP;
	public bool m_attackAnimPlayed;

	// How many tiles is this actor allowed to move
	public int m_nHowManyTiles;
	public int m_nHealth;
    public int m_nDamage;
	public int m_nSpeed;
	public List<Node> m_currentPath;
	public bool m_bMoved;
	public bool m_bAttack;
	public bool m_bExecuteMove;
	public bool m_bSkip;
    public bool m_bStartAttack;
    public DirectionEnum m_lookingDirec;
	public DirectionEnum m_prevDirec;
	public bool m_bLookingDiaganol = false;
	public Texture2D m_CharacterPotrait;
    private float m_nTimer;
	private float m_calculatedSpeed;
	private Vector3 m_v3CurrentPosHolder;
	private Vector3 m_v3StartingPos;
	private int m_nCurrentNode;


	// Character that this character is attacked by
	//[HideInInspector]
	public List<Actor> m_whoWasAttacked = new List<Actor>();
    public List<Node> individualPath = new List<Node>();


	public virtual void Start()
	{
        // Assigning default values
        m_nTimer = 0;
		m_ActorPrefab = this.transform;
		m_ActorRenderer = GetComponent<Renderer>();
		m_ActorPos = m_ActorPrefab.position;
	}

	public virtual void Update()
	{
        if (m_nHealth > 100)
            m_nHealth = 100;
		// if health is 0 destroy the gameobject
		if (m_nHealth <= 0)
		{
			UnitManager.Instance.m_Objects.Remove(gameObject.transform);
            if (this.CompareTag("Player"))
                UnitManager.Instance.m_nPlayersAlive--;
            Destroy(gameObject);
        }
        if(m_nTimer <= 0)
        {
            Material temp = this.transform.GetChild(0).GetComponentInChildren<Renderer>().material;
            temp.SetFloat("_Animation", 1);
            temp.SetFloat("_FrameRate", 24);
            temp.SetFloat("_Frames", 5);
            m_nTimer = 1000f;
        }
        m_nTimer -= Time.deltaTime;
		if (m_bExecuteMove)
		{
			m_calculatedSpeed += Time.deltaTime * m_nSpeed;
			if(this.gameObject.transform.position != m_v3CurrentPosHolder)
			{
				gameObject.transform.position = Vector3.Lerp(m_v3StartingPos, m_v3CurrentPosHolder, m_calculatedSpeed);
				m_ActorPos = m_v3CurrentPosHolder;
			}
			else
			{
				if(m_nCurrentNode < m_currentPath.Count - 1)
				{
					m_nCurrentNode++;
					CheckNode();
				}
				else if(m_nCurrentNode == m_currentPath.Count - 1)
				{
					m_bExecuteMove = false;
					m_bStartAttack = true;
					m_nCurrentNode = 0;

					if(gameObject.CompareTag("Player"))
						GameManager.Instance.m_isMoving = false;

					Map.Instance.UpdateUnitOnTop();

					Material temp = this.transform.GetChild(0).GetComponentInChildren<Renderer>().material;
					temp.SetFloat("_Animation", 1);
					temp.SetFloat("_FrameRate", 24);
					temp.SetFloat("_Frames", 5);
				}
			}
		}
    }

	public virtual void Attack()
	{
		Material temp = this.transform.GetChild(0).GetComponentInChildren<Renderer>().material;
		if (!m_attackAnimPlayed)
		{
			if (m_classType == "melee")
			{
				if (m_playAnimUP)
					temp.SetFloat("_Animation", 7);
				else
					temp.SetFloat("_Animation", 6);

				temp.SetFloat("_FrameRate", 24);
				temp.SetFloat("_Frames", 5);
			}
			else if (m_classType == "support")
			{
				if (m_playAnimUP)
					temp.SetFloat("_Animation", 3);
				else
					temp.SetFloat("_Animation", 2);
				
				temp.SetFloat("_FrameRate", 24);
				temp.SetFloat("_Frames", 5);
			}
			else if (m_classType == "ranged")
			{
				if (m_playAnimUP)
					temp.SetFloat("_Animation", 5);
				else
					temp.SetFloat("_Animation", 4);

				temp.SetFloat("_FrameRate", 24);
				temp.SetFloat("_Frames", 4);
			}
			m_attackAnimPlayed = true;
		}

		if (m_whoWasAttacked.Count > 0)
		{
			Debug.Log("A Step 1");
            foreach (Actor actor in m_whoWasAttacked)
			{
				Debug.Log("A Step 2");

				// Deduct health by the damage of the attacker
				actor.m_nHealth -= this.m_nDamage;

				Debug.Log("A Step 3");
				// Create Health popup and set text which is equal to this actor's health
				Transform HealthDrop = Instantiate(m_HealthDropBorderPrefab, actor.transform.position, Quaternion.Euler(40, 140, 0), actor.transform);
                Transform HealthDrop2 = Instantiate(m_HealthDropPrefab, actor.transform.position, Quaternion.Euler(40.02f, 140, 0), actor.transform);
                Transform HealthDrop3 = Instantiate(m_HealthDropPrefab, actor.transform.position, Quaternion.Euler(39.98f, 140, 0), actor.transform);

                int tempint = -m_nDamage;
				HealthDrop.GetComponent<TextMesh>().text = tempint.ToString();
                HealthDrop3.GetComponent<TextMesh>().text = tempint.ToString();
                HealthDrop2.GetComponent<TextMesh>().text = tempint.ToString();
                if(m_classType != "support")
                    ScreenShake.Instance.shakeTimer = 0f;
                Debug.Log("A Step 4");
			}
		}
		this.m_whoWasAttacked.Clear();
		if (m_classType != "ranged")
			m_nTimer = 0.5f;
		else
			m_nTimer = 0.4f;

	}


    public virtual void SpawnAttackTiles(Transform attackPrefab, Transform holder)
	{
        // Gets the tile infront of the actor and get its attack tiles relevant to class(will be added)
        Vector3 pos  = GetChildObject(transform, "Ring").transform.position + GetChildObject(transform, "Ring").transform.forward;

        Node attackNode = Map.Instance.GetNodeFromPosition(pos);

		List<Node> attackNodes = GetAttackTiles(attackNode, Map.Instance.GetNodeFromPosition(transform.position));

		// Goes thru each node getting its position
		// and spawn a attacktile
		foreach (Node node in attackNodes)
		{
			// checks if its walkable or not 
			if (node.m_bWalkable)
			{
				Vector3 tempPos = node.m_v3WorldPosition;
				tempPos.y = 0.1f;

				Transform tempWalkableTile = Instantiate(
								attackPrefab,
								tempPos,
								Quaternion.Euler(Vector3.zero));

				tempWalkableTile.parent = holder;
			}
		}
	}


	//TODO Move this to there respective classes
	// Returns the attack tiles
	public virtual List<Node> GetAttackTiles(Node node, Node playerNode, bool getDirectionEnum = false, int nHowManyIterations = 1, int nHowManyTiles = 1)
	{
		List<Node> AttackTiles = new List<Node>();

		// The tile infront off player and want to attack
		Vector2 attackCoord = node.m_v2GridCoordinate;

		// Player coordinates
		Vector2 playerCoord = playerNode.m_v2GridCoordinate;

		/// O equals the player, . equals the nodes, | equals the DirectionEnum this part handles
		/// .	.	.
		///		|
		///	.	O	.
		///		|
		///	.	.	.
		if ((attackCoord.y == playerCoord.y + 1 || attackCoord.y == playerCoord.y - 1) && attackCoord.x == playerCoord.x)
		{
			m_lookingDirec = DirectionEnum.UPDOWN;
			m_bLookingDiaganol = false;
			if (!getDirectionEnum)
			{
				for (int x = -nHowManyIterations; x <= nHowManyIterations; x++)
				{
					for (int y = -nHowManyIterations; y <= nHowManyIterations; y++)
					{

						if (x == 0 && y == 0 || x == 1 && y == 0 || x == -1 && y == 0)
						{
							int checkX = (int)node.m_v2GridCoordinate.x + x;
							int checkY = (int)node.m_v2GridCoordinate.y + y;

							if (checkX >= 0 && checkX < Map.Instance.m_nGridSizeX && checkY >= 0 && checkY < Map.Instance.m_nGridSizeY)
							{
								if (!Map.Instance.m_Grid[checkX, checkY].m_bWalkable)
									continue;

								AttackTiles.Add(Map.Instance.m_Grid[checkX, checkY]);
							}
						}
					}
				}
			}
		}

		/// O equals the player, . equals the nodes, - equals the DirectionEnum this part handles
		/// .	.	.
		///		
		///	. -	O -	.
		///		
		///	.	.	.
		else if ((attackCoord.x == playerCoord.x + 1 || attackCoord.x == playerCoord.x - 1) && attackCoord.y == playerCoord.y)
		{
			m_lookingDirec = DirectionEnum.RIGHTLEFT;
			m_bLookingDiaganol = false;
			if (!getDirectionEnum)
			{
				for (int x = -nHowManyIterations; x <= nHowManyIterations; x++)
				{
					for (int y = -nHowManyIterations; y <= nHowManyIterations; y++)
					{
						if (x == 0 && y == 0 || x == 0 && y == 1 || x == 0 && y == -1)
						{
							int checkX = (int)node.m_v2GridCoordinate.x + x;
							int checkY = (int)node.m_v2GridCoordinate.y + y;

							if (checkX >= 0 && checkX < Map.Instance.m_nGridSizeX && checkY >= 0 && checkY < Map.Instance.m_nGridSizeY)
							{
								if (!Map.Instance.m_Grid[checkX, checkY].m_bWalkable)
									continue;

								AttackTiles.Add(Map.Instance.m_Grid[checkX, checkY]);
							}
						}
					}
				}
			}
		}
        
		/// O equals the player, . equals the nodes, | equals the DirectionEnum this part handles
		/// .	.	.
		///	  \   /
		///	.	O	.
		///	  /	  \
		///	.	.	.
		else if ((attackCoord.y == playerCoord.y + 1 && attackCoord.x == playerCoord.x + 1) ||
					(attackCoord.y == playerCoord.y + 1 && attackCoord.x == playerCoord.x - 1) ||
					(attackCoord.y == playerCoord.y - 1 && attackCoord.x == playerCoord.x + 1) ||
					(attackCoord.y == playerCoord.y - 1 && attackCoord.x == playerCoord.x - 1))
		{
			m_lookingDirec = DirectionEnum.DIAGNOL;
			m_bLookingDiaganol = true;
		}


		if (m_prevDirec != m_lookingDirec && !getDirectionEnum)
		{
			GameObject[] temp = GameObject.FindGameObjectsWithTag("AttackTile");
			m_prevDirec = m_lookingDirec;
			// we want to destroy previous spawned attack tiles
			for (int i = 0; i < temp.Length; i++)
			{
				Destroy(temp[i]);
			}
		}

		return AttackTiles;
	}

    public void Move(List<Node> path)
    {
        Material temp = this.transform.GetChild(0).GetComponentInChildren<Renderer>().material;
        if (m_classType == "support")
		{
			if (m_playAnimUP)
				temp.SetFloat("_Animation", 7);
			else
				temp.SetFloat("_Animation", 6);

			temp.SetFloat("_FrameRate", 24);
			temp.SetFloat("_Frames", 3);
		}
        else
        {
			if (m_playAnimUP)
			{
				if(m_classType == "melee")
					temp.SetFloat("_Animation", 4);

				if(m_classType == "ranged")
					temp.SetFloat("_Animation", 3);

				temp.SetFloat("_FrameRate", 24);
				temp.SetFloat("_Frames", 10);
			}
			else
			{
				temp.SetFloat("_Animation", 2);
				temp.SetFloat("_FrameRate", 24);
				temp.SetFloat("_Frames", 10);
			}
		}
		m_currentPath = path;
		if (m_currentPath.Count > 0)
		{
			GameManager.Instance.m_isMoving = true;
			m_bExecuteMove = true;
			CheckNode();
		}
		else
		{
			m_bStartAttack = true;
			m_nCurrentNode = 0;

			if (gameObject.CompareTag("Player"))
				GameManager.Instance.m_isMoving = false;

			Map.Instance.UpdateUnitOnTop();

			Material tempMaterial = this.transform.GetChild(0).GetComponentInChildren<Renderer>().material;
			tempMaterial.SetFloat("_Animation", 1);
			tempMaterial.SetFloat("_FrameRate", 24);
			tempMaterial.SetFloat("_Frames", 5);
		}
    }

    // Is used to move the Actor tile by tile
  //  public IEnumerator FollowPath(List<Node> path, Actor a)
  //  {
  //      if (m_currentPath.Count > 0)
  //      {
		//	for (int i = 0; i < m_currentPath.Count; )
		//	{
		//		GameManager.Instance.m_isMoving = true;

		//		Vector3 pathNodePos = m_currentPath[i].m_v3WorldPosition;
		//		pathNodePos.y = 1.0f;
		//		a.transform.position = Vector3.Lerp(a.transform.position, pathNodePos, 0.1f);
		//		if (a.transform.position == pathNodePos)
		//		{
		//			i++;
		//		}
		//		a.m_ActorPos = pathNodePos;
		//		yield return new WaitForSeconds(1.0f); // skips frames

		//		this.m_bStartAttack = true;
		//		GameManager.Instance.m_isMoving = false;

		//		Map.Instance.UpdateUnitOnTop();
		//	}
		//}

  //      Material temp = this.transform.GetChild(0).GetComponentInChildren<Renderer>().material;
  //      temp.SetFloat("_Animation", 1);
  //      temp.SetFloat("_FrameRate", 24);
  //      temp.SetFloat("_Frames", 5);
  //  }

	public void CheckNode()
	{
		m_calculatedSpeed = 0;
		m_v3CurrentPosHolder = m_currentPath[m_nCurrentNode].m_v3WorldPosition;
		m_v3CurrentPosHolder.y = 1.0f;
		m_v3StartingPos = this.gameObject.transform.position;
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
            if (child.childCount > 0)
            {
                GetChildObject(child, _tag);
            }
        }
        return null;
    }
}