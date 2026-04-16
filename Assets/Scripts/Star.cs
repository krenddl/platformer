using UnityEngine;

public class Star : MonoBehaviour
{
    public int value = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (GameManager.instance != null)
                GameManager.instance.AddStar(value);

            if (AudioManager.instance != null)
                AudioManager.instance.PlayCollect();
            Destroy(gameObject);
        }
    }
}