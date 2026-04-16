using UnityEngine;

public class MenuMusicPlayer : MonoBehaviour
{
    void Start()
    {
        if (AudioManager.instance != null)
        {
            AudioManager.instance.ForceEnableMusic();
            AudioManager.instance.PlayMusic(AudioManager.instance.menuMusic);
        }
    }
}