using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    // Use this for initialization
    public int m_MaxHP;
    public int m_CurrentHP;
    public Transform m_HealthBar;

    void Start ()
    {
		for(int i = 0; i < m_MaxHP; i++)
        {
            Transform go = Instantiate(m_HealthBar, new Vector3( -100, -100, 0), new Quaternion(0,0,0,0));
            go.SetParent(transform.parent);
            go.position = new Vector3(60 + 45 * i, 29) ;
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        var HP = GameObject.FindGameObjectsWithTag("HealthPoint");
        foreach(var item in HP)
        {
            Destroy(item);
        }
            for (int i = 0; i < m_CurrentHP; i++)
            {
                Transform go = Instantiate(m_HealthBar, new Vector3(-100, -100, 0), new Quaternion(0, 0, 0, 0));
                go.SetParent(transform.parent);
                go.position = new Vector3(60 + 45 * i, 29);
            }
	}
}
