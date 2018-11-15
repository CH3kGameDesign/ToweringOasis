using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterButton : MonoBehaviour
{
    public bool m_selected = false;

    private void Update()
    {
        
    }

    public void SelectOne()
    {
        GameManager.Instance.playerController.m_Player = UnitManager.Instance.m_Parent[0].GetChild(0).GetComponent<Actor>();
        GameManager.Instance.playerController.m_showHealth = true;
        m_selected = true;
    }

    public void SelectTwo()
    {
        GameManager.Instance.playerController.m_Player = UnitManager.Instance.m_Parent[0].GetChild(1).GetComponent<Actor>();
        GameManager.Instance.playerController.m_showHealth = true;
        m_selected = true;
    }

    public void SelectThree()
    {
        GameManager.Instance.playerController.m_Player = UnitManager.Instance.m_Parent[0].GetChild(2).GetComponent<Actor>();
        GameManager.Instance.playerController.m_showHealth = true;
        m_selected = true;
    }

    public void SelectFour()
    {
        GameManager.Instance.playerController.m_Player = UnitManager.Instance.m_Parent[0].GetChild(3).GetComponent<Actor>();
        GameManager.Instance.playerController.m_showHealth = true;
        m_selected = true;
    }
}
