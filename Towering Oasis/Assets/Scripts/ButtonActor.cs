using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonActor : MonoBehaviour
{
    public Actor m_buttonActor;
    public int m_ActorNumber;

    private void Start()
    {
        GetActor();
    }

    private void LateUpdate()
    {
        if (GameObject.FindGameObjectWithTag("GUI").activeSelf)
        {
            if (m_buttonActor.m_nHealth <= 0)
            {
                this.GetComponent<Button>().interactable = false;
            }
        }
    }

    public void SelectActor()
    {
        GameManager.Instance.playerController.m_Player = m_buttonActor;
        GameManager.Instance.playerController.m_showHealth = true;
    }

    public void GetActor()
    {
        m_buttonActor = UnitManager.Instance.m_Parent[0].GetChild(m_ActorNumber).GetComponent<Actor>();
        GetComponentInChildren<Text>().text = m_buttonActor.name;
    }
}
