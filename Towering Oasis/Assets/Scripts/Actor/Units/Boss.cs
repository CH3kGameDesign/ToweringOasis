using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Actor
{
    public int m_SpawnPerTurn = 1;
    public Transform[] m_enemySpawns;
    public List<Node> m_walkableTiles;
	public int m_levelIterations;
	private int m_prevLevelIterations;

    public override void Start()
    {
		if (m_levelIterations == 0)
			m_levelIterations = 1;

		m_prevLevelIterations = m_levelIterations;

		base.Start();
        m_walkableTiles = new List<Node>();
        for(int x = 0; x < Map.Instance.m_nGridWorldSize; x++)
        {
            for (int y = 0; y < Map.Instance.m_nGridWorldSize; y++)
            {
                if (Map.Instance.m_Grid[x, y].m_bWalkable && !Map.Instance.m_Grid[x, y].m_bIsUnitOnTop)
                    m_walkableTiles.Add(Map.Instance.m_Grid[x, y]);
            }
        }
		UnitManager.Instance.m_Objects.Add(transform);
    }

    public void myUpdate()
    {
		if (m_levelIterations == 0)
		{
			m_bMoved = true;
			m_bAttack = true;
			int enemyToSpawn = Random.Range(0, m_enemySpawns.Length);
			int tileToSpawn = Random.Range(0, m_walkableTiles.Count);

			Vector3 tempPos = m_walkableTiles[tileToSpawn].m_v3WorldPosition;
			tempPos.y = 1.0f;

			Transform go = Instantiate(m_enemySpawns[enemyToSpawn], tempPos, new Quaternion(0, 0, 0, 0));
			go.parent = GameManager.Instance.enemyController.gameObject.transform;
			UnitManager.Instance.m_Objects.Add(go);
			Map.Instance.UpdateUnitOnTop();
			m_levelIterations = m_prevLevelIterations;
		}
		m_levelIterations--;
	}
}
