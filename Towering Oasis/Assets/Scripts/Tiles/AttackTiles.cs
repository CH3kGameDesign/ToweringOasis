using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTiles : MonoBehaviour
{
	void OnTriggerEnter(Collider other)
	{
		if (UnitManager.Instance.m_Objects.Contains(other.transform))
		{
			Actor actor = GameManager.Instance.m_currentActor;
			Actor ObjectToDamage;

			if (actor.gameObject.CompareTag("Player"))
			{
				ObjectToDamage = other.GetComponent<Actor>();		
				actor.m_whoWasAttacked.Add(ObjectToDamage);
			}
			else if (actor.gameObject.CompareTag("Enemy"))
			{
				if (other.gameObject.CompareTag("Boss") && actor.gameObject.CompareTag("Enemy"))
					return;

				ObjectToDamage = other.GetComponent<Actor>();

				if(actor.m_classType == "support")
				{
					if (ObjectToDamage.CompareTag("Enemy"))
					{
						GameManager.Instance.enemyController.m_enemyPreference.Add(ObjectToDamage);
					}
				}
				else if(actor.m_classType == "melee" || actor.m_classType == "ranged")
				{
					if (ObjectToDamage.CompareTag("Player"))
					{
						GameManager.Instance.enemyController.m_enemyPreference.Add(ObjectToDamage);
					}
				}
				
				actor.m_whoWasAttacked.Add(ObjectToDamage);
			}
		}
	}
}
