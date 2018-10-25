using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerExit : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player") && GameManager.Instance.m_bcontrolsAvailable)
		{
			other.enabled = false;
			UnitManager.Instance.m_nPlayersAtExit++;
			other.transform.parent = transform;
			UnitManager.Instance.m_Objects.Remove(other.transform);
		}
	}
}
