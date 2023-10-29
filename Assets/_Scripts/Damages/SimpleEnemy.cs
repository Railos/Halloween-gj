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
    public Animator animator;

    public int freezeLevel;
    public float freezeTime;

    private bool isFreezed;

    private void Start()
    {
        house = FindObjectOfType<Shack>().transform;

        hp = maxHp;
    }

    private void Update()
    {
        if ((house.position.x - transform.position.x < 0f && transform.localScale.x > 0f ) || (house.position.x - transform.position.x > 0f && transform.localScale.x < 0f ))
        {
            transform.localScale =
                new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }
        if (Vector2.Distance(house.position, transform.position) <= distDestination)
        {
            animator.SetBool("isPunching", true);
            Path.enabled = false;
        }
        else
        {
            animator.SetBool("isPunching", false);
            destSetter.target = house;
            Path.enabled = true;
        }
        
        if (freezeLevel >= 3)
        {
            Path.enabled = false;
            animator.enabled = false;
            if (!isFreezed)
            {
                Invoke(nameof(UnFreeze), freezeTime);
                isFreezed = true;
            }
                
        }
    }

    private void UnFreeze()
    {
        Path.enabled = true;
        animator.enabled = true;
        freezeLevel = 0;
        isFreezed = false;
    }

    void OnPunch()
    {
        house.gameObject.GetComponent<IDamageable>().GetDamage(damage);
    }
}
