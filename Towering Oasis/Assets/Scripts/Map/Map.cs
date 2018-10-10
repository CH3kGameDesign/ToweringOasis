using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
	public static Map Instance;
    public LayerMask m_WalkableMask;
    public int m_nGridWorldSize;
	public bool m_Debug;

	private float m_nodeRadius;
    private float m_nodeDiameter;

    [HideInInspector]
	public List<Vector2> m_v2Coordinates;
    
	[HideInInspector]
	public Node[,] m_Grid;

	[HideInInspector]
	public List<Vector3> m_NodesWithUnits;

	[HideInInspector]
	public int m_nGridSizeX, m_nGridSizeY;
	
	private void Awake()
	{
		if (Instance == null)
			Instance = this;
		else if (Instance != this)
			Destroy(gameObject);

		m_nodeRadius = 0.5f;
        m_nodeDiameter = m_nodeRadius * 2;

        m_nGridSizeX = Mathf.RoundToInt(m_nGridWorldSize / m_nodeDiameter);
        m_nGridSizeY = m_nGridSizeX;
		m_NodesWithUnits = new List<Vector3>();
	}

	public void CreateGrid()
   {
        m_Grid = new Node[m_nGridSizeX, m_nGridSizeY];
        Vector3 worldBottomLeft = transform.position - Vector3.right * m_nGridWorldSize / 2 - Vector3.forward * m_nGridWorldSize / 2;
		
        for (int x = 0; x < m_nGridSizeX; x++)
        {
            for (int y = 0; y < m_nGridSizeY; y++)
            {
                Vector3 worldPoint = worldBottomLeft + Vector3.right * (x * m_nodeDiameter + m_nodeRadius) + Vector3.forward * (y * m_nodeDiameter + m_nodeRadius);
                bool walkable = Physics.CheckSphere(worldPoint, m_nodeRadius - 0.1f, m_WalkableMask);

                if (walkable)
                {
                    m_Grid[x, y] = new Node(x,
                                            y,
                                            worldPoint,
                                            walkable);
                }
                else
                {
                    m_Grid[x, y] = new Node(x,
                                            y,
                                            worldPoint,
                                            walkable);
                }
            }
        }
   }

    public Node GetNodeFromPosition(Vector3 worldPosition)
    {
        float percentX = (worldPosition.x + m_nGridSizeX / 2) / m_nGridSizeX;
        float percentY = (worldPosition.z + m_nGridSizeY / 2) / m_nGridSizeY;

        percentX = Mathf.Clamp01(percentX);
        percentY = Mathf.Clamp01(percentY);

        int x = Mathf.RoundToInt((m_nGridSizeX - 1) * percentX);
        int y = Mathf.RoundToInt((m_nGridSizeY - 1) * percentY);

        return m_Grid[x, y];
    }

    public Vector3 GetPositionFromCoords(int x, int y)
    {
        return m_Grid[x, y].m_v3WorldPosition;
    }

    public List<Node> GetNeighbours(Node node, int nHowManyNeighbourIteration = 1, bool isDiagnols = true)
    {
        List<Node> Neighbours = new List<Node>();

        for (int x = -nHowManyNeighbourIteration; x <= nHowManyNeighbourIteration; x++)
        {
            for (int y = -nHowManyNeighbourIteration; y <= nHowManyNeighbourIteration; y++)
            {
                if (x == 0 && y == 0)
                    continue;

                int checkX = (int)node.m_v2GridCoordinate.x + x;
                int checkY = (int)node.m_v2GridCoordinate.y + y;

                if (checkX >= 0 && checkX < m_nGridSizeX && checkY >= 0 && checkY < m_nGridSizeY)
                {
                    if (!m_Grid[checkX, checkY].m_bWalkable /*|| m_Grid[checkX, checkY].m_bIsUnitOnTop*/)
                        continue;

                    Neighbours.Add(m_Grid[checkX, checkY]);
                }
            }
        }
        return Neighbours;
    }

	public List<Node> GetAttackTiles(Node node, Node playerNode, /*Vector3 pos,*/ int nHowManyIterations = 1, int nHowManyTiles = 1)
	{
		List<Node> AttackTiles = new List<Node>();
		
		Vector2 attackCoord = node.m_v2GridCoordinate;
		Vector2 playerCoord = playerNode.m_v2GridCoordinate;

		if ((attackCoord.y == playerCoord.y + 1 || attackCoord.y == playerCoord.y - 1) && attackCoord.x == playerCoord.x)
		{
			for (int x = -nHowManyIterations; x <= nHowManyIterations; x++)
			{
				for (int y = -nHowManyIterations; y <= nHowManyIterations; y++)
				{
					if (x == 0 && y == 0 || x == 1 && y == 0 || x == -1 && y == 0)
					{
						int checkX = (int)node.m_v2GridCoordinate.x + x;
						int checkY = (int)node.m_v2GridCoordinate.y + y;

						if (checkX >= 0 && checkX < m_nGridSizeX && checkY >= 0 && checkY < m_nGridSizeY)
						{
							if (!m_Grid[checkX, checkY].m_bWalkable /*|| m_Grid[checkX, checkY].m_bIsUnitOnTop*/)
								continue;

							AttackTiles.Add(m_Grid[checkX, checkY]);
						}
					}
				}
			}
		}
		
		if ((attackCoord.x == playerCoord.x + 1 || attackCoord.x == playerCoord.x - 1) && attackCoord.y == playerCoord.y)
		{
			for (int x = -nHowManyIterations; x <= nHowManyIterations; x++)
			{
				for (int y = -nHowManyIterations; y <= nHowManyIterations; y++)
				{
					if (x == 0 && y == 0 || x == 0 && y == 1 || x == 0 && y == -1)
					{
						int checkX = (int)node.m_v2GridCoordinate.x + x;
						int checkY = (int)node.m_v2GridCoordinate.y + y;

						if (checkX >= 0 && checkX < m_nGridSizeX && checkY >= 0 && checkY < m_nGridSizeY)
						{
							if (!m_Grid[checkX, checkY].m_bWalkable /*|| m_Grid[checkX, checkY].m_bIsUnitOnTop*/)
								continue;

							AttackTiles.Add(m_Grid[checkX, checkY]);
						}
					}
				}
			}
		}

		return AttackTiles;
	}

	private void GenerateCoords()
    {
        m_v2Coordinates = new List<Vector2>();
        for (int x = 0; x < m_nGridSizeX; x++)
        {
            for (int y = 0; y < m_nGridSizeY; y++)
            {
                m_v2Coordinates.Add(new Vector2(x, y));
            }
        }
    }

	public void UpdateUnitOnTop()
	{
		if (m_NodesWithUnits.Count > 0)
		{
			for (int x = 0; x < m_NodesWithUnits.Count; x++)
			{
				GetNodeFromPosition(m_NodesWithUnits[x]).m_bIsUnitOnTop = false;
			}
		}
		m_NodesWithUnits.Clear();
		for (int i = 0; i < UnitManager.Instance.m_Objects.Count; i++)
		{
			if (UnitManager.Instance.m_Objects[i] != null)
			{
				Node tempNode = GetNodeFromPosition(UnitManager.Instance.m_Objects[i].position);
				tempNode.m_bIsUnitOnTop = true;
				m_NodesWithUnits.Add(tempNode.m_v3WorldPosition);
			}
		}
	}

	void OnDrawGizmos()
	{
		if (m_Debug)
		{
			Gizmos.DrawWireCube(transform.position, new Vector3(m_nGridWorldSize, 1, m_nGridWorldSize));


			if (m_Grid != null)
			{
				List<Node> ObjectNode = new List<Node>();
				for (int i = 0; i < UnitManager.Instance.m_Objects.Count; i++)
				{
					ObjectNode.Add(GetNodeFromPosition(UnitManager.Instance.m_Objects[i].position));
				}
				foreach (Node n in m_Grid)
				{
					Gizmos.color = (n.m_bWalkable) ? Color.white : Color.red;
					if (ObjectNode.Contains(n))
					{
						Gizmos.color = Color.blue;
					}
					Gizmos.DrawCube(n.m_v3WorldPosition, Vector3.one * (m_nodeDiameter - .1f));
				}
			}
		}
	}
}