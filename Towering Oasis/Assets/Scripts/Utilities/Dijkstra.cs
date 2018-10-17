using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dijkstra : MonoBehaviour
{
	public static Dijkstra Instance; // Static instace of the class
	public List<Node> m_validMoves = new List<Node>(); // The path we will calculated
	public bool m_DebugPath; // If we want to debug out path

	private void Awake()
	{
		// Initialising the instance if its not yet been initialised
		if (Instance == null)
			Instance = this;
		else if (Instance != this)
			Destroy(gameObject);
	}

	public void FindValidMoves(Vector3 startPos, int allowedTiles)
	{
		// If there is already a path clear it
		if (m_validMoves.Count > 0)
			m_validMoves.Clear();

		// The starting point
		Node startNode = Map.Instance.GetNodeFromPosition(startPos);

		// Creating a binary tree for paths that can be taken from the currentnode
		Queue<Node> queue = new Queue<Node>();

		// Add our starting point on the openlist
		queue.Enqueue(startNode);
		int i = 0;
		while (queue.Count > 0)
		{
			// Initialise the current node to openlist's first node and remove it from the openlist
			// add it to the closedlist cuz its being searched
			Node currentNode = queue.Dequeue();

			List<Node> Neighbours = Map.Instance.GetNeighbours(currentNode);

			// We search thru the neighbours until we find the best travel cost
			// to another node
			foreach (Node neighbour in Neighbours)
			{
				if (!neighbour.m_bWalkable || neighbour.m_bIsUnitOnTop)
					continue;

				int newMovementCostToNeighbour = currentNode.m_nGCost + 1;
				if (newMovementCostToNeighbour < neighbour.m_nGCost || !queue.Contains(neighbour))
				{
					neighbour.m_nGCost = newMovementCostToNeighbour;
					neighbour.m_nHCost = 1;
					neighbour.m_parent = currentNode;

					if (neighbour.m_nGCost <= allowedTiles)
						queue.Enqueue(neighbour);
				}
			}

			if (currentNode.m_nGCost > 0 && currentNode.m_nGCost <= allowedTiles)
				m_validMoves.Add(currentNode);
			i++;
			if (i > 19)
				return;

		}
	}

	// Reverse the path 
	//private void RetracePath(Node startNode, Node endNode)
	//{
	//	endNode.m_bIsUnitOnTop = true;
	//	startNode.m_bIsUnitOnTop = false;
	//	Node currentNode = endNode;

	//	while (currentNode != startNode)
	//	{
	//		path.Add(currentNode);
	//		currentNode = currentNode.m_parent;
	//	}
	//	path.Reverse();
	//}
}