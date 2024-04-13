using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class movimiento : MonoBehaviour
{
    public float velocidad = 4.0f;
    public float alturaSalto = 2.0f;
    
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
    private Rigidbody2D _rigidbody2D;
    private float input;
    private bool djump = false;

    // Start is called before the first frame update
    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 colliderPosition = new Vector2(transform.position.x, transform.position.y - 0.5f);
        bool ground = Physics2D.OverlapCircle(colliderPosition, 0.01f, LayerMask.GetMask("floor"));

        if (Input.GetButtonDown("Jump") && !djump)
        {
            if(!ground){
                djump = true;
            }
            float salto = Mathf.Sqrt(-2 * Physics2D.gravity.y * alturaSalto);
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, 0);
            _rigidbody2D.AddForce(new Vector2(0f, salto), ForceMode2D.Impulse);
        }

        if(ground){
            djump = false;
        }

        input = Input.GetAxis("Horizontal");

        if (input != 0)
        {
            _spriteRenderer.flipX = (input < 0);
        }
        
        _animator.SetFloat("speed", Mathf.Abs(input));
        _animator.SetBool("ground", ground);
        _animator.SetBool("djump", djump);
    }

    private void FixedUpdate()
    {
        _rigidbody2D.velocity = new Vector2(input * velocidad, _rigidbody2D.velocity.y);
    }
}
