using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [Header("Scene Names")]
    [SerializeField] private string authSceneName = "AuthScene";
    [SerializeField] private string levelSelectSceneName = "LevelSelect";
    [SerializeField] private string leaderboardSceneName = "LeaderboardScene";
    [SerializeField] private string settingsSceneName = "SettingsScene";

    private void Start()
    {
        PlayerSession.LoadSession();
    }

    public void PlayGame()
    {
        if (AudioManager.instance != null)
            AudioManager.instance.PlayButton();

        SceneManager.LoadScene("Level1");
    }

    public void OpenLevelSelect()
    {
        if (AudioManager.instance != null)
            AudioManager.instance.PlayButton();

        SceneManager.LoadScene(levelSelectSceneName);
    }

    public void OpenLeaderboard()
    {
        if (AudioManager.instance != null)
            AudioManager.instance.PlayButton();

        SceneManager.LoadScene(leaderboardSceneName);
    }

    public void OpenSettings()
    {
        if (AudioManager.instance != null)
            AudioManager.instance.PlayButton();

        SceneManager.LoadScene(settingsSceneName);
    }

    public void Logout()
    {
        PlayerSession.Clear();
        SceneManager.LoadScene(authSceneName);
    }

    public void ExitGame()
    {
        if (AudioManager.instance != null)
            AudioManager.instance.PlayButton();

        Application.Quit();
    }
}