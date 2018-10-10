using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ranged : Actor
{
	public override void Start()
	{
		base.Start();
		m_nHowManyTiles = 2;
		m_nDamage = 20;
	}

	public override void Update()
	{
		base.Update();
	}

	public override void Attack(Transform specialTile)
	{
		base.Attack(specialTile);

		// Gets the tile infront of the actor and get its attack tiles relevant to class(will be added)
		Vector3 pos = transform.position + transform.forward;
		Node attackNode = Map.Instance.GetNodeFromPosition(pos);
		List<Node> attackNodes = Map.Instance.GetAttackTiles(attackNode, Map.Instance.GetNodeFromPosition(this.transform.position));

		// Goes thru each node getting its position
		// and spawn a attacktile
		foreach (Node node in attackNodes)
		{
			// checks if its walkable or not 
			if (node.m_bWalkable || !node.m_bIsUnitOnTop)
			{
				Vector3 tempPos = node.m_v3WorldPosition;
				tempPos.y = 0.1f;

				Transform tempWalkableTile = Instantiate(
								specialTile,
								tempPos,
								Quaternion.Euler(Vector3.zero));

				tempWalkableTile.parent = transform;
			}
		}
	}
}