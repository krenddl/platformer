using UnityEngine;

public class Level2MusicPlayer : MonoBehaviour
{
    void Start()
    {
        if (AudioManager.instance != null)
        {
            AudioManager.instance.PlayMusic(AudioManager.instance.level2Music);
        }
    }
}