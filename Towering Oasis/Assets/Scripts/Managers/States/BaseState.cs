using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BaseState : MonoBehaviour
{
    public void OnSceneLoad(Scene scene, LoadSceneMode mode)
    {
        GameManager.Instance.m_stateName = GameStates.GAME;
    }
}
