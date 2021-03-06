﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTurn : MonoBehaviour {

    // Use this for initialization

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void endTurn()
    {
        if (GameManager.Instance.m_bcontrolsAvailable == true)
        {
            //GameManager.Instance.m_bcontrolsAvailable = false;
            //GameManager.Instance.m_nEnemiesAttacked = false;
            //GameManager.Instance.m_nPlayerMoves = 0;
            //GameManager.Instance.m_nEnemiesMoves = 0;
            for (int x = 0; x < UnitManager.Instance.m_nPlayersAlive; x++)
            {
                UnitManager.Instance.m_Parent[0].GetChild(x).GetComponent<Actor>().m_bMoved = true;
                UnitManager.Instance.m_Parent[0].GetChild(x).GetComponent<Actor>().m_bAttack = true;
                UnitManager.Instance.m_Parent[0].GetChild(x).GetComponent<Actor>().m_bSkip = true;
                GameManager.Instance.GetChildObject(UnitManager.Instance.m_Parent[0].GetChild(x).GetComponent<Actor>().transform, "Ring").GetChild(0).GetComponent<MeshRenderer>().sharedMaterial = GameManager.Instance.m_redRing;
            }
            GameManager.Instance.m_nPlayerMoves = UnitManager.Instance.m_nPlayersAlive;
            GameManager.Instance.m_actions.SetActive(false);
            GameManager.Instance.playerController.m_bshowUI = false;
            GameManager.Instance.m_HealthBar.SetActive(false);
            List<GameObject> temp = new List<GameObject>();
            temp.AddRange(GameObject.FindGameObjectsWithTag("AttackTile"));
            temp.AddRange(GameObject.FindGameObjectsWithTag("MovableTile"));

            // we want to destroy previous spawned attack tiles
            for (int i = 0; i < temp.Count; i++)
            {
                Destroy(temp[i]);
            }
        }
    }
}
