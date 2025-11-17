using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] TMP_Text scoreText;
    [SerializeField] RawImage gameOverImage;
    [SerializeField] RawImage gameStartImage;


    [Header("References")]
    [SerializeField] PlayerMovement playerMove;
    [SerializeField] PlayerShooting playerShoot;
    [SerializeField] EnemySpawner enemySpawner;


    private int score = 0;
    private bool isGameOver = false;

    void Start()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: 0";
        }

        if (gameOverImage != null)
        { 
            gameOverImage.enabled = false;
        }
        Destroy(gameStartImage.gameObject, 1.5f);
    }

    /// <summary>
    /// Adds the specified amount to the player's score and updates the score UI.
    /// </summary>
    /// <param name="amount">The amount to add to the score.</param>
    public void AddScore(int amount)
    {
        if (isGameOver)
        {
            return;
        }

        score += amount;

        if (scoreText != null)
        { 
            scoreText.text = "Score: " + score;
        }
    }

    /// <summary>
    /// Handles the game over state by disabling player controls and displaying the game over UI.
    /// </summary>
    public void GameOver()
    {
        isGameOver = true;
        if (gameOverImage != null)
        {
            gameOverImage.enabled = true;
        }
        if (playerMove != null)
        { 
            playerMove.enabled = false;
        }

        if (playerShoot != null)
        {
            playerShoot.enabled = false;
        }

        if(enemySpawner != null)
        {
            enemySpawner.enabled = false;
        }
    }
}
