using UnityEngine;
using UnityEngine.EventSystems;

public class Tile : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    private Renderer tileRenderer;
    private Color originalColor;
    public Color hoverColor = Color.green;
    [HideInInspector]
    public ChessBoard chessBoard;

    void Start()
    {
        tileRenderer = GetComponent<Renderer>();
        originalColor = tileRenderer.material.color;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        tileRenderer.material.color = hoverColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tileRenderer.material.color = originalColor;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        chessBoard.OnTileClicked(this);
    }

}
