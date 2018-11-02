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
    void Start ()
    {

    }
	
	// Update is called once per frame
	void Update ()
    {
        if (HPcount != m_CurrentHP)
        {
            HPcount = 0;
            var HP = GameObject.FindGameObjectsWithTag("HealthPoint");
            foreach (var item in HP)
            {
                Destroy(item);
            }

            for (int i = 0; i < m_CurrentHP && i < m_MaxHP; i++)
            {
                Transform go = Instantiate(m_HealthBar, new Vector3(-100, -100, 0), new Quaternion(0, 0, 0, 0));
                go.SetParent(transform.parent);
                go.position = new Vector3(100 + 45 * i, 25);
                HPcount++;
            }
        }
    }
}
