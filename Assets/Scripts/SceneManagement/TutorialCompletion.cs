using UnityEngine;

public class TutorialCompletion : MonoBehaviour
{
    private SceneManagement sceneManagement;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTutorialCompletion()
    {
        sceneManagement.toLevel("Menu");
    }
}
