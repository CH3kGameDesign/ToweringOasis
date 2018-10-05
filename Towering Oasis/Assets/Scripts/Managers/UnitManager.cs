using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
   public List<Transform> m_Objects;

    private void Awake()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform m_Parent = transform.GetChild(i);
            for (int j = 0; j < m_Parent.childCount; j++)
            {
                m_Objects.Add(m_Parent.GetChild(j));
                if(m_Parent.GetChild(j).childCount > 0 && m_Parent.name == "Obstacles")
                {
                    int objectCount = m_Objects.Count - 1;
                    for (int x = 0; x < m_Objects[objectCount].childCount; x++)
                    {
                        m_Objects.Add(m_Parent.GetChild(j).GetChild(x));
                    }
                }
            }
        }

    }
}
