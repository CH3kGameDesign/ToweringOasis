using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
	void Start ()
	{
		// Creates Grid
		Map.Instance.CreateGrid();

		// Gets all players, enemies and obstacles in scene
		UnitManager.Instance.UpdateObject();

		// Updates where on the grid player, enemies and obstacles are on
		Map.Instance.UpdateUnitOnTop();
	}
}
