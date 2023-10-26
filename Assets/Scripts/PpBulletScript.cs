using UnityEngine;

public class PpBulletScript : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;
    private Vector2 _shotDirection;
    private Rigidbody2D _rigidbodyComponent;
    
    void Start()
    {
        var player = GameObject.Find("Player");
        if (player != null)
        {
            Transform transformComponent = GetComponent<Transform>();
            var position = transformComponent.position;
            _shotDirection.x = player.transform.position.x - position.x;
            _shotDirection.y = player.transform.position.y - position.y;
            _shotDirection.Normalize();
            _rigidbodyComponent = GetComponent<Rigidbody2D>();    
            Destroy(gameObject, 10);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    private void FixedUpdate()
    {
        _rigidbodyComponent.velocity = _shotDirection * speed;
    }
}
