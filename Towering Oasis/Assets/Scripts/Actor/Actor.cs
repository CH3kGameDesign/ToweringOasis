using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
	public bool m_bMoved;
	public bool m_bAttack;
	public bool m_bLookingDiaganol = false;

	// Character that this character is attacked by
	[HideInInspector]
	public List<Actor> m_whoWasAttacked = new List<Actor>();


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
		foreach (Actor actor in m_whoWasAttacked)
		{
			// Deduct health by the damage of the attacker
			actor.m_nHealth -= this.m_nDamage;

			// Create Health popup and set text which is equal to this actor's health
			Transform HealthDrop = Instantiate(m_HealthDropPrefab, actor.transform.position, Quaternion.Euler(40, 140, 0), actor.transform);
			HealthDrop.GetComponent<TextMesh>().text = actor.m_nHealth.ToString();
		}
	}


	public virtual void SpawnAttackTiles(Transform attackPrefab)
	{
		
	}


	//TODO Move this to there respective classes
	// Returns the attack tiles
	public List<Node> GetAttackTiles(Node node, Node playerNode, int nHowManyIterations = 1, int nHowManyTiles = 1)
	{
		List<Node> AttackTiles = new List<Node>();

		// The infront off player and want to attack
		Vector2 attackCoord = node.m_v2GridCoordinate;

		// Player coordinates
		Vector2 playerCoord = playerNode.m_v2GridCoordinate;

		/// O equals the player, . equals the nodes, | equals the direction this part handles
		/// .	.	.
		///		|
		///	.	O	.
		///		|
		///	.	.	.
		if ((attackCoord.y == playerCoord.y + 1 || attackCoord.y == playerCoord.y - 1) && attackCoord.x == playerCoord.x)
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
			m_bLookingDiaganol = false;
		}

		/// O equals the player, . equals the nodes, - equals the direction this part handles
		/// .	.	.
		///		
		///	. -	O -	.
		///		
		///	.	.	.
		else if ((attackCoord.x == playerCoord.x + 1 || attackCoord.x == playerCoord.x - 1) && attackCoord.y == playerCoord.y)
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
			m_bLookingDiaganol = false;
		}

		else
		{
			m_bLookingDiaganol = false;
		}

		return AttackTiles;
	}
}
