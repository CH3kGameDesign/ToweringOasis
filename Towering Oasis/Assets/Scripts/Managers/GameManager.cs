using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnumGameState
{
    MAINMENU,
    PAUSEMENU,
    GAME,
    GAMEOVER,

    COUNT
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public BaseState m_currentState;
    public bool m_bchangeStateOccured;

    private void Start()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);

        m_bchangeStateOccured = false;
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (m_currentState == null)
            m_currentState = MainMenu.Instance;

        if (m_bchangeStateOccured)
        {
            m_currentState.StartState();   
            m_bchangeStateOccured = false;
        }
        
        m_currentState.UpdateState();


    }
    public void ChangeState(BaseState state)
    {
        m_currentState.EndState();
        m_currentState = state;
        m_bchangeStateOccured = true;
    }
}
