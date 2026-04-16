using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int coins = 0;
    public int stars = 0;
    public int levelNumber = 1;
    public int starsToWin = 3;

    private bool levelCompleted = false;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        if (UIManager.instance != null)
        {
            UIManager.instance.UpdateCoins(coins);
            UIManager.instance.UpdateStars(stars);
        }
    }

    public void AddCoin(int amount)
    {
        coins += amount;

        if (UIManager.instance != null)
            UIManager.instance.UpdateCoins(coins);
    }

    public void AddStar(int amount)
    {
        stars += amount;

        if (UIManager.instance != null)
            UIManager.instance.UpdateStars(stars);

        if (!levelCompleted && stars >= starsToWin)
        {
            StartCoroutine(CompleteLevel());
        }
    }

    IEnumerator CompleteLevel()
    {
        levelCompleted = true;


        yield return new WaitForSeconds(1f);

        if (ProgressManager.Instance != null)
        {
            int currentLevelNumber = levelNumber;
            int earnedCoins = coins;
            int earnedStars = stars;

            ProgressManager.Instance.CompleteLevel(currentLevelNumber, earnedCoins, earnedStars);
        }

        SceneManager.LoadScene("WinScene");
    }
}