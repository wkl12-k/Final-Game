using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class PieceButtons : MonoBehaviour
{
    [Header("Piece Prefabs")]
    [SerializeField] GameObject rookPrefab;
    [SerializeField] GameObject bishopPrefab;
    [SerializeField] GameObject kingPrefab;
    [SerializeField] GameObject knightPrefab;
    [SerializeField] GameObject pawnPrefab;

    [Header("UI Buttons")]
    [SerializeField] GameObject rookButtonPrefab;
    [SerializeField] GameObject bishopButtonPrefab;
    [SerializeField] GameObject kingButtonPrefab;
    [SerializeField] GameObject knightButtonPrefab;
    [SerializeField] GameObject pawnButtonPrefab;

    [Header("UI Setup")]
    [SerializeField] GameObject pieceMenuPanel;

    [Header("Other Scripts")]
    [SerializeField] chessPuzzleSpawner puzzleSpawner;
    [SerializeField] PieceButtonMonitor pieceButtonMonitor;

    private List<GameObject> pieceMenuButtonList;

    public void CreatePieceMenu(List<GameObject> pieceMenu)
    {
        GameObject button = null;
        pieceMenuButtonList = new List<GameObject>();

        foreach (GameObject piece in pieceMenu)
        {
            string pieceTag = piece.gameObject.tag;
            switch (pieceTag)
            {
                case "rook":
                    button = SpawnPiece(rookPrefab, rookButtonPrefab);
                    break;
                case "king":
                    button = SpawnPiece(kingPrefab, kingButtonPrefab);
                    break;
                case "bishop":
                    button = SpawnPiece(bishopPrefab, bishopButtonPrefab);
                    break;
                case "pawn":
                    button = SpawnPiece(pawnPrefab, pawnButtonPrefab);
                    break;
                case "knight":
                    button = SpawnPiece(knightPrefab, knightButtonPrefab);
                    break;
                default:
                    Debug.LogWarning("No valid case was given");
                    return;
            }

            pieceMenuButtonList.Add(button);
        }

        pieceButtonMonitor.StartMonitoringPieceButtons(pieceMenuButtonList);
    }

    public void ResetPieceMenu()
    {
        foreach (GameObject button in pieceMenuButtonList)
        {
            button.GetComponent<Button>().interactable = true;
        }

        GetComponent<SelectPiece>().ResetBoard();
    }

    private GameObject SpawnPiece(GameObject piecePrefab, GameObject pieceButton)
    {
        GameObject button = Instantiate(pieceButton, pieceMenuPanel.transform);
        SelectPiece selectPieceComponent = GetComponent<SelectPiece>();
        Button buttonComponent = button.GetComponent<Button>();
        buttonComponent.onClick.AddListener(() => selectPieceComponent.PieceSelected(piecePrefab, buttonComponent));
        return button;
    }

    public List<GameObject> getButtonMenu()
    {
        return pieceMenuButtonList;
    }
}
