using UnityEngine;
using UnityEngine.EventSystems;

public class Tile : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    private Renderer tileRenderer;
    private Color originalColor;
    public Color hoverColor = Color.green;
    public Color endGoalColor = Color.red;
    [HideInInspector]
    public ChessBoard chessBoard;


    //we want if the piece is chosen and put on board for it to show the available tiles for it by turning green or something else.

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

    public void selectEndGoal(PointerEventData eventData)
    {
        tileRenderer.material.color = endGoalColor;
    }

}
