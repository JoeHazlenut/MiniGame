using UnityEngine;

public class ShotStraightScript : MonoBehaviour
{
    [SerializeField] private Vector2 direction;
    [SerializeField] private float speed;

    private Rigidbody2D _rigidbodyComponent;
    private Transform _transformComponent;

    public ShotStraightScript()
    {
        direction.Normalize();
    }

    void Start()
    {
        _rigidbodyComponent = GetComponent<Rigidbody2D>();
        _transformComponent = GetComponent<Transform>();
        Destroy(gameObject, 10);
    }

    private void FixedUpdate()
    {
        _rigidbodyComponent.velocity = direction * speed;
    }
}
