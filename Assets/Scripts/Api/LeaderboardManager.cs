using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LeaderboardManager : MonoBehaviour
{
    [SerializeField] private TMP_Text leaderboardText;
    [SerializeField] private string backSceneName = "MainMenu";

    private void Start()
    {
        LoadLeaderboard();
    }

    public void LoadLeaderboard()
    {
        if (!PlayerSession.IsAuthorized)
        {
            if (leaderboardText != null)
                leaderboardText.text = "Нужно войти в аккаунт";
            return;
        }

        StartCoroutine(ApiManager.Instance.GetRequest(
            ApiRoutes.GetLeaderboard,
            OnLeaderboardLoaded,
            OnLeaderboardError,
            true));
    }

    private void OnLeaderboardLoaded(string responseJson)
    {
        LeaderboardUser[] users = JsonHelper.FromJsonArray<LeaderboardUser>(responseJson);

        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < users.Length; i++)
        {
            sb.AppendLine($"{i + 1}. {users[i].name} ({users[i].login}) - {users[i].coins}");
        }

        if (leaderboardText != null)
            leaderboardText.text = sb.ToString();
    }

    private void OnLeaderboardError(string error)
    {
        Debug.LogError(error);

        if (leaderboardText != null)
            leaderboardText.text = "Ошибка загрузки таблицы лидеров";
    }

    public void Back()
    {
        SceneManager.LoadScene(backSceneName);
    }
}