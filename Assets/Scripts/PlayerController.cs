using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Collider2D _collider2D;
    
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    public LayerMask ground;
    
    SliderPlatform stayingOnPlatform;
    
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponentInChildren<Animator>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }
    
    void Update()
    {
        float hDirection = Input.GetAxis("Horizontal");
        
        float platformVelocity = 0.0f;
        if (stayingOnPlatform != null)
            platformVelocity = stayingOnPlatform.myrigidbody2d.velocity.x;

        if (hDirection < 0.0f)
        {
            _rigidbody2D.velocity = new Vector2(-5f + platformVelocity, _rigidbody2D.velocity.y);
            _spriteRenderer.flipX = true;
            _animator.SetBool("isRunning", true);
        } 
        else if (hDirection > 0.0f)
        {
            _rigidbody2D.velocity = new Vector2(5f + platformVelocity, _rigidbody2D.velocity.y);
            _spriteRenderer.flipX = false;
            _animator.SetBool("isRunning", true);
        }
        else
        {
            _rigidbody2D.velocity = new Vector2(platformVelocity, _rigidbody2D.velocity.y);
            _animator.SetBool("isRunning", false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && _collider2D.IsTouchingLayers(ground))
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, 8f);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bonus"))
        {
            Destroy(other.gameObject);
        }
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent<SliderPlatform>(out var platform))
            stayingOnPlatform = platform;
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent<SliderPlatform>(out var platform))
            stayingOnPlatform = null;
    }
}
