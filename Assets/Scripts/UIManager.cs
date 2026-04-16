using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public TMP_Text coinText;
    public TMP_Text starText;

    public SpriteRenderer heart1;
    public SpriteRenderer heart2;
    public SpriteRenderer heart3;

    private void Awake()
    {
        instance = this;
    }

    public void UpdateCoins(int amount)
    {
        coinText.text = amount.ToString();
    }

    public void UpdateStars(int amount)
    {
        starText.text = "x" + amount;
    }

    public void UpdateLives(int lives)
    {
        heart1.enabled = lives >= 1;
        heart2.enabled = lives >= 2;
        heart3.enabled = lives >= 3;
    }
}