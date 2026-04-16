using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectManager : MonoBehaviour
{
    public Button level2Button;
    public Button level3Button;

    void Start()
    {
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);

        if (level2Button != null)
            level2Button.interactable = unlockedLevel >= 2;

        if (level3Button != null)
            level3Button.interactable = unlockedLevel >= 3;
    }

    public void LoadLevel1()
    {
        if (AudioManager.instance != null)
            AudioManager.instance.PlayButton();

        SceneManager.LoadScene("Level1");
    }

    public void LoadLevel2()
    {
        if (AudioManager.instance != null)
            AudioManager.instance.PlayButton();

        SceneManager.LoadScene("Level2");
    }

    public void LoadLevel3()
    {
        if (AudioManager.instance != null)
            AudioManager.instance.PlayButton();

        SceneManager.LoadScene("Level3");
    }

    public void BackToMenu()
    {
        if (AudioManager.instance != null)
            AudioManager.instance.PlayButton();

        SceneManager.LoadScene("MainMenu");
    }
}