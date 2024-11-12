using UnityEngine;
using UnityEngine.UI;

public class TutorialScript : MonoBehaviour
{
    public GameObject tutorial1;
    public GameObject tutorial2;
    public GameObject tutorial3;
    public GameObject tutorial4; 
    public Button bishopButton;
    public Button rookButton;
    public Button knightButton;
    public Button kingButton;
    public Button helpButton;
    public Button returnButton;
    public Button resetButton;

    private bool isTutorial1Completed = false;
    private bool isTutorial2Completed = false;
    private bool isTutorial3Active = false;
    private bool isTutorial4Active = false;  

    private static bool tutorialsCompleted = false;

    private SceneManagement sceneManagement;

    void Awake()
    {
        sceneManagement = FindAnyObjectByType<SceneManagement>();
        if (sceneManagement == null)
        {
            Debug.LogError("SceneManagement not found in the scene.");
        }

        if (tutorialsCompleted)
        {
            tutorial1.SetActive(false);
            tutorial2.SetActive(false);
            tutorial3.SetActive(false);
            tutorial4.SetActive(false);
        }
        else
        {
            ShowTutorial1();
        }
    }

    void Update()
    {
        if (isTutorial3Active && Input.GetMouseButtonDown(0))
        {
            HideTutorial3();
            ShowTutorial4();   
        }
    }

    void ShowTutorial1()
    {
        tutorial1.SetActive(true);
        tutorial2.SetActive(false);
        tutorial3.SetActive(false);
        tutorial4.SetActive(false);

        bishopButton.onClick.AddListener(HideTutorial1);
        rookButton.onClick.AddListener(HideTutorial1);
        knightButton.onClick.AddListener(HideTutorial1);
        kingButton.onClick.AddListener(HideTutorial1);
    }

    void HideTutorial1()
    {
        if (!isTutorial1Completed)
        {
            tutorial1.SetActive(false);
            isTutorial1Completed = true;
            ShowTutorial2();
        }
    }

    void ShowTutorial2()
    {
        tutorial2.SetActive(true);
        helpButton.onClick.AddListener(HideTutorial2);
    }

    void HideTutorial2()
    {
        if (!isTutorial2Completed)
        {
            tutorial2.SetActive(false);
            isTutorial2Completed = true;
            returnButton.onClick.AddListener(ShowTutorial3);
        }
    }

    void ShowTutorial3()
    {
        tutorial3.SetActive(true);
        isTutorial3Active = true;
    }

    void HideTutorial3()
    {
        tutorial3.SetActive(false);
        isTutorial3Active = false;
    }

    void ShowTutorial4()
    {
        tutorial4.SetActive(true);
        isTutorial4Active = true;
        resetButton.onClick.AddListener(RestartLevel);
    }

    void HideTutorial4()
    {
        tutorial4.SetActive(false);
        isTutorial4Active = false;
    }

    public void RestartLevel()
    {
        HideTutorial4();
        tutorialsCompleted = true;
        sceneManagement.ReloadScene();
    }
}
