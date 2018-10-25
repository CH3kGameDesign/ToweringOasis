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

	public override void SpawnAttackTiles(Transform attackPrefab, Transform holder)
	{
		base.SpawnAttackTiles(attackPrefab, holder);
	}
}