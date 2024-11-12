using UnityEngine;
using UnityEngine.EventSystems;

public class Tile : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    private Renderer tileRenderer;
    private bool isEndGoal = false;
    private Color originalColor;
    public Color hoverColor = Color.green;
    private Color endGoalColor = Color.HSVToRGB(20, 0, 50);
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
        if(!isEndGoal)
        tileRenderer.material.color = hoverColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {   if(!isEndGoal)
        tileRenderer.material.color = originalColor;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        chessBoard.OnTileClicked(this);
    }

    public void SetEndGoal()
    {
       
            tileRenderer.material.color = endGoalColor;
        isEndGoal = true;
    }

}
