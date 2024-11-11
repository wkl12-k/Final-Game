using UnityEngine;

public class TutorialScript : MonoBehaviour
{
    [SerializeField] private GameObject UIElement;
    [SerializeField] private KeyCode trigger;
    [SerializeField] private GameObject[] tutorials;

    private static bool _hasInitialized = false;
    private int currentIndex = 0;

    void Update()
    {
        if (Input.GetKeyDown(trigger))
        {
            if (!_hasInitialized)
            {
                // Deactivate the initial UI element
                UIElement.SetActive(false);
                _hasInitialized = true;

                // Activate the first tutorial UI if it exists
                if (tutorials.Length > 0)
                {
                    tutorials[0].SetActive(true);
                    currentIndex = 1; // Set to the next tutorial in the array
                }
            }
            else if (currentIndex < tutorials.Length)
            {
                // Deactivate the previous tutorial UI
                tutorials[currentIndex - 1].SetActive(false);

                // Activate the current tutorial UI
                tutorials[currentIndex].SetActive(true);

                // Move to the next tutorial
                currentIndex++;
            }
            else
            {
                // Ensure the last tutorial is deactivated if all have been shown
                tutorials[currentIndex - 1].SetActive(false);
            }
        }
    }

    private void Awake()
    {
        // Ensure the initial state is correct before initialization
        UIElement.SetActive(true);

        // Deactivate all tutorial UIs initially
        foreach (GameObject tutorial in tutorials)
        {
            tutorial.SetActive(false);
        }

        // Activate the first tutorial if not initialized yet and tutorials array is not empty
        if (!_hasInitialized && tutorials.Length > 0)
        {
            tutorials[0].SetActive(true);
            _hasInitialized = true; // Mark as initialized to avoid reinitialization in Update
            currentIndex = 1; // Set to the next tutorial in the array
        }
    }
}
