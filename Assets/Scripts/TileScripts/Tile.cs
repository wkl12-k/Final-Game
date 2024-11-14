using UnityEngine;
using UnityEngine.EventSystems;

public class Tile : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    private Renderer tileRenderer;
    private bool isEndGoal = false;
    private Color originalColor;
    public Color hoverColor = Color.green;
    private Color endGoalColor = Color.cyan;

    [HideInInspector]
    public ChessBoard chessBoard;


    

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
