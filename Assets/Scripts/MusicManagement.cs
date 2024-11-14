using UnityEngine;

public class MusicManagement : MonoBehaviour
{
    [SerializeField] private AudioClip chessMoveSound;
    [SerializeField] private AudioClip reachedGoalSound;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
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

}
