using UnityEngine;
using UnityEngine.SceneManagement;

public class Sun : MonoBehaviour
{
    [SerializeField] private float speed = 1.0f;
    [SerializeField] private uint healthPoints = 1;
    private readonly Vector2 _left = new(-1, 0);
    private readonly Vector2 _up = new(0, 1);
    private readonly Vector2 _down = new(0, -1);
    private Vector2 _currentDirection;
    private bool _active = false;
    private Rigidbody2D _rigidbodyComponent;
    //private Transform _transformComponent;

    void Start()
    {
        _currentDirection = _left;
        _rigidbodyComponent = GetComponent<Rigidbody2D>();
        //    _transformComponent = GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        _rigidbodyComponent.velocity = speed * _currentDirection;
        if (healthPoints <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("Win");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 12)
        {
            if (!_active)
            {
                _currentDirection = _up;
                _active = true;
                Destroy(other.gameObject);
            }
            else
            {
                _currentDirection = _currentDirection == _down ? _up : _down;
            }
        }
        else if (other.gameObject.layer == 10)
        {  
            Destroy(other.gameObject);
            if (_active)
            {
                healthPoints -= 1;
            }
        }
    }
}