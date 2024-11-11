using UnityEngine;

public class PausePlay : MonoBehaviour
{
    [SerializeField] GameObject playButton;
    [SerializeField] GameObject pauseButton;

    void Start()
    {
        pauseButton.SetActive(true);
        playButton.SetActive(false);
    }

    public void PauseButtonPressed()
    {
        Time.timeScale = 0;
        pauseButton.SetActive(false);
        playButton.SetActive(true);
    }

    public void PlayButtonPressed()
    {
        Time.timeScale = Time.deltaTime;
        playButton.SetActive(false);
        pauseButton.SetActive(true);
    }

}
