using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
	public static UnitManager Instance = null;
	public List<Transform> m_Parent;
	public List<Transform> m_Objects;

    private void Awake()
	{
		if (Instance == null)
			Instance = this;
		else if (Instance != this)
			Destroy(gameObject);
	}

	public void UpdateObjectTile()
	{
		m_Objects = new List<Transform>();
		for (int i = 0; i < m_Parent.Count; i++)
		{
			for (int j = 0; j < m_Parent[i].childCount; j++)
			{
				m_Objects.Add(m_Parent[i].GetChild(j));
				if (m_Parent[i].GetChild(j).childCount > 0 && m_Parent[i].name == "Obstacles")
				{
					int objectCount = m_Objects.Count - 1;
					for (int x = 0; x < m_Objects[objectCount].childCount; x++)
					{
						m_Objects.Add(m_Parent[i].GetChild(j).GetChild(x));
					}
				}
			}
		}
	}
}
