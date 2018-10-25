using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTiles : MonoBehaviour
{
	void OnTriggerEnter(Collider other)
	{
		if (UnitManager.Instance.m_Objects.Contains(other.transform))
		{
			Actor actor;
			if (other.CompareTag("Enemy"))
				actor = GameObject.FindObjectOfType<PlayerController>().m_Player;
			else
			{
				actor = GameObject.FindObjectOfType<EnemyController>().m_currentEnemy;
			}

			Actor ObjectToDamage = other.GetComponent<Actor>();

			actor.m_whoWasAttacked.Add(ObjectToDamage);
		}
	}
}
