using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    [SerializeField] GameObject exitPanel;
    [SerializeField] GameObject instructionsPanel;
    [SerializeField] GameObject playButton;
    [SerializeField] GameObject[] UIelements;

    private static string lastSceneName;

    void Update()
    {
    }

    public void OpenExitPanel()
    {
        if (exitPanel != null)
        {
            exitPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void CloseExitPanel()
    {
        if (exitPanel != null)
        {
            exitPanel.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void OpenInstructionsPanel()
    {
        if (instructionsPanel != null)
        {
            instructionsPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void CloseInstructionsPanel()
    {
        if (instructionsPanel != null)
        {
            instructionsPanel.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void Play()
    {
        if (playButton != null)
        {
            playButton.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void toLevel(string name)
    {
        lastSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(name);
    }

    public void LoadLastScene()
    {
        if (!string.IsNullOrEmpty(lastSceneName))
        {
            SceneManager.LoadScene(lastSceneName);
        }
    }
}
