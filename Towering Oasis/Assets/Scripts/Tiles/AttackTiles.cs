using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTiles : MonoBehaviour
{
	void OnTriggerEnter(Collider other)
	{
		if (UnitManager.Instance.m_Objects.Contains(other.transform))
		{
			Actor Player = GetComponentInParent<Actor>();
			Actor ObjectToDamage = other.GetComponent<Actor>();
			Player.m_whoWasAttacked.Add(ObjectToDamage);
		}
	}
}
