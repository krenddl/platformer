using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int damage = 1;
    public float bounceForce = 5f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;

        PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
        Rigidbody2D playerRb = collision.gameObject.GetComponent<Rigidbody2D>();

        foreach (ContactPoint2D contact in collision.contacts)
        {
            
            if (contact.normal.y < -0.5f)
            {
                if (playerRb != null)
                {
                    playerRb.linearVelocity = new Vector2(playerRb.linearVelocity.x, bounceForce);
                }

                if (AudioManager.instance != null)
                {
                    AudioManager.instance.PlayEnemyDeath();
                }

                Destroy(gameObject);
                return;
            }
        }

        
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damage);
        }
    }
}