using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneManagement : MonoBehaviour
{

    [SerializeField] GameObject exitPanel;
    [SerializeField] GameObject instructionsPanel;
    [SerializeField] GameObject playButton;
    [SerializeField] GameObject[] UIelements;

    void Update()
    {
    }

    public void OpenExitPanel()
    {
        if (exitPanel != null)
        {
            exitPanel.SetActive(true);
            Time.timeScale = 0;
            //foreach (GameObject element in UIelements)
            //{
            //    element.SetActive(false);
            //}
        }
    }

    public void CloseExitPanel()
    {
        if (exitPanel != null)
        {
            exitPanel.SetActive(false);
            Time.timeScale = 1;
            //foreach (GameObject element in UIelements)
            //{
            //    element.SetActive(true);
            //}
        }
    }

    public void OpenInstructionsPanel()
    {
        if (instructionsPanel != null)
        {
            instructionsPanel.SetActive(true);
            Time.timeScale = 0;
            //foreach (GameObject element in UIelements)
            //{
            //    element.SetActive(false);
            //}
        }
    }

    public void CloseInstructionsPanel()
    {
        if (instructionsPanel != null)
        {
            instructionsPanel.SetActive(false);
            Time.timeScale = 1;
            //foreach (GameObject element in UIelements)
            //{
            //    element.SetActive(true);
            //}
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

}
