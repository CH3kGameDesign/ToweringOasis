using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState : BaseState
{
    public override void StartState()
    {

    }
    public override void UpdateState()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Debug.Log("hello");
    }

    public override void EndState()
    {

    }
    public void StartClicked()
    {
        SceneManager.LoadScene(1);
        GameManager.Instance.ChangeState(GameState.Instance);
    }
}
