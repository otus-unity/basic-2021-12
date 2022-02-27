using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Collider2D collider2D;
    private Rigidbody2D rigidbody2D;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    public LayerMask ground;
    
    void Start()
    {
        collider2D = GetComponent<Collider2D>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    void Update()
    {
        float hDirection = Input.GetAxis("Horizontal");

        if (hDirection < 0.0f)
        {
            rigidbody2D.velocity = new Vector2(-5f, rigidbody2D.velocity.y);
            spriteRenderer.flipX = true;
            animator.SetBool("isRunning", true);
        } 
        else if (hDirection > 0.0f)
        {
            rigidbody2D.velocity = new Vector2(5f, rigidbody2D.velocity.y);
            spriteRenderer.flipX = false;
            animator.SetBool("isRunning", true);
        }
        else
        {
            rigidbody2D.velocity = new Vector2(0f, rigidbody2D.velocity.y);
            animator.SetBool("isRunning", false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && collider2D.IsTouchingLayers(ground))
        {
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, 5f);
        }
    }
}
