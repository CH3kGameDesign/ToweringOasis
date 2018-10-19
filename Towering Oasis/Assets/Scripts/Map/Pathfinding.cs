using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding : MonoBehaviour
{
    public static Pathfinding Instance; // Static instace of the class
    public List<Node> path = new List<Node>(); // The path we will calculated
    public bool m_DebugPath; // If we want to debug out path

    private void Awake()
    {
        // Initialising the instance if its not yet been initialised
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
    }

    public void FindPath(Vector3 startPos, Vector3 endPos, bool isGettingDistance = false, bool isAStar = true)
    {
        // If there is already a path clear it
        if (path.Count > 0)
            path.Clear();

        // The starting point
        Node startNode = Map.Instance.GetNodeFromPosition(startPos);

        // The end point
        Node endNode = Map.Instance.GetNodeFromPosition(endPos);

        // Creating a binary tree for paths that can be taken from the currentnode
        Heap<Node> openList = new Heap<Node>((int)Map.Instance.m_nGridSizeX * (int)Map.Instance.m_nGridSizeY);

        // Nodes we have already searched
        HashSet<Node> closedList = new HashSet<Node>();

        // Add our starting point on the openlist
        openList.Add(startNode);


        while (openList.Count > 0)
        {
            // Initialise the current node to openlist's first node and remove it from the openlist
            // add it to the closedlist cuz its being searched
            Node currentNode = openList.RemoveFirst();
            closedList.Add(currentNode);

            // If the currentNode is equals to the endNode 
            // we've found our path
            if (currentNode == endNode)
            {
                RetracePath(startNode, endNode);
                return;
            }

            List<Node> Neighbours = Map.Instance.GetNeighbours(currentNode);

            // We search thru the neighbours until we find the best travel cost
            // to another node
            foreach (Node neighbour in Neighbours)
            {
                if (!neighbour.m_bWalkable || (neighbour.m_bIsUnitOnTop && !isGettingDistance) || closedList.Contains(neighbour))
                    continue;

                int newMovementCostToNeighbour = currentNode.m_nGCost + GetDistance(currentNode, neighbour, isAStar);
                if (newMovementCostToNeighbour < neighbour.m_nGCost || !openList.Contains(neighbour))
                {
                    neighbour.m_nGCost = newMovementCostToNeighbour;
                    neighbour.m_nHCost = GetDistance(currentNode, endNode, isAStar);
                    neighbour.m_parent = currentNode;

                    if (!openList.Contains(neighbour))
                        openList.Add(neighbour);
                    else
                        openList.UpdateItem(neighbour);
                }
            }
        }
    }

    // Reverse the path 
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

    public int GetDistance(Node nodeA, Node nodeB, bool isAStar)
    {
        if (isAStar)
        {
            int dstX = (int)Mathf.Abs(nodeA.m_v2GridCoordinate.x - nodeB.m_v2GridCoordinate.x);
            int dstY = (int)Mathf.Abs(nodeA.m_v2GridCoordinate.y - nodeB.m_v2GridCoordinate.y);

            //Heuristic seen from redblobgames Diagonal distance
            //Link: http://theory.stanford.edu/~amitp/GameProgramming/Heuristics.html#S7
            return 10 * (dstX + dstY) + (14 - 2 * 10) * Mathf.Min(dstX, dstY);
        }
        else
        {
            return 0;
        }
    }
}