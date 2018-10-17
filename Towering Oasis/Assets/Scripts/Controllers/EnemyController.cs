using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distance
{
	public int m_playerNumber;
	public int m_enemyNumber;

	public int m_distance;
	private int m_nHeapIndex;

	public Distance(int playerNumber, int enemyNumber, int distance)
	{
		m_playerNumber = playerNumber;
		m_enemyNumber = enemyNumber;

		m_distance = distance;
	}
}

public class EnemyController : Controller
{
	public List<Actor> m_Players;
	public List<Actor> m_Enemies;
	public List<Distance> m_distance;
	int d = 0;

	private void Start()
	{
		for (int i = 0; i < UnitManager.Instance.m_Parent[0].childCount; i++)
		{
			m_Players.Add(UnitManager.Instance.m_Parent[0].GetChild(i).GetComponent<Actor>());
		}

		for (int i = 0; i < UnitManager.Instance.m_Parent[1].childCount; i++)
		{
			m_Enemies.Add(UnitManager.Instance.m_Parent[1].GetChild(i).GetComponent<Actor>());
		}
		int nlength = m_Players.Count * m_Enemies.Count;
		m_distance = new List<Distance>(nlength);
	}

	private void Update()
	{
		//TODO change condition after testing
		if (/*!GameManager.Instance.m_bcontrolsAvailable*/ d < 1)
		{
			int i = 0;
			for (int p = 0; p < m_Players.Count; p++)
			{
				for (int e = 0; e < m_Enemies.Count; e++)
				{
					Pathfinding.Instance.FindPath(m_Players[p].m_ActorPos, m_Enemies[e].m_ActorPos, false);

					Distance temp = new Distance(
									p,
									e,
									Pathfinding.Instance.path.Count - 1);
					m_distance.Add(temp);
					i++;
				}
			}
			m_distance = m_distance.OrderBy(o => o.m_distance).ToList<Distance>();

			for (int j = 0; j < m_distance.Count; j++)
			{
				Debug.Log("Distance with player " + m_distance[j].m_playerNumber + " and enemy " + m_distance[j].m_enemyNumber + " is " + m_distance[j].m_distance);

			}
			d++;
		}
	}
}