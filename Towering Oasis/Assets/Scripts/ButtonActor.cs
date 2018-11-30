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
        GameManager.Instance.playerController.m_bshowUI = true;
        GameManager.Instance.playerController.m_playerMode = PLAYERMODE.MENU;
        
        GameManager.Instance.m_currentActor = GameManager.Instance.playerController.m_Player;
        GameManager.Instance.playerController.m_v3PlayerTilePos = GameManager.Instance.playerController.m_Player.m_ActorPos;
        GameManager.Instance.playerController.m_v3PlayerTilePos.y = 0.1f;
        Vector2 m_v2UiPosition;

        // Get the Player Pos
        m_v2UiPosition = Vector2.zero;
        m_v2UiPosition.x = Input.mousePosition.x;
        m_v2UiPosition.y = Screen.height - Input.mousePosition.y;

        // Show UI(attack/move buttons)
        if (GameManager.Instance.playerController.m_Player != null)
            GameManager.Instance.playerController.m_bshowUI = true;

        GameManager.Instance.playerController.m_SelectedPrefab = GameManager.Instance.playerController.m_Player.gameObject.transform.GetChild(2).gameObject;
        GameManager.Instance.playerController.m_showHealth = true;

        for (int i = 0; i < GameManager.Instance.MoveableTileHolder.transform.childCount; i++)
        {
            Destroy(GameManager.Instance.MoveableTileHolder.transform.GetChild(i).gameObject);
        }
    }

    public void GetActor()
    {
        m_buttonActor = UnitManager.Instance.m_Parent[0].GetChild(m_ActorNumber).GetComponent<Actor>();
        GetComponentInChildren<Text>().text = m_buttonActor.m_classType;
    }
}
