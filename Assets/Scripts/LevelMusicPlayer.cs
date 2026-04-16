using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMusicPlayer : MonoBehaviour
{
    void Start()
    {
        if (AudioManager.instance == null) return;

        string sceneName = SceneManager.GetActiveScene().name;

        if (sceneName == "MainMenu")
        {
            AudioManager.instance.PlayMusic(AudioManager.instance.menuMusic);
        }
        else if (sceneName == "Level1")
        {
            AudioManager.instance.PlayMusic(AudioManager.instance.level1Music);
        }
        else if (sceneName == "Level2")
        {
            AudioManager.instance.PlayMusic(AudioManager.instance.level2Music);
        }
        else if (sceneName == "Level3")
        {
            AudioManager.instance.PlayMusic(AudioManager.instance.level3Music);
        }
    }
}