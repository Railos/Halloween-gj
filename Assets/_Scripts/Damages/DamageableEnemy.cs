using System;
using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;
using Random = UnityEngine.Random;

public class DamageableEnemy : MonoBehaviour, IDamageable
{
    public float hp, maxHp;
    public List<dropWhenDie> dropList;


    // Start is called before the first frame update
    void Start()
    {
        hp = maxHp;
    }

    public void GetDamage(float damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        foreach (var zalupen in dropList)
        {
            if (Random.Range(1, 100 / zalupen.chance) == 1)
            {
                var drop = Instantiate(zalupen.dropPrefab, transform.position, Quaternion.identity).GetComponent<ItemDrop>();

                drop.amount = zalupen.amount;
            }
        }
        
        Destroy(gameObject);
    }
}

[System.Serializable]
public struct dropWhenDie
{
    public GameObject dropPrefab;
    public int amount;
    public int chance;
}
