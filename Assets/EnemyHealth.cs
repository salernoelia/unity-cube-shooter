using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    private SpriteRenderer spriteRenderer;

    public GameObject healthSliderPrefab; // Reference to the health slider prefab
    private Slider healthSlider; // Instance of the health slider

    void Start()
    {
        currentHealth = maxHealth;
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Instantiate the health slider and set it up
        GameObject sliderInstance = Instantiate(healthSliderPrefab, transform.position, Quaternion.identity, transform);
        sliderInstance.transform.localPosition = new Vector3(0, 1.5f, 0); // Adjust as needed to position above the enemy
        healthSlider = sliderInstance.GetComponentInChildren<Slider>();
        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (healthSlider != null)
        {
            healthSlider.value = currentHealth;
        }

        StartCoroutine(FlashRed());

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        FindObjectOfType<EnemySpawner>().SpawnEnemies(transform.position); // Notify the spawner to respawn enemies
        Destroy(gameObject); // Destroy the enemy GameObject when health is 0
    }

    IEnumerator FlashRed()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.2f); // Adjust the duration to suit your needs
        spriteRenderer.color = Color.white; // Assuming the default color is white
    }
}
