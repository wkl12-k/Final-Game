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
                UIElement.SetActive(false);
                _hasInitialized = true;

                if (tutorials.Length > 0)
                {
                    tutorials[0].SetActive(true);
                    currentIndex = 1;  
                }
            }
            else if (currentIndex < tutorials.Length)
            {
                tutorials[currentIndex - 1].SetActive(false);
                tutorials[currentIndex].SetActive(true);
                currentIndex++;
            }
            else
            {
                tutorials[currentIndex - 1].SetActive(false);
            }
        }
    }

    private void Awake()
    {
        UIElement.SetActive(true);

        foreach (GameObject tutorial in tutorials)
        {
            tutorial.SetActive(false);
        }

        if (!_hasInitialized && tutorials.Length > 0)
        {
            tutorials[0].SetActive(true);
            _hasInitialized = true;  
            currentIndex = 1; 
        }
    }
}
