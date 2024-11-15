using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManagement : MonoBehaviour
{
    [SerializeField] private AudioClip chessMoveSound;
    [SerializeField] private AudioClip reachedGoalSound;
    [SerializeField] private AudioClip backgroundMusic;

    private AudioSource audioSource;
    private static MusicManagement instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.loop = true;
            PlayBackgroundMusic();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayChessMoveSound()
    {
        audioSource.PlayOneShot(chessMoveSound);
    }

    public void PlayReachedGoalSound()
    {
        audioSource.PlayOneShot(reachedGoalSound);
    }

    private void PlayBackgroundMusic()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.clip = backgroundMusic;
            audioSource.Play();
        }
    }
}
