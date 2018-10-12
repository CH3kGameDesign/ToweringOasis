using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIAttackRange : MonoBehaviour {

    public List<Actor> howManyHit;
    public List<Actor> m_whoWasAttacked;

    private Actor Player;
    private Actor ObjectToDamage;

    private int howManyHitBest = 0;
    private int bestRotation = 0;
    private int iAttempt = 0;

    public bool DebugTrue = false;

    void OnTriggerEnter(Collider other)
    {
        if (UnitManager.Instance.m_Objects.Contains(other.transform))
        {
            Player = GetComponentInParent<Actor>();
            ObjectToDamage = other.GetComponent<Actor>();
            m_whoWasAttacked.Add(ObjectToDamage);
            if (!howManyHit.Contains(other.GetComponent<Actor>()))
                howManyHit.Add(other.GetComponent<Actor>());
            if (DebugTrue)
                Debug.Log("Melee Hit");
        }
    }

    public void CheckAttack ()
    {
        if (DebugTrue)
            Debug.Log("CHECKATTACK");

        howManyHitBest = 0;
        bestRotation = 0;
        iAttempt = 0;

        
        StartCoroutine(CheckAttackRoutine());
        
        Invoke("StartAttack", 0.5f);
    }

    IEnumerator CheckAttackRoutine()
    {
        for (int i = 0; i < 4; i++)
        {
            if (DebugTrue)
                Debug.Log("CHECKATTACKROUTINE " + i);
            m_whoWasAttacked.Clear();
            Quaternion rotation = Quaternion.Euler(new Vector3(transform.localRotation.x, 90 * i, transform.localRotation.z));
            if (DebugTrue)
                Debug.Log("Rotation To Aim For " + rotation);
            transform.localRotation = rotation;
            if (DebugTrue)
                Debug.Log("How Many Hit = " + i + " " + howManyHit.Count + " > " + howManyHitBest);
            if (howManyHit.Count > howManyHitBest)
            {
                howManyHitBest = howManyHit.Count;
                bestRotation = i;
                if (DebugTrue)
                    Debug.Log("Best Rotation = " + bestRotation);
            }
            howManyHit.Clear();

            if (bestRotation != 3)
            {
                m_whoWasAttacked.Clear();
            }
            
            yield return new WaitForSeconds(0.1f); // skips frames
        }
    }

    public void StartAttack ()
    {
        transform.localRotation = Quaternion.Euler(transform.localRotation.x, 90 * bestRotation, transform.localRotation.z);
        //Player.m_whoWasAttacked = m_whoWasAttacked;
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }
    }

    public void EndAttack()
    {
        //BRING BACK SOON
        //Player.m_whoWasAttacked.Clear();
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }
}
