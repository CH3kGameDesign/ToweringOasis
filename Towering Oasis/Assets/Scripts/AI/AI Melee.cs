using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMelee : MonoBehaviour {

    public int chainsawAttackMinDamage;
    public int chainsawAttackDamageRange;

    public int kickAttackMinDamage;
    public int kickAttackDamageRange;

    public int movementSpaces;
    public int health;
    public int healthMax;

    public bool hasMoved;
    public bool hasAttacked;

    // Use this for initialization
    void Start () {
        health = healthMax;
	}
    
    public void DecideMove ()
    {
        //if (Is Enemy within 5 blocks)
        {
            //if (Is It Possible To Hit Multiple People)
            {
                //if (Enemies Hit > Allies Hit)
                {
                    //if (Enemies Killed >= Allies Killed)
                    {
                        //Hit Most Possible enemies with chainsaw
                        return;
                    }
                }
            }
            //if (Will Kicking Them Kill Them)
            {
                //Kick Them
                return;
            }
            //if (How Far Away From The Objective Can You Kick Them (> Current Distance = true))
            {
                //Kick Them
                return;
            }
            //Chainsaw Them
            return;
        }
        //if (Can You Kick Ally Within 1 Block Of Them)
        {
            //if (Is Ally Ranged Or Melee)
            {
                //if (!Has Ally Attacked Already)
                {
                    //if (Does Ally Have Over Half Health)
                    {
                        //if (!Is Ally Already Within 5 Blocks Of Them)
                        {
                            //if (!Has Ally Moved )
                            {
                                //if (!Is Ally Already Within 1 Block Of Them)
                                {
                                    //Kick Ally Closer
                                }
                            }
                        }
                    }
                }
            }
        }
        //if (Is Enemy Further Than 10 Blocks Away)
        {
            if (health < healthMax/2)
            {
                //if (Is Healing Area Within 4 Blocks)
                {
                    //Move Towards Closest Healing Area
                }
            }
        }
        //Move Towards Enemy Closest To Exit
    }
    
}
