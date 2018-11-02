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

public class Direction
{
    public int m_whowasattackedPrev;
    public Vector3 m_prevRotation;

    public Direction(int whowasattackedPrev, Vector3 prevRotation)
    {
        m_whowasattackedPrev = whowasattackedPrev;
        m_prevRotation = prevRotation;
    }
}

public class EnemyController : Controller
{
    public List<Actor> m_Players;
    public List<Actor> m_Enemies;
    public Actor m_currentEnemy;
    public List<Distance> m_distance;
    public Transform m_attackPrefab;
    public GameManager m_gameManager;
    public int m_nhasAttacked;
    public List<Direction> m_BestDirection;
    public bool m_bestDirectionFound;

    private void Start()
    {
        m_Players = new List<Actor>();
        m_Enemies = new List<Actor>();
        m_distance = new List<Distance>();
        m_BestDirection = new List<Direction>();
        m_gameManager = GameManager.Instance;
    }

    public override void myUpdate()
    {
        if(!m_gameManager.m_bcontrolsAvailable && !m_gameManager.m_isMoving && !m_gameManager.m_isAttacking)
        {
            m_BestDirection.Clear();
            m_nhasAttacked = 0;
            m_Players.Clear();
            m_Enemies.Clear();

            for (int i = 0; i < UnitManager.Instance.m_Parent[0].childCount; i++)
            {
                m_Players.Add(UnitManager.Instance.m_Parent[0].GetChild(i).GetComponent<Actor>());
            }

            for (int i = 0; i < UnitManager.Instance.m_Parent[1].childCount; i++)
            {
                m_Enemies.Add(UnitManager.Instance.m_Parent[1].GetChild(i).GetComponent<Actor>());
            }

            m_currentEnemy = m_Enemies[m_gameManager.m_nEnemiesMoves];
            GameManager.Instance.m_currentActor = m_currentEnemy;

            {
                // Draw a line to debug player front
                Debug.DrawRay(m_Enemies[m_gameManager.m_nEnemiesMoves].gameObject.transform.position, m_Enemies[m_gameManager.m_nEnemiesMoves].gameObject.transform.forward * 5, Color.red);
            }

            m_distance.Clear();

            for (int p = 0; p < m_Players.Count; p++)
            {
                Pathfinding.Instance.FindPath(m_Enemies[m_gameManager.m_nEnemiesMoves].m_ActorPos, m_Players[p].m_ActorPos, true);

                m_distance.Add(new Distance(
                                        p,
                                        m_gameManager.m_nEnemiesMoves,
                                        Pathfinding.Instance.path.Count - 1));
            }

            m_distance = m_distance.OrderBy(o => o.m_tileCount).ToList<Distance>();

            Pathfinding.Instance.FindPath(m_Enemies[m_gameManager.m_nEnemiesMoves].m_ActorPos, m_Players[m_distance[0].m_playerNumber].m_ActorPos, false);
            
            m_Enemies[m_gameManager.m_nEnemiesMoves].Move(Pathfinding.Instance.path);
        }

        if (m_currentEnemy.m_bStartAttack && m_nhasAttacked == 0)
        {
            m_nhasAttacked++;
            m_bestDirectionFound = true;
            StartCoroutine(EnemyAttack());
            m_currentEnemy.m_bStartAttack = false;
            m_gameManager.m_nEnemiesMoves++;
        }

        if (m_gameManager.m_nEnemiesMoves == m_Enemies.Count)
        {
            m_gameManager.m_bcontrolsAvailable = true;
        }
    }

    IEnumerator EnemyAttack()
    {
        m_gameManager.m_isAttacking = true;

        if (m_gameManager.m_isMoving)
            yield return new WaitForSeconds(3f);

        if(m_bestDirectionFound)
        { 
            for (int i = 0; i < 4;)
            {
                m_currentEnemy.transform.Rotate(0.0f, 90.0f, 0.0f);

                Vector3 rot = m_currentEnemy.transform.eulerAngles;

                m_BestDirection.Add(new Direction(0, rot));
                m_currentEnemy.SpawnAttackTiles(m_attackPrefab, m_gameManager.AttackTileHolder);

                if (i < 4)
                    yield return new WaitForSeconds(0.7f);

                m_BestDirection[m_BestDirection.Count - 1].m_whowasattackedPrev = m_currentEnemy.m_whoWasAttacked.Count;

                m_currentEnemy.m_whoWasAttacked.Clear();

                GameObject[] temp = GameObject.FindGameObjectsWithTag("AttackTile");

                // we want to destroy previous spawned attack tiles
                for (int j = 0; j < temp.Length; j++)
                {
                    Destroy(temp[j]);
                }

                i++;
            }
            m_currentEnemy.m_whoWasAttacked.Clear();

            m_BestDirection = m_BestDirection.OrderByDescending(o => o.m_whowasattackedPrev).ToList<Direction>();

            m_currentEnemy.transform.eulerAngles = m_BestDirection[0].m_prevRotation;

            m_currentEnemy.SpawnAttackTiles(m_attackPrefab, m_gameManager.AttackTileHolder);

            m_bestDirectionFound = false;
            m_BestDirection.Clear();
        }

        yield return new WaitForSeconds(0.7f);

        if (m_currentEnemy.m_whoWasAttacked.Count > 0)
            m_currentEnemy.Attack();

        m_currentEnemy.m_whoWasAttacked.Clear();

        GameObject[] temp2 = GameObject.FindGameObjectsWithTag("AttackTile");

        // we want to destroy previous spawned attack tiles
        for (int j = 0; j < temp2.Length; j++)
        {
            Destroy(temp2[j]);
        }

        yield return new WaitForSeconds(0.2f);

        m_bestDirectionFound = false;
        m_gameManager.m_isAttacking = false;
    }
}