using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ranged : Actor
{
	public override void Start()
	{
		base.Start();
		m_classType = "ranged";
	}

	public override void Update()
	{
		base.Update();
	}

	// Performs attack function
	public override void Attack()
	{
		base.Attack();
	}

	public override void SpawnAttackTiles(Transform attackPrefab, Transform holder)
	{
		base.SpawnAttackTiles(attackPrefab, holder);
	}

	public override List<Node> GetAttackTiles(Node node, Node playerNode, bool getDirectionEnum = false, int nHowManyIterations = 1, int nHowManyTiles = 1)
	{
		List<Node> AttackTiles = new List<Node>();
		// The tile infront off player and want to attack
		Vector2 attackCoord = node.m_v2GridCoordinate;

		// Player coordinates
		Vector2 playerCoord = playerNode.m_v2GridCoordinate;

		AttackTiles.Add(node);

		/// O equals the player, . equals the nodes, | equals the DirectionEnum this part handles
		/// .	.	.
		///		|
		///	.	O	.
		///		|
		///	.	.	.
		if (attackCoord.y == playerCoord.y + 1 && attackCoord.x == playerCoord.x)
		{
			m_lookingDirec = DirectionEnum.UPDOWN;
			m_bLookingDiaganol = false;
			if (!getDirectionEnum)
			{
				int y = (int)attackCoord.y + 2;
				AttackTiles.Add(Map.Instance.m_Grid[(int)attackCoord.x, y]);
				AttackTiles.AddRange(Map.Instance.GetNeighbours(Map.Instance.m_Grid[(int)attackCoord.x, y], 1));
			}
		}
		else if (attackCoord.y == playerCoord.y - 1 && attackCoord.x == playerCoord.x)
		{
			m_lookingDirec = DirectionEnum.UPDOWN;
			m_bLookingDiaganol = false;
			if (!getDirectionEnum)
			{
				int y = (int)attackCoord.y - 2;
				AttackTiles.Add(Map.Instance.m_Grid[(int)attackCoord.x, y]);
				AttackTiles.AddRange(Map.Instance.GetNeighbours(Map.Instance.m_Grid[(int)attackCoord.x, y], 1));
			}
		}

		/// O equals the player, . equals the nodes, - equals the DirectionEnum this part handles
		/// .	.	.
		///		
		///	. -	O -	.
		///		
		///	.	.	.
		else if (attackCoord.x == playerCoord.x + 1 && attackCoord.y == playerCoord.y)
		{
			m_lookingDirec = DirectionEnum.RIGHTLEFT;
			m_bLookingDiaganol = false;
			if (!getDirectionEnum)
			{
				int x = (int)attackCoord.x + 2;
				AttackTiles.Add(Map.Instance.m_Grid[x, (int)attackCoord.y]);
				AttackTiles.AddRange(Map.Instance.GetNeighbours(Map.Instance.m_Grid[x, (int)attackCoord.y], 1));
			}
		}
		else if (attackCoord.x == playerCoord.x - 1 && attackCoord.y == playerCoord.y)
		{
			m_lookingDirec = DirectionEnum.RIGHTLEFT;
			m_bLookingDiaganol = false;
			if (!getDirectionEnum)
			{
				int x = (int)attackCoord.x - 2;
				AttackTiles.Add(Map.Instance.m_Grid[x, (int)attackCoord.y]);
				AttackTiles.AddRange(Map.Instance.GetNeighbours(Map.Instance.m_Grid[x, (int)attackCoord.y], 1));
			}
		}

		/// O equals the player, . equals the nodes, | equals the DirectionEnum this part handles
		/// .	.	.
		///	  \   /
		///	.	O	.
		///	  /	  \
		///	.	.	.
		else if (attackCoord.y == playerCoord.y + 1 && attackCoord.x == playerCoord.x + 1)
		{
			m_lookingDirec = DirectionEnum.DIAGNOL;
			m_bLookingDiaganol = true;
			if (!getDirectionEnum)
			{
				int x = (int)attackCoord.x + 2;
				int y = (int)attackCoord.y + 2;
				AttackTiles.Add(Map.Instance.m_Grid[x, y]);

				AttackTiles.AddRange(Map.Instance.GetNeighbours(Map.Instance.m_Grid[x, y], 1));
			}
		}

		else if (attackCoord.y == playerCoord.y + 1 && attackCoord.x == playerCoord.x - 1)
		{
			m_lookingDirec = DirectionEnum.DIAGNOL;
			m_bLookingDiaganol = true;
			if (!getDirectionEnum)
			{
				int x = (int)attackCoord.x - 2;
				int y = (int)attackCoord.y + 2;
				AttackTiles.Add(Map.Instance.m_Grid[x, y]);

				AttackTiles.AddRange(Map.Instance.GetNeighbours(Map.Instance.m_Grid[x, y], 1));
			}
		}

		else if (attackCoord.y == playerCoord.y - 1 && attackCoord.x == playerCoord.x + 1)
		{
			m_lookingDirec = DirectionEnum.DIAGNOL;
			m_bLookingDiaganol = true;
			if (!getDirectionEnum)
			{
				int x = (int)attackCoord.x + 2;
				int y = (int)attackCoord.y - 2;
				AttackTiles.Add(Map.Instance.m_Grid[x, y]);

				AttackTiles.AddRange(Map.Instance.GetNeighbours(Map.Instance.m_Grid[x, y], 1));
			}
		}

		else if (attackCoord.y == playerCoord.y - 1 && attackCoord.x == playerCoord.x - 1) 
		{
			m_lookingDirec = DirectionEnum.DIAGNOL;
			m_bLookingDiaganol = true;
			if (!getDirectionEnum)
			{
				int x = (int)attackCoord.x - 2;
				int y = (int)attackCoord.y - 2;
				AttackTiles.Add(Map.Instance.m_Grid[x, y]);

				AttackTiles.AddRange(Map.Instance.GetNeighbours(Map.Instance.m_Grid[x, y], 1));
			}
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
}