using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectManager : MonoBehaviour
{
    [SerializeField] private Button level2Button;
    [SerializeField] private Button level3Button;
    [SerializeField] private string mainMenuSceneName = "MainMenu";

    private void Start()
    {
        UpdateButtons();

        if (ProgressManager.Instance != null)
        {
            ProgressManager.Instance.LoadProgress();
        }
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene("Level1");
    }

    public void LoadLevel2()
    {
        if (PlayerSession.Level2Unlocked)
            SceneManager.LoadScene("Level2");
    }

    public void LoadLevel3()
    {
        if (PlayerSession.Level3Unlocked)
            SceneManager.LoadScene("Level3");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(mainMenuSceneName);
    }

    public void UpdateButtons()
    {
        if (level2Button != null)
            level2Button.interactable = PlayerSession.Level2Unlocked;

        if (level3Button != null)
            level3Button.interactable = PlayerSession.Level3Unlocked;
    }
}