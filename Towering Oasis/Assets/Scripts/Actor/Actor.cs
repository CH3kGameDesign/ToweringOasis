using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour
{
	// Health popup text and animation
	public Transform m_HealthDropPrefab;
	
	[HideInInspector]
	public Transform m_ActorPrefab;
	[HideInInspector]
	public Renderer m_ActorRenderer;
	[HideInInspector]
	public Vector3 m_ActorPos;

	// How many tiles is this actor allowed to move
	[HideInInspector]
	public int m_nHowManyTiles;

	// Character that this character is attacked by
	[HideInInspector]
	public Actor m_attackedBy;
	// is this actor performing an attack
	[HideInInspector]
	public bool m_IsAttacked;
	
	public int m_nHealth { get; set; }	
	public int m_nDamage { get; set; }

	public virtual void Start()
	{
		// Assigning default values
		m_ActorPrefab = this.transform;
		m_ActorRenderer = GetComponent<Renderer>();
		m_ActorPos = m_ActorPrefab.position;
		m_nHealth = 100;
	}

	public virtual void Update()
	{
		// Checks if mouse button is clicked and if someone is attacking it
		if (Input.GetMouseButtonDown(0) && m_IsAttacked)
		{
			// Deduct health by the damage of the attacker
			this.m_nHealth -= m_attackedBy.m_nDamage;

			// Create Health popup and set text which is equal to this actor's health
			Transform HealthDrop = Instantiate(m_HealthDropPrefab, transform.position, Quaternion.Euler(40, 140, 0), transform);
			HealthDrop.GetComponent<TextMesh>().text = m_nHealth.ToString();
			m_IsAttacked = false;
		}

		// if health is 0 destroy the gameobject
		if (m_nHealth <= 0)
		{
			UnitManager.Instance.m_Objects.Remove(gameObject.transform);
			Destroy(gameObject);
		}
	}

	public virtual void Attack(Transform specialTile)
	{

	}
}
