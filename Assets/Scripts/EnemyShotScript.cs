using System;
using UnityEngine;

public class EnemyShotScript : MonoBehaviour
{
    [SerializeField] private Transform bulletPrefab;
    [SerializeField] private float currentCooldown = 2.0f;
    [SerializeField] private float shootInterval = 3.0f;
    private bool _onScreen;
    private Transform _transformComponent;

    private void Start()
    {
        _transformComponent = GetComponent<Transform>();
    }

    private void Update()
    {
        if (_onScreen)
        {
           if (currentCooldown <= 0)
           { 
               FireBullets();
               currentCooldown = shootInterval;
           }
           else
           {
               currentCooldown -= Time.deltaTime;
           } 
        }
    }

    void FireBullets()
    {
        var bulletTransform = Instantiate(bulletPrefab);
        bulletTransform.position = _transformComponent.position;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Activate"))
        {
            if (_onScreen == false)
            {
                _onScreen = true;
            }  
        }

        if (other.CompareTag("Deactivate"))
        {
            if (_onScreen)
            {
                _onScreen = false;
                Destroy(gameObject, 3);
            }
        }
    }
}
