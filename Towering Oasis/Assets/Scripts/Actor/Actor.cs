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
    public int m_nHealth;
    public int m_nHowManyTiles;
    public int m_nDamage;

    // Character that this character is attacked by
    [HideInInspector]
	public List<Actor> m_whoWasAttacked = new List<Actor>();


	public virtual void Start()
	{
		// Assigning default values
		m_ActorPrefab = this.transform;
		m_ActorRenderer = GetComponent<Renderer>();
		m_ActorPos = m_ActorPrefab.position;
	}

	public virtual void Update()
	{
		// if health is 0 destroy the gameobject
		if (m_nHealth <= 0)
		{
			UnitManager.Instance.m_Objects.Remove(gameObject.transform);
			Destroy(gameObject);
		}
	}

	public virtual void Attack()
	{
		foreach (Actor actor in m_whoWasAttacked)
		{
			// Deduct health by the damage of the attacker
			actor.m_nHealth -= this.m_nDamage;

			// Create Health popup and set text which is equal to this actor's health
			Transform HealthDrop = Instantiate(m_HealthDropPrefab, actor.transform.position, Quaternion.Euler(40, 140, 0), actor.transform);
			HealthDrop.GetComponent<TextMesh>().text = actor.m_nHealth.ToString();
		}
	}


	public virtual void SpawnAttackTiles(Transform attackPrefab)
	{
		
	}
}
