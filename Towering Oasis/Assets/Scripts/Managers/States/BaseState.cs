using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseState : MonoBehaviour
{
    public static BaseState Instance;
    public string m_stateName;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
    }

    public virtual void StartState()
    {

    }

    public virtual void UpdateState()
    {

    }

    public virtual void EndState()
    {

    }
}
