using System;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float acceleration;
    [SerializeField] private float deacceleration;

    private Vector2 moveDir;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        moveDir = new Vector2(horizontal, vertical).normalized;

        if (Mathf.Abs(rb.velocity.x) < moveSpeed)
        {
            rb.velocity += new Vector2(moveDir.x * acceleration, 0);
        }
        
        if (Mathf.Abs(rb.velocity.y) < moveSpeed)
        {
            rb.velocity += new Vector2(0, moveDir.y * acceleration);
        }
        
        // Замедление по X
        if (rb.velocity.x > 0)
        {
            rb.velocity -= new Vector2(deacceleration, 0);
            if (rb.velocity.x < 0)
                rb.velocity = new Vector2(0, rb.velocity.y);
        }
        else if (rb.velocity.x < 0)
        {
            rb.velocity += new Vector2(deacceleration, 0);
            if (rb.velocity.x > 0)
                rb.velocity = new Vector2(0, rb.velocity.y);
        }

        // Замедление по Y
        if (rb.velocity.y > 0)
        {
            rb.velocity -= new Vector2(0, deacceleration);
            if (rb.velocity.y < 0)
                rb.velocity = new Vector2(rb.velocity.x, 0);
        }
        else if (rb.velocity.y < 0)
        {
            rb.velocity += new Vector2(0, deacceleration);
            if (rb.velocity.y > 0)
                rb.velocity = new Vector2(rb.velocity.x, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<InteractionSystem>())
        {
            other.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<InteractionSystem>())
        {
            other.transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}