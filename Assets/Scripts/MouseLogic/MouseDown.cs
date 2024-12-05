using UnityEngine;
using UnityEngine.EventSystems;


public class MouseDown : MonoBehaviour
{ 

    void OnMouseDown()
    {
        GetMousePosition();
    }

    public Vector3 GetMousePosition()
    {
        return Input.mousePosition;
    }
}