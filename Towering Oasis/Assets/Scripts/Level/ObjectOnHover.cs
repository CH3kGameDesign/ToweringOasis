using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectOnHover : MonoBehaviour
{
	// TODO move this to parent
	private void OnMouseOver()
	{
		if(GameManager.Instance.m_bcontrolsAvailable)
			gameObject.SetActive(false);
	}

	private void OnMouseExit()
	{
		if (GameManager.Instance.m_bcontrolsAvailable)
			gameObject.SetActive(true); 
	}
}
