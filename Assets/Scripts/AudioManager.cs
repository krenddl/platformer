using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [Header("Sources")]
    public AudioSource musicSource;
    public AudioSource sfxSource;

    [Header("Music")]
    public AudioClip menuMusic;
    public AudioClip level1Music;
    public AudioClip level2Music;
    public AudioClip level3Music;

    [Header("SFX")]
    public AudioClip jumpClip;
    public AudioClip hurtClip;
    public AudioClip collectClip;
    public AudioClip buttonClip;
    public AudioClip enemyDeathClip;

    private bool musicEnabled = true;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            musicEnabled = PlayerPrefs.GetInt("MusicEnabled", 1) == 1;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Start()
    {
        ApplyMusicState();
    }

    public void PlayMusic(AudioClip clip)
    {
        if (clip == null) return;

        if (musicSource.clip != clip)
        {
            musicSource.clip = clip;
            musicSource.loop = true;
        }

        ApplyMusicState();

        if (musicEnabled && !musicSource.isPlaying)
        {
            musicSource.Play();
        }
    }

    public void ToggleMusic()
    {
        musicEnabled = !musicEnabled;
        PlayerPrefs.SetInt("MusicEnabled", musicEnabled ? 1 : 0);
        PlayerPrefs.Save();

        ApplyMusicState();
    }

    private void ApplyMusicState()
    {
        if (musicSource == null) return;

        musicSource.mute = !musicEnabled;

        if (!musicEnabled)
        {
            musicSource.Pause();
        }
        else
        {
            if (musicSource.clip != null && !musicSource.isPlaying)
            {
                musicSource.UnPause();

                if (!musicSource.isPlaying)
                    musicSource.Play();
            }
        }
    }

    public void PlaySFX(AudioClip clip)
    {
        if (clip == null || sfxSource == null) return;
        sfxSource.PlayOneShot(clip);
    }

    public void PlayJump() => PlaySFX(jumpClip);
    public void PlayHurt() => PlaySFX(hurtClip);
    public void PlayCollect() => PlaySFX(collectClip);
    public void PlayButton() => PlaySFX(buttonClip);
    public void PlayEnemyDeath() => PlaySFX(enemyDeathClip);

    public void ForceEnableMusic()
    {
        musicEnabled = true;
        PlayerPrefs.SetInt("MusicEnabled", 1);
        PlayerPrefs.Save();

        ApplyMusicState();
    }
}