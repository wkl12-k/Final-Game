using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManagement : MonoBehaviour
{
    [SerializeField] private AudioClip chessMoveSound;
    [SerializeField] private AudioClip reachedGoalSound;
    [SerializeField] private AudioClip backgroundMusic;

    private AudioSource audioSource;
    private static MusicManagement instance;

    void Start()
    {
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.loop = true;
            PlayMusicForCurrentScene();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
    }

    public void PlayChessMoveSound()
    {
        audioSource.PlayOneShot(chessMoveSound);
    }

    public void PlayReachedGoalSound()
    {
        audioSource.PlayOneShot(reachedGoalSound);
    }

    private void PlayMusic(AudioClip song)
    {
        audioSource.PlayOneShot(song);
    }

    private void PlayMusicForCurrentScene()
    {
        string sceneName = SceneManager.GetActiveScene().name;

        if (sceneName == "Intro" && !audioSource.isPlaying)
        {
            PlayMusic(backgroundMusic);
        }
        else if (sceneName == "Menu" && !audioSource.isPlaying)
        {
            PlayMusic(backgroundMusic);
        }
    }
}
