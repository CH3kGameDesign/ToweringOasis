using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
	public List<Transform> m_Map;
    public LayerMask m_WalkableMask;
    public int m_nGridWorldSize;
    public int m_nGridSizeX, m_nGridSizeY;
    public Transform player;
    public Transform m_NonWalkablePrefab;

    private float m_nodeRadius;
    private float m_nodeDiameter;

    [HideInInspector]
	public List<Vector2> m_v2Coordinates;
    
	[HideInInspector]
	public Node[,] m_Grid;

	private void Awake()
	{
        m_nodeRadius = 0.5f;
        m_nodeDiameter = m_nodeRadius * 2;

        m_nGridSizeX = Mathf.RoundToInt(m_nGridWorldSize / m_nodeDiameter);
        m_nGridSizeY = m_nGridSizeX;

        Transform MapHolder = transform.GetChild(0);
        for(int i = 0; i < MapHolder.transform.childCount; i++)
        {
            m_Map.Add(MapHolder.GetChild(i));
        }
                
        CreateGrid();
	}

    //	public void GenerateMap()
    //	{
    //        int i = 0;
    //		for(int x = 0; x < m_Map.Length; x++)
    //		{
    //			for (int y = 0; y < m_Map.Length; y++)
    //			{
    //				int nTileType = 0;
    //				bool bIsWall = false;
    //				string szTileTag = "Tile";

    //				if (m_Map.)
    //				{
    //					nTileType = 1;
    //					bIsWall = true;
    //					szTileTag = "Obstacle";

    //					if (v2RandomCoords.Count - 1 != i)
    //						i++;
    //				}
    //				else
    //				{
    //					nTileType = 0;
    //					bIsWall = false;
    //					szTileTag = "Tile";
    //				}

    //				Vector3 v3TempPosition = Vector3.zero;
    //				v3TempPosition.x = (-m_v2MapSize.x / 2 + x) + 0.5f;
    //				v3TempPosition.y = -6.0f;
    //				v3TempPosition.z = (-m_v2MapSize.y / 2 + y) + 0.5f;

    //				m_Grid[x, y] = new Node(Instantiate(
    //											m_Tiles[nTileType].m_TilePrefab,
    //											v3TempPosition,
    //											Quaternion.Euler(Vector3.zero)),
    //										m_Tiles[nTileType].m_TileMaterial,
    //										x,
    //										y,
    //										v3TempPosition.x,
    //										v3TempPosition.y,
    //										v3TempPosition.z,
    //										bIsWall);

    //				m_Grid[x, y].m_TilePrefab.parent = MapHolder.transform;

    //				m_Grid[x, y].m_TilePrefab.localScale = new Vector3(1 * (1 - m_fOutline), m_Grid[x, y].m_TilePrefab.transform.localScale.y, 1 * (1 - m_fOutline));
    //				m_Grid[x, y].m_TilePrefab.tag = szTileTag;
    //			}
    //		}
    //	}

    public void CreateGrid()
    {
        m_Grid = new Node[m_nGridSizeX, m_nGridSizeY];
        Vector3 worldBottomLeft = transform.position - Vector3.right * m_nGridWorldSize / 2 - Vector3.forward * m_nGridWorldSize / 2;
        int i = 0;
        for (int x = 0; x < m_nGridSizeX; x++)
        {
            for (int y = 0; y < m_nGridSizeY; y++)
            {
                Vector3 worldPoint = worldBottomLeft + Vector3.right * (x * m_nodeDiameter + m_nodeRadius) + Vector3.forward * (y * m_nodeDiameter + m_nodeRadius);
                bool walkable = Physics.CheckSphere(worldPoint, m_nodeRadius, m_WalkableMask);

                if (walkable)
                {
                    m_Grid[x, y] = new Node(m_Map[i],
                                            x,
                                            y,
                                            worldPoint,
                                            walkable);
                    //i++;
                }
                else
                {
                    m_Grid[x, y] = new Node(m_NonWalkablePrefab,
                                            x,
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
                    if (m_Grid[checkX, checkY].m_bWalkable || m_Grid[checkX, checkY].m_bWalkable)
                        continue;

                    Neighbours.Add(m_Grid[checkX, checkY]);
                }
            }
        }
        return Neighbours;
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

    //	private List<Vector2> GetRandomCoords()
    //	{
    //		List<Vector2> RandomCoords = new List<Vector2>();

    //		for(int i = 0; i < obstacleNumber;)
    //		{
    //			Vector2 RandomCoordinate = m_v2ShuffledCoordinates.Dequeue();
    //			m_v2ShuffledCoordinates.Enqueue(RandomCoordinate);
    //			if (RandomCoordinate.y > 1 && RandomCoordinate.y < 13)
    //			{
    //				RandomCoords.Add(RandomCoordinate);
    //				i++;
    //			}
    //		}

    //		// Delegate sorts the Vectors
    //			// found on this link: https://stackoverflow.com/questions/289010/c-sharp-list-sort-by-x-then-y
    //		RandomCoords.Sort(delegate (Vector2 a, Vector2 b)
    //		{
    //			int xdiff = a.x.CompareTo(b.x);
    //			if (xdiff != 0) return xdiff;
    //			else return a.y.CompareTo(b.y);
    //		});

    //		return RandomCoords;
    //	}

    void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(m_nGridWorldSize, 1, m_nGridWorldSize));


        if (m_Grid != null)
        {
            Node PlayerNode = GetNodeFromPosition(player.position);
            foreach (Node n in m_Grid)
            {
                Gizmos.color = (n.m_bWalkable) ? Color.white : Color.red;
                if(n == PlayerNode)
                {
                    Gizmos.color = Color.blue;
                }
                Gizmos.DrawCube(n.m_v3WorldPosition, Vector3.one * (m_nodeDiameter - .1f));
            }
        }
    }
}
