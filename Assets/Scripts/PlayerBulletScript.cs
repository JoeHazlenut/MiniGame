using System;
using UnityEngine;

public class PlayerBulletScript : MonoBehaviour
{
    [SerializeField] private float speed = 10.0f;
    public uint damage = 1;
    private static readonly Vector2 direction = new Vector2(1, 0);
    private Rigidbody2D _rigidbodyComponent;

    private void Start()
    {
        _rigidbodyComponent = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 8);
    }

    private void FixedUpdate()
    {
        _rigidbodyComponent.velocity = speed * direction;
    }
}
