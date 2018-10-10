using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIRanged : MonoBehaviour {

    public int flameAttackMinDamage;
    public int flameAttackDamageRange;

    public int grenadeAttackMinDamage;
    public int grenadeAttackDamageRange;

    public int movementSpaces;
    public int health;
    public int healthMax;

    public bool hasMoved;
    public bool hasAttacked;

    // Use this for initialization
    void Start()
    {
        health = healthMax;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
