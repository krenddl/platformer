using UnityEngine;
using System.Collections;

public class Chest : MonoBehaviour
{
    public Animator animator;
    public GameObject starPrefab;
    public Transform spawnPoint;

    private bool isOpened = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isOpened) return;

        if (other.CompareTag("Player"))
        {
            StartCoroutine(OpenChest());
        }
    }

    IEnumerator OpenChest()
    {
        isOpened = true;

        if (animator != null)
            animator.SetBool("isOpen", true);

        yield return new WaitForSeconds(1f);

        if (starPrefab != null && spawnPoint != null)
        {
            GameObject spawnedStar = Instantiate(starPrefab, spawnPoint.position, Quaternion.identity);

            Rigidbody2D rb = spawnedStar.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.linearVelocity = new Vector2(1.2f, 4f);
            }
        }
    }
}