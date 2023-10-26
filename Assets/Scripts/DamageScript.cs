using UnityEngine;

public class DamageScript : MonoBehaviour
{
    [SerializeField] private uint healthPoints;
    private bool _vulnerable;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Activate"))
        {
            _vulnerable = true;
        }

        if (_vulnerable)
        {
            var playerBulletScript = other.GetComponent<PlayerBulletScript>();
            if (playerBulletScript != null)
            {
                healthPoints -= playerBulletScript.damage;
                Destroy(playerBulletScript.gameObject);
            } 
        }
    }

    private void Update()
    {
        if (healthPoints <= 0)
        {
            Destroy(gameObject);
        }
    }
}
