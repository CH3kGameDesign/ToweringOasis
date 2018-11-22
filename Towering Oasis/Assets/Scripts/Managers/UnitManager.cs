using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Singleton class
public class UnitManager : MonoBehaviour
{
	// Static instance for accessing it from any class
	public static UnitManager Instance = null;
	public List<Transform> m_Parent; // Player, Enemy and obstacle parent objects
	public List<Transform> m_Objects; // Player, Enemies and obstacles themselves
	public int m_nPlayersAtExit;
	public int m_nPlayersAlive;

	private void Awake()
	{
		// Creating an instance of this class
			// if its not already declared
		if (Instance == null)
			Instance = this;
		else if (Instance != this)
			Destroy(gameObject);

        m_nPlayersAtExit = 0;
        m_nPlayersAlive = 4;
}

	// Getting all the objects under m_parent objects
	public void UpdateObject()
	{
		m_Objects = new List<Transform>();

		// Going through the parents
		for (int i = 0; i < m_Parent.Count; i++)
		{
			// For every child that is present under the parent
			for (int j = 0; j < m_Parent[i].childCount; j++)
			{
				// Add them to the list
				m_Objects.Add(m_Parent[i].GetChild(j));

				// If the child count of the object under m_parent
					// and its parent is and obstacles
				if (m_Parent[i].GetChild(j).childCount > 0 && m_Parent[i].name == "Obstacles")
				{
					// Get its child as well
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
