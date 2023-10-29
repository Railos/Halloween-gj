using System;
using UnityEngine;


public class Projectile : MonoBehaviour
{
    public float speed;
    public float damage;

    public void Start()
    {
        Invoke("Zz", 30f);
    }

    private void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = transform.right * speed;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        IDamageable dmg;
        if (other.gameObject.TryGetComponent(out dmg))
        {
            if (other.gameObject.GetComponent<Shack>() == null)
                dmg.GetDamage(damage);
        }
        Destroy(gameObject);
    }

    void Zz()
    {
        Destroy(gameObject);
    }
}
