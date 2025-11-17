using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [Header("Health Settings")]
    [SerializeField] int maxHealth = 5;

    [Header("UI")]
    [SerializeField] Slider healthBar;

    [Header("References")]
    [SerializeField] private GameObject deathEffectPrefab;

    private GameManager gameManager;
    int currentHealth;
    bool isDead = false;
    void Start()
    {
        currentHealth = maxHealth;

        if (healthBar != null)
        {
            healthBar.maxValue = maxHealth;
            healthBar.value = currentHealth;
        }
        if (gameManager == null)
        {
            gameManager = GameObject.FindFirstObjectByType<GameManager>();
        }
    }

    /// <summary>
    /// Reduces the current health by the specified damage amount and updates the health bar. Triggers death logic if
    /// health reaches zero.
    /// </summary>
    /// <param name="damage">The amount of damage to subtract from the current health. Must be non-negative.</param>
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        if (healthBar != null)
        {
            healthBar.value = currentHealth;
        }

        if (currentHealth <= 0 && !isDead)
        {
            Die();
        }
    }

    /// <summary>
    /// Triggers the game over sequence by notifying the game manager that the entity has died.
    /// </summary>
    void Die()
    {
        isDead = true;

        if (deathEffectPrefab != null)
        {
            GameObject effect = Instantiate(deathEffectPrefab, transform.position, Quaternion.identity);
            Destroy(effect, 0.5f);
        }

        // Cacher le sprite du personnage
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            sr.enabled = false;
        }

        if (gameManager != null)
        {
            gameManager.GameOver();
        }
    }
}
