using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Support : Actor
{
	public override void Start()
	{
		base.Start();
		m_classType = "support";
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

	public override void SpawnAttackTiles(Transform attackPrefab)
	{
		base.SpawnAttackTiles(attackPrefab);

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

				tempWalkableTile.parent = transform;
			}
		}
	}
}