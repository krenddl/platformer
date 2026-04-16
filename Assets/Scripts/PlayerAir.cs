using UnityEngine;
using UnityEngine.UI;

public class PlayerAir : MonoBehaviour
{
    [Header("Air Settings")]
    public int maxAir = 5;
    public float timePerBubble = 1f;

    [Header("UI")]
    public Image[] airBubbles;

    private int currentAir;
    private float timer;
    private bool isInWater;

    private PlayerHealth playerHealth;

    void Start()
    {
        currentAir = maxAir;
        timer = timePerBubble;
        playerHealth = GetComponent<PlayerHealth>();

        SetAirUIVisible(false);
    }

    void Update()
    {
        if (isInWater)
        {
            timer -= Time.deltaTime;

            if (timer <= 0f)
            {
                currentAir--;
                timer = timePerBubble;

                UpdateAirUI();

                if (currentAir <= 0)
                {
                    if (playerHealth != null)
                    {
                        playerHealth.TakeDamage(1);
                    }

                    currentAir = maxAir;
                    timer = timePerBubble;
                    UpdateAirUI();
                }
            }
        }
        else
        {
            if (currentAir < maxAir)
            {
                timer -= Time.deltaTime;

                if (timer <= 0f)
                {
                    currentAir++;
                    timer = timePerBubble;
                    UpdateAirUI();
                }
            }
            else
            {
                timer = timePerBubble;
            }
        }
    }

    void UpdateAirUI()
    {
        for (int i = 0; i < airBubbles.Length; i++)
        {
            airBubbles[i].enabled = i < currentAir;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Water"))
        {
            isInWater = true;
            timer = timePerBubble;
            SetAirUIVisible(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Water"))
        {
            isInWater = false;
            timer = timePerBubble;
            SetAirUIVisible(false);
        }
    }

    void SetAirUIVisible(bool visible)
    {
        for (int i = 0; i < airBubbles.Length; i++)
        {
            airBubbles[i].gameObject.SetActive(visible);
        }
    }
}