using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding : MonoBehaviour
{
	public static Pathfinding Instance;
    public List<Node> path = new List<Node>();
    public bool m_DebugPath;

	private void Awake()
	{
		if (Instance == null)
			Instance = this;
		else if (Instance != this)
			Destroy(gameObject);
	}

	public void FindPath(Vector3 startPos, Vector3 endPos)
    {
        if (path.Count > 0)
            path.Clear();

        Node startNode = Map.Instance.GetNodeFromPosition(startPos);
        Node endNode = Map.Instance.GetNodeFromPosition(endPos);

        Heap<Node> openList = new Heap<Node>((int)Map.Instance.m_nGridSizeX * (int)Map.Instance.m_nGridSizeY);
        HashSet<Node> closedList = new HashSet<Node>();
        openList.Add(startNode);

        while (openList.Count > 0)
        {
            Node currentNode = openList.RemoveFirst();
            closedList.Add(currentNode);

            if (currentNode == endNode)
            {
                RetracePath(startNode, endNode);
                return;
            }
            List<Node> Neighbours = Map.Instance.GetNeighbours(currentNode);

            foreach (Node neighbour in Neighbours)
            {
                if (!neighbour.m_bWalkable || neighbour.m_bIsUnitOnTop || closedList.Contains(neighbour))
                    continue;

                int newMovementCostToNeighbour = currentNode.m_nGCost + GetDistance(currentNode, neighbour);
                if (newMovementCostToNeighbour < neighbour.m_nGCost || !openList.Contains(neighbour))
                {
                    neighbour.m_nGCost = newMovementCostToNeighbour;
                    neighbour.m_nHCost = GetDistance(currentNode, endNode);
                    neighbour.m_parent = currentNode;

                    if (!openList.Contains(neighbour))
                        openList.Add(neighbour);
                    else
                        openList.UpdateItem(neighbour);
                }
            }
        }
    }

    private void RetracePath(Node startNode, Node endNode)
    {
        endNode.m_bIsUnitOnTop = true;
        startNode.m_bIsUnitOnTop = false;
        Node currentNode = endNode;

        while (currentNode != startNode)
        {
            path.Add(currentNode);
            currentNode = currentNode.m_parent;
        }
        path.Reverse();
    }

    private int GetDistance(Node nodeA, Node nodeB)
    {
        int dstX = (int)Mathf.Abs(nodeA.m_v2GridCoordinate.x - nodeB.m_v2GridCoordinate.x);
        int dstY = (int)Mathf.Abs(nodeA.m_v2GridCoordinate.y - nodeB.m_v2GridCoordinate.y);

        //Heuristic seen from redblobgames Diagonal distance
        //Link: http://theory.stanford.edu/~amitp/GameProgramming/Heuristics.html#S7
        return 10 * (dstX + dstY) + (14 - 2 * 10) * Mathf.Min(dstX, dstY);
    }
}