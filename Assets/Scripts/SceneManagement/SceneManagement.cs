using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;


public class SceneManagement : MonoBehaviour
{
    [SerializeField] GameObject exitPanel;
    [SerializeField] GameObject instructionsPanel;
    [SerializeField] GameObject playButton;

    [SerializeField] chessPuzzleSpawner chessSpawner = null;
    [SerializeField] PieceButtons pieceButtons = null;

    private static string lastSceneName;
    private SelectPiece selectPiece;

    void Update()
    {
        selectPiece = FindAnyObjectByType<SelectPiece>();
    }

    public string GetCurrentScene()
    {
        return SceneManager.GetActiveScene().name;
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
        Time.timeScale = 1;
        SceneManager.LoadScene(name);  
    }

    public void LoadLastScene()
    {
        if (!string.IsNullOrEmpty(lastSceneName))
        {
            SceneManager.LoadScene(lastSceneName);
        }
    }

    public void RestartScene()
    {
        pieceButtons.ResetPieceMenu();
        PieceStatus pieceStatus = FindAnyObjectByType<PieceStatus>();
        pieceStatus.SetPieceStatus(false);
        selectPiece.ResetBoard();
    }
}
