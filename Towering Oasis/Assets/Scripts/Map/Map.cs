using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Singleton class
public class Map : MonoBehaviour
{
	public static Map Instance; // Static Instance of the class
    public LayerMask m_WalkableMask; // Mask of the area you are allowed to walk on
    public int m_nGridWorldSize; // Grid size you want to create result will be m_nGridWorldSize x m_nGridWorldSize
	public bool m_Debug; // If want to debug the grid

	private float m_nodeRadius; // Radius of a single node
    private float m_nodeDiameter; // equals to radius*2

    [HideInInspector]
	public List<Vector2> m_v2Coordinates; // Coordinates of each node
    
	[HideInInspector]
	public Node[,] m_Grid; // Grid itself

	[HideInInspector]
	public List<Vector3> m_NodesWithUnits; // Nodes with player, enemy or obstacle on top

	[HideInInspector]
	public int m_nGridSizeX, m_nGridSizeY; // For checking how many nodes will fit in the grid and creating grid
	
	private void Awake()
	{
		// Initialising the instance if its not yet been initialised
		if (Instance == null)
			Instance = this;
		else if (Instance != this)
			Destroy(gameObject);

		// Setting the radius and diameter
		m_nodeRadius = 0.5f;
        m_nodeDiameter = m_nodeRadius * 2;

		// Calculating how many nodes will fit the grid
        m_nGridSizeX = Mathf.RoundToInt(m_nGridWorldSize / m_nodeDiameter);
        m_nGridSizeY = m_nGridSizeX;

		m_NodesWithUnits = new List<Vector3>();
	}

	public void CreateGrid()
   {
		// Declaring the grid
        m_Grid = new Node[m_nGridSizeX, m_nGridSizeY];

		// Getting the grid bottom left by
			// check Sebastion Lague's video for explanation
        Vector3 worldBottomLeft = transform.position - Vector3.right * m_nGridWorldSize / 2 - Vector3.forward * m_nGridWorldSize / 2;
		
		// Populating the grid with either walkable or not walkable nodes
        for (int x = 0; x < m_nGridSizeX; x++)
        {
            for (int y = 0; y < m_nGridSizeY; y++)
            {
				// Getting the point node should be created
                Vector3 worldPoint = worldBottomLeft + Vector3.right * (x * m_nodeDiameter + m_nodeRadius) + Vector3.forward * (y * m_nodeDiameter + m_nodeRadius);

				// Checking if the node is walkable or not by performing a collision on the object
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

	// Gets the node from world position
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

	// Gets the position from Coords
    public Vector3 GetPositionFromCoords(int x, int y)
    {
        return m_Grid[x, y].m_v3WorldPosition;
    }

	// Gets the neighbours of the node passed in
    public List<Node> GetNeighbours(Node node, int nHowManyNeighbourIteration = 1, bool isDiagnols = true)
    {
        List<Node> Neighbours = new List<Node>();

		// For how many neighbours u want 
			// for example 3x3 grid neighbours or even 1x1
        for (int x = -nHowManyNeighbourIteration; x <= nHowManyNeighbourIteration; x++)
        {
            for (int y = -nHowManyNeighbourIteration; y <= nHowManyNeighbourIteration; y++)
            {
				// If its the middle one step out of the iteration
                if (x == 0 && y == 0)
                    continue;

				// Get the coordinates of the neighbouring tile
                int checkX = (int)node.m_v2GridCoordinate.x + x;
                int checkY = (int)node.m_v2GridCoordinate.y + y;

				// Check if its in the grid
					// If not skip node
                if (checkX >= 0 && checkX < m_nGridSizeX && checkY >= 0 && checkY < m_nGridSizeY)
                {
					// If its not walkable or player, enemy or obstacle is on top
						// skip
                    if (!m_Grid[checkX, checkY].m_bWalkable /*|| m_Grid[checkX, checkY].m_bIsUnitOnTop*/)
                        continue;

					// else add it to the neighbours list
                    Neighbours.Add(m_Grid[checkX, checkY]);
                }
            }
        }
        return Neighbours;
    }

	//TODO Move this to there respective classes
		// Returns the attack tiles
	public List<Node> GetAttackTiles(Node node, Node playerNode, int nHowManyIterations = 1, int nHowManyTiles = 1)
	{
		List<Node> AttackTiles = new List<Node>();
		
		// The infront off player and want to attack
		Vector2 attackCoord = node.m_v2GridCoordinate;

		// Player coordinates
		Vector2 playerCoord = playerNode.m_v2GridCoordinate;

		/// O equals the player, . equals the nodes, | equals the direction this part handles
		/// .	.	.
		///		|
		///	.	O	.
		///		|
		///	.	.	.
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
							if (!m_Grid[checkX, checkY].m_bWalkable)
								continue;

							AttackTiles.Add(m_Grid[checkX, checkY]);
						}
					}
				}
			}
		}

		/// O equals the player, . equals the nodes, - equals the direction this part handles
		/// .	.	.
		///		
		///	. -	O -	.
		///		
		///	.	.	.
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
							if (!m_Grid[checkX, checkY].m_bWalkable)
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
		// If there are nodesWithUnits count is greater
			// means we have done this before
		if (m_NodesWithUnits.Count > 0)
		{
			// for every node we set unitOnTop to false 
			for (int x = 0; x < m_NodesWithUnits.Count; x++)
			{
				GetNodeFromPosition(m_NodesWithUnits[x]).m_bIsUnitOnTop = false;
			}
		}
		// Clear the list
		m_NodesWithUnits.Clear();

		// Every object in the unitManager 
		for (int i = 0; i < UnitManager.Instance.m_Objects.Count; i++)
		{
			// We set there m_bIsUnitOnTop to true
				// and add it's position to the m_NodesWithUnits 
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