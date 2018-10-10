using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialManager : MonoBehaviour
{
	public static MaterialManager Instance = null;	
	public Dictionary<string, Material> m_Materials;
	public MaterialTypes[] m_MaterialsTypes;

	private void Awake()
	{
		if (Instance == null)
			Instance = this;
		else if (Instance != this)
			Destroy(gameObject);

		m_Materials = new Dictionary<string, Material>();
		foreach(MaterialTypes m in m_MaterialsTypes)
		{
			m_Materials.Add(m.MaterialName, m.Material);
		}
	}

	/* Serialized classes only*/
	[System.Serializable]
	public class MaterialTypes
	{
		public string MaterialName;
		public Material Material;
	}
}
