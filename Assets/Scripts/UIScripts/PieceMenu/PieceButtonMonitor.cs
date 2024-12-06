using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PieceButtonMonitor: MonoBehaviour
{
    [SerializeField] PieceButtons pieceButtons;
    [SerializeField] PieceStatus pieceStatus;

    private List<GameObject> buttonMenu;

    private GameObject pieceSelected;
    private GameObject pieceMoved;
    private GameObject pieceDeselected;

    private Dictionary<Button, string> buttonMap = new Dictionary<Button, string>();

    void Start()
    {
        pieceButtons = FindAnyObjectByType<PieceButtons>();
        pieceStatus = FindAnyObjectByType<PieceStatus>();

        buttonMenu = pieceButtons.getButtonMenu();

        foreach (GameObject pieceButton in buttonMenu)
        {
            buttonMap.Add(pieceButton.GetComponent<Button>(), "available"); 
        }

    }

    public void StartMonitoringPieceButtons(List<GameObject> buttonMenu)
    {
        foreach (GameObject pieceButton in buttonMenu)
        {
            buttonMap.Add(pieceButton.GetComponent<Button>(), "available");
        }
    }

    public void PieceSelected(Button piece)
    {
        buttonMap[piece] = "selected";
        Debug.Log("SELECTED A PIECE: " + piece);
    }

    public Button GetSelectedPiece()
    {
        foreach (Button button in buttonMap.Keys)
        {
            if (buttonMap[button] == "selected"){
                return button;
            }
        }

        return null;
    }

    public void PieceDeselected(bool makeAvailableAgain)
    {
        
        
        Button selectedPiece = GetSelectedPiece();
        Debug.Log("DESELECTING: " + selectedPiece);


        if (selectedPiece != null)
        {
            
            //if (makeAvailableAgain)
            //{
                Debug.Log("SELECTED PIECE +   "+ selectedPiece);
                selectedPiece.interactable = true;
                buttonMap[selectedPiece] = "available";
            //}
            //else
            //{
            //    buttonMap[selectedPiece] = "exhausted";
            //}
        }
    }
}
