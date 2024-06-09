using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject healthSliderPrefab; // Reference to the health slider prefab
    public int initialEnemyCount = 1;
    private int currentEnemyCount;

    void Start()
    {
        currentEnemyCount = initialEnemyCount;
        SpawnEnemies(transform.position);
    }

    public void SpawnEnemies(Vector3 spawnPosition)
    {
        for (int i = 0; i < currentEnemyCount; i++)
        {
            Vector3 randomOffset = new Vector3(Random.Range(-2f, 2f), Random.Range(-2f, 2f), 0);
            GameObject enemy = Instantiate(enemyPrefab, spawnPosition + randomOffset, Quaternion.identity);

            // Ensure the enemy has the EnemyHealth script and set the health slider prefab
            EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.healthSliderPrefab = healthSliderPrefab;
            }

            // Ensure the enemy is on a valid layer
            enemy.layer = LayerMask.NameToLayer("Enemy");
        }

        currentEnemyCount *= 2; // Double the enemy count for the next spawn
    }
}
