using System;
using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class SimpleEnemy : DamageableEnemy
{
    public float damage;
    public AIPath Path;
    public Transform house;
    public float distDestination;
    public AIDestinationSetter destSetter;
    
    
    private void Update()
    {
        if (Vector2.Distance(house.position, transform.position) <= distDestination)
        {
            Path.enabled = false;
            house.gameObject.GetComponent<IDamageable>().GetDamage(damage);
        }
        else
        {
            destSetter.target = house;
            Path.enabled = true;
        }
    }
}
