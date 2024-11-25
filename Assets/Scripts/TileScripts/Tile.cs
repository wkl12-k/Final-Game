using UnityEngine;
using UnityEngine.EventSystems;

public class Tile : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    private Renderer tileRenderer;
    private bool isEndGoal = false;
    private bool isStartGoal = false;
    private Color originalColor;
    public Color hoverColor = Color.green;
    private Color endGoalColor = Color.Lerp(Color.green, Color.yellow, 5);
    private Color startTileColor = Color.red;

    [HideInInspector]
    public ChessBoard chessBoard;

    private TextMesh textMesh;

    void Start()
    {
        tileRenderer = GetComponent<Renderer>();
        originalColor = tileRenderer.material.color;
        createTextIndicatorsOnTile();



    }


    private void createTextIndicatorsOnTile()
    {
        textMesh = GetComponentInChildren<TextMesh>();
        if (textMesh == null)
        {
            GameObject textObject = new GameObject("TileText");
            textObject.transform.SetParent(this.transform, false);
            textMesh = textObject.AddComponent<TextMesh>();

            textObject.transform.localPosition = Vector3.up * 0.1f;

            textMesh.fontSize = 50;
            textMesh.alignment = TextAlignment.Center;
            textMesh.anchor = TextAnchor.MiddleCenter;
            textMesh.characterSize = 0.1f;
            textMesh.color = Color.black; 
        }
        textMesh.text = "";
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

    public void setStartTileColor()
    {
        tileRenderer.material.color = startTileColor;
        isStartGoal = true;
        textMesh.text = "Start"; 
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        chessBoard.OnTileClicked(this);
    }

    public void SetEndGoal()
    {
        tileRenderer.material.color = endGoalColor;
        isEndGoal = true;
        textMesh.text = "End"; 
    }
}
