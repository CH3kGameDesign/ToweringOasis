using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
	public static DontDestroy Instance;

	private void Awake()
	{
		if (Instance == null)
			Instance = this;
		else if (Instance != this)
			Destroy(gameObject);

		DontDestroyOnLoad(transform.gameObject);
	}

	public void Move()
	{
		GameManager.Instance.playerController.Move();
	}

	public void Attack()
	{
		GameManager.Instance.playerController.Attack();
	}

	public void Skip()
	{
		GameManager.Instance.playerController.Skip();
	}
}
