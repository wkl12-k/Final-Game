using UnityEngine;


public class ClickListener : MonoBehaviour
{
    private MusicManagement musicManagement;

    void Start()
    {
        musicManagement = MusicManagement.Instance;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))  
        {
            PlayClickSound();
        }
    }

    private void PlayClickSound()
    {
        if (musicManagement != null)
        {
            musicManagement.PlayClick();
        }
    }
}
