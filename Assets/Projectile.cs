using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float lifetime = 5f;
    public int damage = 10; // Damage dealt by the projectile

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);
            }
            Destroy(gameObject); // Destroy the projectile after hitting the enemy
        }
    }
}
