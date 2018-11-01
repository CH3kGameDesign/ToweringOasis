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
	
	[HideInInspector]
	public Transform m_ActorPrefab;
	[HideInInspector]
	public Renderer m_ActorRenderer;
	[HideInInspector]
	public Vector3 m_ActorPos;
	public string m_classType;

    // How many tiles is this actor allowed to move
    public int m_nHealth;
    public int m_nHowManyTiles;
    public int m_nDamage;
	public List<Node> m_currentPath;
	public bool m_bMoved;
	public bool m_bAttack;
	public bool m_bSkip;
    public bool m_bStartAttack;
    public DirectionEnum m_lookingDirec;
	public DirectionEnum m_prevDirec;
	public bool m_bLookingDiaganol = false;


	// Character that this character is attacked by
	//[HideInInspector]
	public List<Actor> m_whoWasAttacked = new List<Actor>();
    public List<Node> individualPath = new List<Node>();


	public virtual void Start()
	{
		// Assigning default values
		m_ActorPrefab = this.transform;
		m_ActorRenderer = GetComponent<Renderer>();
		m_ActorPos = m_ActorPrefab.position;
	}

	public virtual void Update()
	{
		// if health is 0 destroy the gameobject
		if (m_nHealth <= 0)
		{
			UnitManager.Instance.m_Objects.Remove(gameObject.transform);
			Destroy(gameObject);
		}
	}

	public virtual void Attack()
	{
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
				Transform HealthDrop = Instantiate(m_HealthDropPrefab, actor.transform.position, Quaternion.Euler(40, 140, 0), actor.transform);
				HealthDrop.GetComponent<TextMesh>().text = actor.m_nHealth.ToString();
				Debug.Log("A Step 4");
			}
		}

        this.m_whoWasAttacked.Clear();
    }


    public virtual void SpawnAttackTiles(Transform attackPrefab, Transform holder)
	{
		// Gets the tile infront of the actor and get its attack tiles relevant to class(will be added)
		Vector3 pos = transform.position + transform.forward;
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
	public List<Node> GetAttackTiles(Node node, Node playerNode, bool getDirectionEnum = false, int nHowManyIterations = 1, int nHowManyTiles = 1)
	{
		List<Node> AttackTiles = new List<Node>();

		// The infront off player and want to attack
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

	public void GetDirectionEnum()
	{

	}

    public void Move(List<Node> path)
    {
        StartCoroutine(FollowPath(path, this));
    }

    // Is used to move the Actor tile by tile
    public IEnumerator FollowPath(List<Node> path, Actor a)
    {
		m_currentPath = path;
        if (m_currentPath.Count > a.m_nHowManyTiles)
        {
            for (int i = 0; i < a.m_nHowManyTiles; i++)
            {
                GameManager.Instance.m_isMoving = true;

                m_bAttack = false;
                Vector3 pathNodePos = m_currentPath[i].m_v3WorldPosition;
                pathNodePos.y = 1.0f;
                a.transform.position = pathNodePos;
                a.m_ActorPos = pathNodePos;
                yield return new WaitForSeconds(1.0f); // skips frames

                this.m_bStartAttack = true;
                GameManager.Instance.m_isMoving = false;

				Map.Instance.UpdateUnitOnTop();
			}
        }
        else if(m_currentPath.Count == 0)
        {
            this.m_bStartAttack = true;
            GameManager.Instance.m_isMoving = false;

			Map.Instance.UpdateUnitOnTop();
		}
        else
        {
            for (int i = 0; i < m_currentPath.Count; i++)
            {
                GameManager.Instance.m_isMoving = true;

                m_bAttack = false;
                Vector3 pathNodePos = m_currentPath[i].m_v3WorldPosition;
                pathNodePos.y = 1.0f;
                a.transform.position = pathNodePos;
                a.m_ActorPos = pathNodePos;
                yield return new WaitForSeconds(1.0f); // skips frames

                this.m_bStartAttack = true;
                GameManager.Instance.m_isMoving = false;

				Map.Instance.UpdateUnitOnTop();
			}
        }
	}
}
