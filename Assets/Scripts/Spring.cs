using UnityEngine;

public class Spring : MonoBehaviour
{
    public float bounceForce = 12f;
    [SerializeField] private Animator animator;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;

        PlayerMovement playerMovement = collision.gameObject.GetComponent<PlayerMovement>();
        Rigidbody2D playerRb = collision.gameObject.GetComponent<Rigidbody2D>();

        Debug.Log("SPRING HIT");

        if (playerMovement != null && playerRb != null && playerRb.linearVelocity.y <= 0)
        {
            playerMovement.Bounce(bounceForce);
            animator.SetTrigger("bounce");
        }
    }
}