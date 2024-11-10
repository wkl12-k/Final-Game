using UnityEngine;
using UnityEngine.EventSystems;

public class DroppableTile : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        GameObject droppedPiece = eventData.pointerDrag;
        if (droppedPiece != null)
        {
            droppedPiece.GetComponent<RectTransform>().position = transform.position;  
           
        }
    }
}
