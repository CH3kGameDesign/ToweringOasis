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

    private List<int> distanceToPlayers = new List<int>();
    public int closestPlayer;
    private int distanceToExit;
    private int enemyDistanceToExit;

    public GameObject ChainsawAttackRange;

    public Vector3 Destination;

    public float movementSpeed = 0.3f;

    public bool DebugTrue = false;




    public List<Node> path = new List<Node>();
    public bool m_DebugPath;







    
    // Use this for initialization
    void Start () {
        health = healthMax;
        for (int i = 0; i < GameObject.Find("PlayerCharacters").transform.childCount; i++)
        {
            distanceToPlayers.Add(100);
        }
	}

    private void Update()
    {
        if (Input.anyKeyDown) DecideMove();
    }

    public void DecideMove ()
    {
        for (int i = 0; i < GameObject.Find("PlayerCharacters").transform.childCount; i++)
        {
            distanceToPlayers[i] = 100;
        }

        for (int i = 0; i < GameObject.Find("PlayerCharacters").transform.childCount; i++)
        {
            Transform playerChar = GameObject.Find("PlayerCharacters").transform.GetChild(i).transform;

            Vector3 thisPos = transform.position;
            Vector3 thatPos = playerChar.position;

            int closestNeighbour = 0;
            int howCloseNeighbour = 100;
            List<Node> Neighbours = Map.Instance.GetNeighbours(Map.Instance.GetNodeFromPosition(thatPos));
            for (int j = 0; j < Neighbours.Count; j++)
            {
                FindPath(thisPos, Neighbours[j].m_v3WorldPosition);
                if (DebugTrue)
                    Debug.Log(path.Count + " < " + howCloseNeighbour);
                 if (path.Count < howCloseNeighbour)
                 {
                    if (DebugTrue)
                        Debug.Log(path.Count + " < " + howCloseNeighbour + " won");
                    closestNeighbour = j;
                    howCloseNeighbour = path.Count;
                 }
            }
            thatPos = Neighbours[closestNeighbour].m_v3WorldPosition;

            FindPath(thisPos, thatPos);
            distanceToPlayers[i] = path.Count;
            if (DebugTrue)
                Debug.Log ("Player " + i + ": Closest Neighbour = " + Neighbours[closestNeighbour].m_v3WorldPosition);
            if (i == 0)
            {
                closestPlayer = i;
            } else
            if (distanceToPlayers[i] < distanceToPlayers[closestPlayer])
            {
                closestPlayer = i;
            }
        }
        //Check Each AI's Closest Player
        Debug.Log(gameObject.name + " = " + closestPlayer + " (Closest Player) " + distanceToPlayers[closestPlayer] + " (Distance)");

        if (distanceToPlayers[closestPlayer] <= 4)
        {
            List<Node> Neighbours1 = Map.Instance.GetNeighbours(Map.Instance.GetNodeFromPosition(GameObject.Find("PlayerCharacters").transform.GetChild(closestPlayer).transform.position));
            for (int i = 0; i < GameObject.Find("PlayerCharacters").transform.childCount; i++)
            {
                if (i != closestPlayer)
                {
                    List<Node> Neighbours2 = Map.Instance.GetNeighbours(Map.Instance.GetNodeFromPosition(GameObject.Find("PlayerCharacters").transform.GetChild(i).transform.position));
                    Node player1 = Map.Instance.GetNodeFromPosition(GameObject.Find("PlayerCharacters").transform.GetChild(closestPlayer).transform.position);
                    Node player2 = Map.Instance.GetNodeFromPosition(GameObject.Find("PlayerCharacters").transform.GetChild(i).transform.position);

                    Vector3 thisPos = transform.position;
                    Vector3 thatPos = new Vector3(thisPos.x + 2, 0, thisPos.z + 2);
                    FindPath(thisPos, thatPos);
					List<Node> DestinationList = new List<Node>();
					for (int j = 0; j < 10; j++) {
						DestinationList.Add (path [0]);
					}

                    if (player1.m_v2GridCoordinate.x == player2.m_v2GridCoordinate.x || player1.m_v2GridCoordinate.y == player2.m_v2GridCoordinate.y)
                    {
                        for (int j = 0; j < Neighbours1.Count; j++)
                        {
                            if (DebugTrue)
                                Debug.Log ("1 " + j);
                            for (int k = 0; k < Neighbours2.Count; k++)
                            {
                                if (DebugTrue)
                                    Debug.Log ("2 " + k);
                                if (Neighbours1[j] == Neighbours2[k])
                                {
									FindPath(thisPos, Neighbours1[j].m_v3WorldPosition);
                                    if (DebugTrue)
                                        Debug.Log ("3 " + j + " " + k + " Path.Count = " + path.Count + " < " + DestinationList.Count);

                                    if (path.Count <= DestinationList.Count)
                                    {
										for (int m= 0; m < path.Count; m++) {
                                            if (DebugTrue)
                                                Debug.Log("path[" + m + "] = " + path[m].m_v3WorldPosition);
										}
                                        if (DebugTrue)
                                            Debug.Log ("Destination " + Neighbours1[j].m_v3WorldPosition);
                                        thatPos = Neighbours1[j].m_v3WorldPosition;
                                        DestinationList = path;
                                    }
                                }
                            }
                        }
                        if (DestinationList.Count < 7)
                        {
                            if (DebugTrue)
                                Debug.Log("New Destination");
                            FindPath(thisPos, thatPos);
                            if (path.Count <= 4)
                            {
                                Destination = thatPos;
                                if (DebugTrue)
                                    Debug.Log(gameObject.name + " = " + Destination + " (Destination)");
                                ChainsawAttack();
                                return;
                            }
                        }
                    }
                }
            }
            if (GameObject.Find("PlayerCharacters").transform.GetChild(closestPlayer).GetComponent<Actor>().m_nHealth < kickAttackMinDamage)
            {
                //Kick Them
                return;
            }
            //if (How Far Away From The Objective Can You Kick Them (> Current Distance = true))
            //{
            //Kick Them
            //return;
            //}

            List<Node> Neighbours = Map.Instance.GetNeighbours(Map.Instance.GetNodeFromPosition(GameObject.Find("PlayerCharacters").transform.GetChild(closestPlayer).transform.position));

            int closestNeighbour = 0;
            int howCloseNeighbour = 100;
            for (int j = 0; j < Neighbours.Count; j++)
            {
                FindPath(transform.position, Neighbours[j].m_v3WorldPosition);
                if (path.Count < howCloseNeighbour)
                {
                    closestNeighbour = j;
                    howCloseNeighbour = path.Count;
                }
            }
            Destination = Neighbours[closestNeighbour].m_v3WorldPosition;

            ChainsawAttack();
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
                                //Kick Ally Closer
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
                                //Kick Ally Closer
                            }
                        }
                    }
                }
            }
        }
        if (distanceToPlayers[closestPlayer] >= 10)
        {
            if (health < healthMax/2)
            {
                for (int i = 0; i < GameObject.Find("HealthTiles").transform.childCount; i++)
                {
                    Transform healthTile = GameObject.Find("PlayerCharacters").transform.GetChild(i).transform;

                    Vector3 thisPos = transform.position;
                    Vector3 thatPos = healthTile.position;
                    
                    FindPath(thisPos, thatPos);
                    if (path.Count < 4 && hasMoved == false)
                    {
                        //Move Towards HealthTile
                        return;
                    }
                }
            }
        }
        //Move Towards Enemy Closest To Exit
    }

    private void ChainsawAttack ()
    {
        FindPath(transform.position, Destination);

        transform.position = new Vector3 (Destination.x, 1, Destination.z);
        
        /*
        for (int i = 0; i < path.Count; i++)
        {
            Debug.Log("path Variable " + i + " = " + path[i].m_v2GridCoordinate);
            StartCoroutine(FollowPath(path));
        }
        */
        
        ChainsawAttackRange.SetActive(true);
        ChainsawAttackRange.GetComponent<AIAttackRange>().CheckAttack();

        //Invoke("TurnOffAttack", 1f);

        return;

    }

    public void TurnOffAttack ()
    {
        ChainsawAttackRange.GetComponent<AIAttackRange>().EndAttack();
        ChainsawAttackRange.SetActive(false);
    }


    




    IEnumerator FollowPath(List<Node> path)
    {
        foreach (Node waypoint in path)
        {
            Vector3 pathNodePos = waypoint.m_v3WorldPosition;
            pathNodePos.y = 1.0f;
            transform.position = pathNodePos;
            GetComponent<Actor>().m_ActorPos = pathNodePos;
            yield return new WaitForSeconds(movementSpeed); // skips frames
        }
    }

    public void FindPath(Vector3 startPos, Vector3 endPos)
    {
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
                if (path.Count > 0)
                    path.Clear();

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
