using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMelee : MonoBehaviour {

    public int chainsawAttackMinDamage;
    public int chainsawAttackDamageRange;

    public int kickAttackMinDamage;
    public int kickAttackDamageRange;

    public int movementSpaces;
    public int health;
    public int healthMax;

    public bool hasMoved;
    public bool hasAttacked;






    public List<Node> path = new List<Node>();
    public bool m_DebugPath;








    // Use this for initialization
    void Start () {
        health = healthMax;
	}

    private void Update()
    {
        if (Input.anyKeyDown) DecideMove();
    }

    public void DecideMove ()
    {
        for (int i = 0; i < GameObject.Find("PlayerCharacters").transform.childCount; i++)
        {
            Debug.Log("try " + i);
            Transform playerChar = GameObject.Find("PlayerCharacters").transform.GetChild(i).transform;
            FindPath(transform.position, playerChar.position);
            Debug.Log("Self = " + transform.position);
            Debug.Log(playerChar.name + " = " + playerChar.position);
            Debug.Log(path.Count);
            
        }
        //if (Is Enemy within 5 blocks)
        {
            //if (Is It Possible To Hit Multiple People)
            {
                //if (Enemies Hit > Allies Hit)
                {
                    //if (Enemies Killed >= Allies Killed)
                    {
                        //Hit Most Possible enemies with chainsaw
                        return;
                    }
                }
            }
            //if (Will Kicking Them Kill Them)
            {
                //Kick Them
                return;
            }
            //if (How Far Away From The Objective Can You Kick Them (> Current Distance = true))
            {
                //Kick Them
                return;
            }
            //Chainsaw Them
            return;
        }
        //if (Can You Kick Ally Within 1 Block Of Them)
        {
            GameObject other = this.gameObject;
            if (other.tag == "AI Melee")
            {
                if (other.GetComponent<AIMelee>().hasAttacked == false)
                {
                    if (other.GetComponent<AIMelee>().health >= other.GetComponent<AIMelee>().healthMax /2)
                    {
                        //if (!Is Ally Already Within 5 Blocks Of Them)
                        {
                            if (other.GetComponent<AIMelee>().hasMoved == false)
                            {
                                //if (!Is Ally Already Within 1 Block Of Them)
                                {
                                    //Kick Ally Closer
                                }
                            }
                        }
                    }
                }
            }
            if (other.tag == "AI Ranged")
            {
                if (other.GetComponent<AIRanged>().hasAttacked == false)
                {
                    if (other.GetComponent<AIRanged>().health >= other.GetComponent<AIRanged>().healthMax / 2)
                    {
                        //if (!Is Ally Already Within 5 Blocks Of Them)
                        {
                            if (other.GetComponent<AIRanged>().hasMoved == false)
                            {
                                //if (!Is Ally Already Within 1 Block Of Them)
                                {
                                    //Kick Ally Closer
                                }
                            }
                        }
                    }
                }
            }
        }
        //if (Is Enemy Further Than 10 Blocks Away)
        {
            if (health < healthMax/2)
            {
                //if (Is Healing Area Within 4 Blocks)
                {
                    //Move Towards Closest Healing Area
                }
            }
        }
        //Move Towards Enemy Closest To Exit
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
