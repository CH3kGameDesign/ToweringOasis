using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonActor : MonoBehaviour
{
    public Actor m_buttonActor = null;
    public int m_ActorNumber;

    private void Start()
    {
    }

    private void LateUpdate()
    {
        if (GameObject.FindGameObjectWithTag("GUI").activeSelf)
        {
            if (m_buttonActor != null && m_buttonActor.m_nHealth <= 0)
            {
                GameManager.Instance.GUIReset();
            }

            m_buttonActor = UnitManager.Instance.m_Parent[0].GetChild(m_ActorNumber).GetComponent<Actor>();

            if(m_buttonActor != null)
                GetComponentInChildren<Text>().text = m_buttonActor.name;
        }
    }

    //private void LateUpdate()
    //{
    //    if (GameObject.FindGameObjectWithTag("GUI").activeSelf && m_buttonActor != null)
    //    {
    //        if (m_buttonActor.m_nHealth <= 0)
    //        {
    //            Button thisButton = GetComponent<Button>();
    //            thisButton.GetComponent<Image>().color = Color.grey;
    //            thisButton.interactable = false;

    //            GameManager.Instance.GUIReset();
    //        }
    //    }
    //}

    public void SelectActor()
    {
        GameManager.Instance.playerController.m_Player = m_buttonActor;
        GameManager.Instance.playerController.m_showHealth = true;
        //m_selected = true;
    }
}
