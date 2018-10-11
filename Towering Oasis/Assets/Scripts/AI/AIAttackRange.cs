using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIAttackRange : MonoBehaviour {

    public int howManyHit;
    public List<Actor> m_whoWasAttacked;

    private Actor Player;
    private Actor ObjectToDamage;

    void OnTriggerEnter(Collider other)
    {
        if (UnitManager.Instance.m_Objects.Contains(other.transform))
        {
            Player = GetComponentInParent<Actor>();
            ObjectToDamage = other.GetComponent<Actor>();
            m_whoWasAttacked.Add(ObjectToDamage);
            howManyHit++;
            Debug.Log("Melee Hit");
        }
    }

    public void StartAttack ()
    {
        //Player.m_whoWasAttacked = m_whoWasAttacked;
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }
    }

    public void EndAttack()
    {
        Player.m_whoWasAttacked.Clear();
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }
}
