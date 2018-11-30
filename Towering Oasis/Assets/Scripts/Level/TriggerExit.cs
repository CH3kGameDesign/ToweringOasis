using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerExit : MonoBehaviour
{
    private void Update()
    {
        gameObject.GetComponent<Collider>().enabled = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !GameManager.Instance.m_charactersInElevator.Contains(other.name))
        {
            UnitManager.Instance.m_nPlayersAtExit++;
            GameManager.Instance.m_charactersInElevator.Add(other.name);
            other.GetComponent<Actor>().m_bAtExit = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (UnitManager.Instance.m_nPlayersAtExit > 0)
                UnitManager.Instance.m_nPlayersAtExit--;
        }
    }
}
