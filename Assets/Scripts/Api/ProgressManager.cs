using UnityEngine;

public class ProgressManager : MonoBehaviour
{
    public static ProgressManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoadProgress()
    {
        if (!PlayerSession.IsAuthorized)
        {
            Debug.LogWarning("Пользователь не авторизован");
            return;
        }

        string url = ApiRoutes.GetProgress + "?userId=" + PlayerSession.UserId;
        StartCoroutine(ApiManager.Instance.GetRequest(url, OnProgressLoaded, OnProgressError, true));
    }

    public void CompleteLevel(int levelNumber, int score, int stars)
    {
        if (!PlayerSession.IsAuthorized)
        {
            Debug.LogWarning("Пользователь не авторизован");
            return;
        }

        CompleteLevelRequest request = new CompleteLevelRequest
        {
            userId = PlayerSession.UserId,
            levelNumber = levelNumber,
            score = score,
            stars = stars
        };

        string json = JsonUtility.ToJson(request);

        StartCoroutine(ApiManager.Instance.PostRequest(
            ApiRoutes.CompleteLevel,
            json,
            OnCompleteLevelSuccess,
            OnCompleteLevelError,
            true));
    }

    private void OnProgressLoaded(string responseJson)
    {
        ProgressItem[] progressArray = JsonHelper.FromJsonArray<ProgressItem>(responseJson);

        PlayerSession.Level1Unlocked = true;
        PlayerSession.Level2Unlocked = false;
        PlayerSession.Level3Unlocked = false;

        foreach (ProgressItem item in progressArray)
        {
            if (item.levelNumber == 1 && item.isCompleted)
                PlayerSession.Level2Unlocked = true;

            if (item.levelNumber == 2 && item.isCompleted)
                PlayerSession.Level3Unlocked = true;
        }

        LevelSelectManager levelSelectManager = Object.FindObjectOfType<LevelSelectManager>();
        if (levelSelectManager != null)
        {
            levelSelectManager.UpdateButtons();
        }
    }

    private void OnProgressError(string error)
    {
        Debug.LogError("Ошибка загрузки прогресса: " + error);
    }

    private void OnCompleteLevelSuccess(string responseJson)
    {
        Debug.Log("COMPLETE LEVEL RESPONSE: " + responseJson);

        CompleteLevelResponse response = JsonUtility.FromJson<CompleteLevelResponse>(responseJson);

        if (response != null)
        {
            PlayerSession.UpdateCoins(response.coins);
        }

        CoinUIManager coinsUi = Object.FindObjectOfType<CoinUIManager>();
        if (coinsUi != null)
        {
            coinsUi.Refresh();
        }

        LoadProgress();
    }

    private void OnCompleteLevelError(string error)
    {
        Debug.LogError("Ошибка отправки прохождения уровня: " + error);
    }
}
