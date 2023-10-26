using System;
using UnityEngine;

public class StraightMovementScript : MonoBehaviour
{
    private Rigidbody2D _rigidbodyComponent;
    [SerializeField] private float speed = 4.0f;
    private bool _frozen = false;
    private float _frozenTime = 2.0f;
    private SpriteRenderer _spriteComponent;
    private Color _defaultColor;

    private void Start()
    {
        _rigidbodyComponent = GetComponent<Rigidbody2D>();
        _spriteComponent = GetComponent<SpriteRenderer>();
        _defaultColor = _spriteComponent.color;
    }

    private void FixedUpdate()
    {
        if (!_frozen)
        {
            var direction = new Vector2(-1.0f, 0.0f);
            _rigidbodyComponent.velocity = speed * direction;    
        }
        else
        {
            _rigidbodyComponent.velocity *= 0.0f;
        }
    }

    private void Update()
    {
        if (_frozen)
        {
            if (_frozenTime >= 0.0f)
            {
                _frozenTime -= Time.deltaTime;
            }
            else
            {
                _frozen = false;
                _frozenTime = 2.0f;
                _spriteComponent.color = _defaultColor;
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 13)
        {
            _frozen = true;
            _spriteComponent.color = Color.cyan;
        }
    }
}
