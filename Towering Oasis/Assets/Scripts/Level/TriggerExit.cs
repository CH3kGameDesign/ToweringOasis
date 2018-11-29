using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerExit : MonoBehaviour
{
    private void Update()
    {
        //Debug.Log(UnitManager.Instance.m_nPlayersAtExit);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && GameManager.Instance.m_bcontrolsAvailable && !GameManager.Instance.m_charactersInElevator.Contains(other.name))
        {
            //other.enabled = false;
            UnitManager.Instance.m_nPlayersAtExit++;
            GameManager.Instance.m_charactersInElevator.Add(other.name);
            //other.transform.parent = transform;
            //UnitManager.Instance.m_Objects.Remove(other.transform);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        //Debug.Log(UnitManager.Instance.m_nPlayersAtExit);
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //other.enabled = false;
            if (UnitManager.Instance.m_nPlayersAtExit > 0)
                UnitManager.Instance.m_nPlayersAtExit--;
            //other.transform.parent = transform;
            //UnitManager.Instance.m_Objects.Remove(other.transform);
        }
    }
}
