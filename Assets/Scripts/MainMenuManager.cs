using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
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

        SceneManager.LoadScene("LevelSelect");
    }

    public void ExitGame()
    {
        if (AudioManager.instance != null)
            AudioManager.instance.PlayButton();

        Application.Quit();
    }

    public void ToggleMusic()
    {
        if (AudioManager.instance != null)
            AudioManager.instance.ToggleMusic();
    }
}