using UnityEngine;
using UnityEngine.EventSystems;


public class Tile : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    private Renderer tileRenderer;
    private bool isEndGoal = false;
    private bool isStartGoal = false;
    private Color originalColor;
    private Color hoverColor = new Color(0.941f, 0.929f, 0.322f); // yellow
    private Color startTileColor= new Color(0.62f, 0.208f, 0.282f); // red
    private Color endGoalColor = new Color(0.416f, 0.6f, 0.447f); // green

    [HideInInspector]
    public ChessBoard chessBoard;

    void Start()
    {
        tileRenderer = GetComponent<Renderer>();
        originalColor = tileRenderer.material.color;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!isEndGoal && !isStartGoal)
            tileRenderer.material.color = hoverColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (!isEndGoal && !isStartGoal)
            tileRenderer.material.color = originalColor;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        chessBoard.OnTileClicked(this);
    }

    public void setStartTileColor()
    {
        tileRenderer.material.color = startTileColor;
        isStartGoal = true;
    }

    public void SetEndGoal()
    {
        tileRenderer.material.color = endGoalColor;
        isEndGoal = true;
    }
}