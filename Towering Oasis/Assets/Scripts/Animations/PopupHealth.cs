using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupHealth : MonoBehaviour
{
	private void Start()
	{
		// Destorys object after one second
		Destroy(gameObject, 1);
	}
}
