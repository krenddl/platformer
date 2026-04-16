using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [Header("Lives")]
    public int maxLives = 3;
    public int currentLives;

    [Header("Respawn")]
    public Vector3 respawnPoint;

    private Rigidbody2D rb;

    void Start()
    {
        currentLives = maxLives;
        respawnPoint = transform.position;
        rb = GetComponent<Rigidbody2D>();

        if (UIManager.instance != null)
            UIManager.instance.UpdateLives(currentLives);
    }

    public void TakeDamage(int damage)
    {
        currentLives -= damage;

        if (AudioManager.instance != null)
            AudioManager.instance.PlayHurt();

        if (UIManager.instance != null)
            UIManager.instance.UpdateLives(currentLives);

        if (currentLives > 0)
        {
            Respawn();
        }
        else
        {
            Die();
        }
    }

    public void SetCheckpoint(Vector3 newCheckpoint)
    {
        respawnPoint = newCheckpoint;
    }

    void Respawn()
    {
        transform.position = respawnPoint;

        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero;
        }
    }

    void Die()
    {
        SceneManager.LoadScene("GameOverScene");
    }
}