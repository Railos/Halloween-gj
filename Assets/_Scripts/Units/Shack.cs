using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shack : MonoBehaviour, IDamageable
{
    public float hp, maxHp;
    
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
        Destroy(gameObject);
    }
}
