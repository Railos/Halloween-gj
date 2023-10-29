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
    }

    void OnPunch()
    {
        house.gameObject.GetComponent<IDamageable>().GetDamage(damage);
    }
}
