using System;
using UnityEngine;


public class Projectile : MonoBehaviour
{
    public float speed;
    private void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = transform.right * speed;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject);
    }
}
