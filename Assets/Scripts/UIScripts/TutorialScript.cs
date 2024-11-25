using UnityEngine;
using UnityEngine.UI;

public class TutorialScript : MonoBehaviour
{
    public GameObject tutorial1;
    public GameObject tutorial2;
    public GameObject tutorial2_5;
    public GameObject tutorial3;
    public GameObject tutorial4;
    public Button bishopButton;
    public Button rookButton;
    public Button knightButton;
    public Button kingButton;
    public Button pawnButton;

    private bool isTutorial1Completed = false;
    private int nextTutorial = 1;


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
            tutorial2_5.SetActive(false);
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
        if (nextTutorial == 2 && Input.GetMouseButtonDown(0))
        {
                HideTutorial1();
                ShowTutorial2();
        }
        else if (nextTutorial == 3 && Input.GetMouseButtonDown(0))
        {
            HideTutorial2();
            ShowTutorial3();
        }
        else if (nextTutorial == 4 && Input.GetMouseButtonDown(0))
        {
            HideTutorial3();
            ShowTutorial4();
        }
        else if ( nextTutorial == 0 && Input.GetMouseButtonDown(0))
        {
            HideTutorial4();
            tutorialsCompleted = true;
        }
    }

    void ShowTutorial1()
    {
        tutorial1.SetActive(true);
        tutorial2.SetActive(false);
        tutorial2_5.SetActive(false);
        tutorial3.SetActive(false);
        tutorial4.SetActive(false);

        nextTutorial = 2;
    }

    public void HideTutorial1()
    {
        if (!isTutorial1Completed)
        {
            tutorial1.SetActive(false);
            isTutorial1Completed = true;
        }
    }

    void ShowTutorial2()
    {
        tutorial2.SetActive(true);
        tutorial2_5.SetActive(true);
        nextTutorial = 3;
    }

    void HideTutorial2()
    {
        tutorial2.SetActive(false);
        tutorial2_5.SetActive(false);
    }

    void ShowTutorial3()
    {
        tutorial3.SetActive(true);
        nextTutorial = 4;
    }

    void HideTutorial3()
    {
        tutorial3.SetActive(false);
    }

    void ShowTutorial4()
    {
        tutorial4.SetActive(true);
        nextTutorial = 0;
    }

    void HideTutorial4()
    {
        tutorial4.SetActive(false);
    }

}
