using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditReturn : MonoBehaviour {

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.anyKeyDown)
        {
            GameManager.Instance.ResetGame();
            GameManager.Instance.ResetGUI();

            if (!GameManager.Instance.m_actions.activeSelf)
            {
                GameManager.Instance.m_actions.transform.position = new Vector3(-70, -70, -70);
                GameManager.Instance.m_actions.SetActive(true);
            }

            GameManager.Instance.m_PauseMenuPanel.SetActive(false);
            GameManager.Instance.m_MainMenuPanel.SetActive(true);
            GameManager.Instance.m_isLevelLoading = true;
            GameManager.Instance.m_stateName = GameStates.MAINMENU;
            SceneManager.LoadScene(0);

        }
    }
}
