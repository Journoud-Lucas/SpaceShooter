using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Settings")]
    [SerializeField] float moveSpeed = 2f;
    [SerializeField] int maxHealth = 2;
    [SerializeField] int damage = 1;

    [Header("References")]
    [SerializeField] private GameObject sparkleEffectPrefab;

    private GameManager gameManager;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
        if (gameManager == null)
        {
            gameManager = GameObject.FindFirstObjectByType<GameManager>();
        }
    }
    void Update()
    {
        transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);

        if (transform.position.y < -6f)
        {
            PlayerHealth player = GameObject.FindWithTag("Player").GetComponent<PlayerHealth>();
            if (player != null)
            {
                player.TakeDamage(damage);
            }

        Destroy(gameObject);
        }

    }

    /// <summary>
    /// Applies damage to the object by reducing its current health by the specified amount. Destroys the object if its
    /// health reaches zero or below.
    /// </summary>
    /// <param name="amount">The amount of damage to apply. Must be a non-negative integer.</param>
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            if (gameManager != null)
                gameManager.AddScore(1);

            DestroyEnemy();
        }
    }

    /// <summary>
    /// Destroys the enemy game object.
    /// </summary>
    public void DestroyEnemy()
    {
        GameObject effect = Instantiate(sparkleEffectPrefab, transform.position, Quaternion.identity);
        Destroy(effect, 0.25f);
        Destroy(gameObject);
    }

    /// <summary>
    /// Handles collision with other objects.
    /// </summary>
    /// <param name="other">The collider of the other object.</param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerHealth>().TakeDamage(damage);
            DestroyEnemy();
        }
    }
}
