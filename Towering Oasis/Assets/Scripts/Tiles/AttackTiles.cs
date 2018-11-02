﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTiles : MonoBehaviour
{
	void OnTriggerEnter(Collider other)
	{
		if (UnitManager.Instance.m_Objects.Contains(other.transform))
		{
			Actor actor = GameManager.Instance.m_currentActor;

			Actor ObjectToDamage = other.GetComponent<Actor>();

            if (other.gameObject.CompareTag("Enemy") && actor.gameObject.CompareTag("Enemy"))
                return;

			actor.m_whoWasAttacked.Add(ObjectToDamage);
		}
	}
}
