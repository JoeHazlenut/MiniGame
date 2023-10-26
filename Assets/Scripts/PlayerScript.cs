using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private float speed = 7.0f;
    private Rigidbody2D _rigidbodyComponent;
    private Transform _transformComponent;
    private Vector2 _direction;
    private bool _canShrink;
    private GameObject _player;

    
    [SerializeField] private Transform bulletPrefab;
    [SerializeField] private Transform icePrefab;
    [SerializeField] private float shootingRate = 0.25f;
    [SerializeField] private float specialReadyRate = 4.0f;
    [SerializeField] private float shootCooldown;
    [SerializeField] private float shootingOffset = 1.15f;
    [SerializeField] private float iceCooldown;
    [SerializeField] private float shrinkDuration;

    [SerializeField] private uint healthPoints = 3;

    private void Start()
    {
        
        _player = GameObject.Find("Player");
        _rigidbodyComponent = GetComponent<Rigidbody2D>();
        _transformComponent = GetComponent<Transform>();
    }

    private void Update()
    {
        if (shootCooldown > 0)
        {
            shootCooldown -= Time.deltaTime;
        }

        if (iceCooldown > 0)
        {
            iceCooldown -= Time.deltaTime;
        }

        bool shouldShoot = Input.GetButton("Fire1");

        if (shouldShoot)
        {
            FireBullets();
        }

        bool shouldSpecial = Input.GetButton("Fire2");

        if (shouldSpecial)
        {
            FireIceBeam();
        }

        if (Input.GetButton("Fire3"))
        {
            if (_canShrink)
            {
                ShrinkToHalf();
                _canShrink = false;
            }
        }

        if (healthPoints <= 0)
        {
            SceneManager.LoadScene("Loose");
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        _direction.x = Input.GetAxis("Horizontal");
        _direction.y = Input.GetAxis("Vertical");

        if (_direction.sqrMagnitude > 1.0f)
        {   
            _direction.Normalize();
        }

        _rigidbodyComponent.velocity = speed * _direction;

        _direction.x = 0.0f;
        _direction.y = 0.0f;
        ClipToViewport();
    }

    private void ClipToViewport()
    {
        float xClipLeft = -8.130f;
        float xClipRight = 7.9383f;
        float yClipBottom = 4.6974f;
        float yClipTop = -4.4974f;
        
        if (_transformComponent.position.x < xClipLeft)
        {
            _transformComponent.position = new Vector3(xClipLeft, _transformComponent.position.y, 0);
        }

        if (_transformComponent.position.x > xClipRight)
        {
            _transformComponent.position = new Vector3(xClipRight, _transformComponent.position.y, 0);
        }

        if (_transformComponent.position.y < yClipTop)
        {
            _transformComponent.position = new Vector3(_transformComponent.position.x, yClipTop, 0);
        }

        if (_transformComponent.position.y > yClipBottom)
        {
            _transformComponent.position = new Vector3(_transformComponent.position.x, yClipBottom, 0);
        }
    }

    private void FireBullets()
    {
        if (shootCooldown <= 0)
        {
            shootCooldown = shootingRate;
            var shotTransform = Instantiate(bulletPrefab);
            Vector2 bulletStartPosition = new Vector2(_transformComponent.position.x + shootingOffset, _transformComponent.position.y);
            shotTransform.position = bulletStartPosition;
        }
    }

    private void FireIceBeam()
    {
        if (iceCooldown <= 0)
        {
            iceCooldown = specialReadyRate;
            var iceTransform = Instantiate(icePrefab);
            Vector2 iceStartPosition = new Vector2(_transformComponent.position.x + shootingOffset, _transformComponent.position.y);
            iceTransform.position = iceStartPosition;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 14)
        {
            Destroy(other.gameObject);
            _canShrink = true;
        }
        else
        {
            if (healthPoints > 0)
            {
                healthPoints -= 1;
                Destroy(other.gameObject);
                var cherry3 = GameObject.Find("Cherry3");
                var cherry2 = GameObject.Find("Cherry2");
                var cherry1 = GameObject.Find("Cherry1");
            
                if (cherry3.GetComponent<SpriteRenderer>().enabled)
                {
                    cherry3.GetComponent<SpriteRenderer>().enabled = false;
                } 
                else if (cherry2.GetComponent<SpriteRenderer>().enabled)
                {
                    cherry2.GetComponent<SpriteRenderer>().enabled = false;
                }
                else if (cherry1.GetComponent<SpriteRenderer>().enabled)
                {
                    cherry1.GetComponent<SpriteRenderer>().enabled = false;
                }
            } 
        }
        
        
    }

    private void ShrinkToHalf()
    {
        _player.transform.localScale -= new Vector3(1.5f, 1.5f, 0);
    }
}

