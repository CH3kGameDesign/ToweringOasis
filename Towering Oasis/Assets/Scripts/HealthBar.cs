using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    // Use this for initialization
    int m_MaxHP = 10;
    public int m_CurrentHP;
    public Transform m_HealthBar;
    int HPcount;
    public GameObject[] m_HealthPoints;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (HPcount != m_CurrentHP)
        {
            HPcount = 0;
            var HP = GameObject.FindGameObjectsWithTag("HealthPoint");
            foreach (var item in HP)
            {
                item.SetActive(false);
            }

            for (int i = 0; i < m_CurrentHP && i < m_MaxHP; i++)
            {
                m_HealthPoints[i].SetActive(true);
                HPcount++;
            }
        }
    }
}
