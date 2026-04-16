using UnityEngine;

public class Level1MusicPlayer : MonoBehaviour
{
    void Start()
    {
        if (AudioManager.instance != null)
        {
            AudioManager.instance.PlayMusic(AudioManager.instance.level1Music);
        }
    }
}