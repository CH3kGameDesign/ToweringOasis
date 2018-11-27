using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : IHeapItem<Node>
{
	public Node m_parent;

	public Vector2 m_v2GridCoordinate;
	public Vector3 m_v3WorldPosition; 

    public bool m_bWalkable;
    public bool m_bIsUnitOnTop;
    public int m_nHeapIndex;
	public int m_nGCost, m_nHCost;
	public int m_nFCost
	{
		get
		{
			return m_nGCost + m_nHCost;
		}
	}

    public Node(int nGridCoordX,
                int nGridCoordY,
                Vector3 v3WorldPos,
                bool isWalkable)
	{
        m_v2GridCoordinate.x = nGridCoordX;
        m_v2GridCoordinate.y = nGridCoordY;
        m_v3WorldPosition.x = v3WorldPos.x;
		m_v3WorldPosition.y = v3WorldPos.y;
		m_v3WorldPosition.z = v3WorldPos.z;
        m_bWalkable = isWalkable;
	}

	public int HeapIndex
	{
		get
		{
			return m_nHeapIndex;
		}
		set
		{
			m_nHeapIndex = value;
		}
	}

	public int CompareTo(Node nodeToCompare)
	{
		int compare = m_nFCost.CompareTo(nodeToCompare.m_nFCost);
		if (compare == 0)
		{
			compare = m_nHCost.CompareTo(nodeToCompare.m_nHCost);
		}
		return -compare;
	}
}
