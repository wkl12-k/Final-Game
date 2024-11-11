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
        }
    }

    private void Awake()
    {
        if (_hasInitialized)
        {
            // Ensure the initial UI element is inactive
            UIElement.SetActive(false);

            // Deactivate all tutorial UIs initially
            foreach (GameObject tutorial in tutorials)
            {
                tutorial.SetActive(false);
            }

            // Activate the current tutorial UI if within bounds
            if (currentIndex > 0 && currentIndex <= tutorials.Length)
            {
                tutorials[currentIndex - 1].SetActive(true);
            }
        }
        else
        {
            // Ensure the initial state is correct before initialization
            UIElement.SetActive(true);
            foreach (GameObject tutorial in tutorials)
            {
                tutorial.SetActive(false);
            }
        }
    }
}
