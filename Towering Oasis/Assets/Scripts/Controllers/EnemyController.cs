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
    public int m_preference;
    public Vector3 m_prevRotation;

    public Direction(int preference, Vector3 prevRotation)
    {
        m_preference = preference;
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
    public GameObject m_SelectedPrefab;
	public List<Actor> m_enemyPreference = new List<Actor>();

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
		if (UnitManager.Instance.m_Parent[0].childCount > 0)
		{ 
            if (!m_gameManager.m_bcontrolsAvailable && !m_gameManager.m_isMoving && !m_gameManager.m_isAttacking)
			{
				m_enemyPreference.Clear();
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
                m_SelectedPrefab = m_currentEnemy.gameObject.transform.GetChild(0).gameObject;
                m_SelectedPrefab.SetActive(true);

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
				List<Node> path = Pathfinding.Instance.path;
                if (path.Count > m_Enemies[m_gameManager.m_nEnemiesMoves].m_nHowManyTiles)
                {
                    for (int i = path.Count - 1; i > m_Enemies[m_gameManager.m_nEnemiesMoves].m_nHowManyTiles - 1; i--)
                    {
                        path.RemoveAt(i);
                    }
                }
                //Material temp = this.transform.GetComponentInChildren<Renderer>().material;
                //temp.SetFloat("_Animation", 1);
                //temp.SetFloat("_FrameRate", 24);
                //temp.SetFloat("_Frames", 8);
                m_Enemies[m_gameManager.m_nEnemiesMoves].Move(path);
                //temp.SetFloat("_Animation", 3);
                //temp.SetFloat("_FrameRate", 24);
                //temp.SetFloat("_Frames", 5);
            }

            if (m_currentEnemy.m_bStartAttack && m_nhasAttacked == 0)
			{
				GameManager.Instance.m_isMoving = false;
				m_nhasAttacked++;
                m_bestDirectionFound = true;
                StartCoroutine(EnemyAttack());
                m_currentEnemy.m_bStartAttack = false;
                m_gameManager.m_nEnemiesMoves++;
            }

            if (m_gameManager.m_nEnemiesMoves == m_Enemies.Count)
            {
                m_gameManager.m_bcontrolsAvailable = true;
                for(int x = 0; x < UnitManager.Instance.m_nPlayersAlive; x++)
                GameManager.Instance.GetChildObject(UnitManager.Instance.m_Parent[0].GetChild(x).GetComponent<Actor>().transform, "Ring").GetChild(0).GetComponent<MeshRenderer>().sharedMaterial = GameManager.Instance.m_whiteRing;
            }
        }
    }

    IEnumerator EnemyAttack()
	{
		m_gameManager.m_isAttacking = true;

        if (m_gameManager.m_isMoving)
            yield return new WaitForSeconds(3f);

        if(m_bestDirectionFound)
        { 
            for (int i = 0; i < 8;)
            {
                GameManager.Instance.GetChildObject(m_currentEnemy.transform, "Ring").transform.Rotate(0.0f, 45.0f, 0.0f);

                Vector3 rot = GameManager.Instance.GetChildObject(m_currentEnemy.transform, "Ring").transform.eulerAngles;

                m_BestDirection.Add(new Direction(0, rot));
                m_currentEnemy.SpawnAttackTiles(m_attackPrefab, m_gameManager.AttackTileHolder);

                if (i < 8)
                    yield return new WaitForSeconds(0.2f);

                m_BestDirection[m_BestDirection.Count - 1].m_preference = m_enemyPreference.Count;

                m_currentEnemy.m_whoWasAttacked.Clear();
				m_enemyPreference.Clear();

				GameObject[] temp = GameObject.FindGameObjectsWithTag("AttackTile");

                // we want to destroy previous spawned attack tiles
                for (int j = 0; j < temp.Length; j++)
                {
                    Destroy(temp[j]);
                }

                i++;
            }
            m_currentEnemy.m_whoWasAttacked.Clear();
			m_enemyPreference.Clear();

			m_BestDirection = m_BestDirection.OrderByDescending(o => o.m_preference).ToList<Direction>();

            GameManager.Instance.GetChildObject(m_currentEnemy.transform, "Ring").transform.eulerAngles = m_BestDirection[0].m_prevRotation;

            m_currentEnemy.SpawnAttackTiles(m_attackPrefab, m_gameManager.AttackTileHolder);

            m_bestDirectionFound = false;
            m_BestDirection.Clear();
        }

        yield return new WaitForSeconds(0.7f);

        if (m_currentEnemy.m_whoWasAttacked.Count > 0)
            m_currentEnemy.Attack();

        m_currentEnemy.m_whoWasAttacked.Clear();
		m_enemyPreference.Clear();
		m_SelectedPrefab.SetActive(false);

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