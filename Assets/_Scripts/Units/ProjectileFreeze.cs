using System;
using DG.Tweening;
using UnityEngine;


public class ProjectileFreeze : MonoBehaviour
{
    public float speed;
    public float damage;

    public void Start()
    {
        Invoke("Zz", 10f);
        GetComponent<SpriteRenderer>().DOFade(0f, 0f);
        GetComponent<SpriteRenderer>().DOFade(1f, 0.05f);
    }

    private void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = transform.right * speed;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        IDamageable dmg;
        SimpleEnemy enm;
        if (other.gameObject.TryGetComponent(out enm))
        {
            if (other.gameObject.GetComponent<Shack>() == null)
            {
                enm.GetDamage(damage);
                enm.freezeLevel += 1;
            }

        }
        else if (other.gameObject.TryGetComponent(out dmg))
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
