using UnityEngine;

public class MusicManagement : MonoBehaviour
{
    public static MusicManagement Instance { get; private set; }

    [SerializeField] private AudioClip chessMoveSound;
    [SerializeField] private AudioClip reachedGoalSound;
    [SerializeField] private AudioClip backgroundMusic;
    [SerializeField] private AudioClip clickSound;

    private AudioSource backgroundAudioSource;
    private AudioSource chessMoveAudioSource;
    private AudioSource reachedGoalAudioSource;
    private AudioSource clickAudioSource;

    private float musicVolume = 0.5f;
    private float chessMoveVolume = 1f;
    private float reachedGoalVolume = 0.6f;
    private float clickVolume = 0.6f; 

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            backgroundAudioSource = gameObject.AddComponent<AudioSource>();
            backgroundAudioSource.loop = true;
            backgroundAudioSource.volume = musicVolume;
            backgroundAudioSource.clip = backgroundMusic;

            chessMoveAudioSource = gameObject.AddComponent<AudioSource>();
            chessMoveAudioSource.loop = false;
            chessMoveAudioSource.volume = chessMoveVolume;

            reachedGoalAudioSource = gameObject.AddComponent<AudioSource>();
            reachedGoalAudioSource.loop = false;
            reachedGoalAudioSource.volume = reachedGoalVolume;

            clickAudioSource = gameObject.AddComponent<AudioSource>(); // Dedicated AudioSource for click sound
            clickAudioSource.loop = false;
            clickAudioSource.volume = clickVolume;

            PlayBackgroundMusic();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayChessMoveSound()
    {
        if (chessMoveSound != null)
        {
            chessMoveAudioSource.PlayOneShot(chessMoveSound, chessMoveVolume);
        }
    }

    public void PlayReachedGoalSound()
    {
        if (reachedGoalSound != null)
        {
            reachedGoalAudioSource.PlayOneShot(reachedGoalSound, reachedGoalVolume);
        }
    }

    public void PlayClick()
    {
        if (clickSound != null)
        {
            clickAudioSource.PlayOneShot(clickSound, clickVolume);
        }
    }

    private void PlayBackgroundMusic()
    {
        if (backgroundMusic != null && !backgroundAudioSource.isPlaying)
        {
            backgroundAudioSource.Play();
        }
    }

    public void SetMusicVolume(float newVolume)
    {
        musicVolume = Mathf.Clamp(newVolume, 0f, 1f);
        backgroundAudioSource.volume = musicVolume;
    }

    public void SetEffectsVolume(float newVolume)
    {
        chessMoveVolume = Mathf.Clamp(newVolume, 0f, 1f);
        chessMoveAudioSource.volume = chessMoveVolume;

        reachedGoalVolume = Mathf.Clamp(newVolume, 0f, 1f);
        reachedGoalAudioSource.volume = reachedGoalVolume;

        clickVolume = Mathf.Clamp(newVolume, 0f, 1f);
        clickAudioSource.volume = clickVolume;  
    }
}
