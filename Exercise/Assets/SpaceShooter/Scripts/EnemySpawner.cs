using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Enemy Spawn Settings")]
    [SerializeField] GameObject alan;
    [SerializeField] GameObject bonBon;
    [SerializeField] GameObject lips;
    [SerializeField] float spawnInterval = 1.5f;
    [SerializeField] float minX = -7f;
    [SerializeField] float maxX = 7f;
    [SerializeField] float spawnY = 6f;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnEnemy();
            timer = 0f;
        }
    }

    void SpawnEnemy()
    {
        float randomX = Random.Range(minX, maxX);
        Vector3 spawnPos = new Vector3(randomX, spawnY, 0f);

        float r = Random.value;

        GameObject enemyToSpawn;

        if (r < 0.5f)
        {
            enemyToSpawn = alan;
        }
        else if (r < 0.75f)
        {
            enemyToSpawn = bonBon;
        }
        else
        {
            enemyToSpawn = lips;
        }

        Instantiate(enemyToSpawn, spawnPos, Quaternion.identity);
    }
}
