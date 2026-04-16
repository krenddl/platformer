using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    public void ToggleMusic()
    {
        if (AudioManager.instance != null)
        {
            AudioManager.instance.ToggleMusic();
        }
    }
}