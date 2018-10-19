using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distance
{
    public int m_playerNumber;
    public int m_enemyNumber;

    public int m_tileCount;

    public Distance(int playerNumber, int enemyNumber, int distance)
    {
        m_playerNumber = playerNumber;
        m_enemyNumber = enemyNumber;

        m_tileCount = distance;
    }
}

public class EnemyController : Controller
{
    public List<Actor> m_Players;
    public List<Actor> m_Enemies;
    public List<Distance> m_distance;
    public List<Actor> m_closestEnemies;
    public Transform m_attackPrefab;
    public bool inFirst = false;

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
        if (!GameManager.Instance.m_bcontrolsAvailable)
        {
            int i = 0;
            for (int e = 0; e < m_Enemies.Count; e++)
            {
                for (int p = 0; p < m_Players.Count; p++)
                {
                    Pathfinding.Instance.FindPath(m_Enemies[e].m_ActorPos, m_Players[p].m_ActorPos, true);

                    Distance temp = new Distance(
                                    p,
                                    e,
                                    Pathfinding.Instance.path.Count - 1);
                    m_distance.Add(temp);
                    i++;
                }
            }

            m_distance = m_distance.OrderBy(o => o.m_tileCount).ToList<Distance>();

            int nlowestDistance = m_distance[0].m_tileCount;
            bool benemiesWithLowestDistFound = false;
            int[] distanceClosest = new int[m_distance.Count];

            for (int j = 0; j < m_distance.Count && !benemiesWithLowestDistFound; j++)
            {
                int x = 0;
                if (m_distance[j].m_tileCount > nlowestDistance)
                {
                    benemiesWithLowestDistFound = true;
                }

                if (!m_closestEnemies.Contains(m_Enemies[m_distance[j].m_enemyNumber]))
                {
                    m_closestEnemies.Add(m_Enemies[m_distance[j].m_enemyNumber]);
                    distanceClosest[x] = j;
                }
                x++;
            }

            for (int x = 0; x < m_closestEnemies.Count; x++)
            {
                Debug.Log(m_closestEnemies[x].name);
            }

            for (int j = 0; j < m_closestEnemies.Count; j++)
            {
                Pathfinding.Instance.FindPath(m_closestEnemies[j].m_ActorPos, m_Players[m_distance[j].m_playerNumber].m_ActorPos, true);

                for (int x = 0; x < Pathfinding.Instance.path.Count - 1; x++)
                {
                    m_closestEnemies[j].Move(Pathfinding.Instance.path);
                }

                m_closestEnemies[j].transform.LookAt(m_Players[m_distance[j].m_playerNumber].transform);
                m_closestEnemies[j].SpawnAttackTiles(m_attackPrefab);
            }



        }
    }

    private void FixedUpdate()
    {
        if (!GameManager.Instance.m_bcontrolsAvailable)
        {
            m_closestEnemies[0].Attack();

            GameManager.Instance.m_nPlayerMoves = 0;
            GameManager.Instance.m_bcontrolsAvailable = true;

            // Assign tiles actors and obstacles are on
            Map.Instance.UpdateUnitOnTop();
        }
    }
}