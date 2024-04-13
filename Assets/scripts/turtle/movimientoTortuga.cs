using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class movement : MonoBehaviour
{
    public float speed = 1.0f;

    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
    private Rigidbody2D _rigidbody2D;
    private float actualSpeed = 0;
    public bool flipping = false;

    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        actualSpeed = speed;
    }

    private void FixedUpdate()
    {

        Vector2 ab_der = new Vector2(transform.position.x + 0.55f, transform.position.y - 0.46f);
        Vector2 ab_iz = new Vector2(transform.position.x - 0.55f, transform.position.y - 0.46f);
        Vector2 ar_der = new Vector2(transform.position.x + 0.75f, transform.position.y + 0.46f);
        Vector2 ar_iz = new Vector2(transform.position.x - 1.5f, transform.position.y + 0.46f);
        bool flip1 = !Physics2D.OverlapCircle(ab_der, 0.01f, LayerMask.GetMask("floor"));
        bool flip2 = !Physics2D.OverlapCircle(ab_iz, 0.01f, LayerMask.GetMask("floor"));
        bool flip3 = Physics2D.OverlapCircle(ar_der, 0.01f, LayerMask.GetMask("floor"));
        bool flip4 = Physics2D.OverlapCircle(ar_iz, 0.01f, LayerMask.GetMask("floor"));

        if(flip1 || flip2 || flip3 || flip4){
            if(flipping){
            }else{
                _spriteRenderer.flipX = !_spriteRenderer.flipX;
                actualSpeed = -actualSpeed;
                flipping = true;
            }
        }
        if(!flip1 && !flip2 && !flip3 && !flip4){
            flipping = false;
        }
        _rigidbody2D.velocity = new Vector2(actualSpeed, _rigidbody2D.velocity.y);
    }
}
