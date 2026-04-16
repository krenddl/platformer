using UnityEngine;

public class Level3MusicPlayer : MonoBehaviour
{
    void Start()
    {
        if (AudioManager.instance != null)
        {
            AudioManager.instance.PlayMusic(AudioManager.instance.level3Music);
        }
    }
}   