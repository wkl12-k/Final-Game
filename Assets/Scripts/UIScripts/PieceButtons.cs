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

    private List<GameObject> pieceMenuButtonList;

    public void CreatePieceMenu(List<GameObject> pieceMenu)
    {
        pieceMenuButtonList = new List<GameObject>();

        foreach (GameObject piece in pieceMenu)
        {
            GameObject button = null;

            if (piece.CompareTag("rook"))
            {
                button = Instantiate(rookButtonPrefab, pieceMenuPanel.transform);
                button.GetComponent<Button>().onClick.AddListener(() => GetComponent<SelectPiece>().PieceSelected(rookPrefab, button.GetComponent<Button>()));
            }
            else if (piece.CompareTag("king"))
            {
                button = Instantiate(kingButtonPrefab, pieceMenuPanel.transform);
                button.GetComponent<Button>().onClick.AddListener(() => GetComponent<SelectPiece>().PieceSelected(kingPrefab, button.GetComponent<Button>()));
            }
            else if (piece.CompareTag("bishop"))
            {
                button = Instantiate(bishopButtonPrefab, pieceMenuPanel.transform);
                button.GetComponent<Button>().onClick.AddListener(() => GetComponent<SelectPiece>().PieceSelected(bishopPrefab, button.GetComponent<Button>()));
            }
            else if (piece.CompareTag("pawn"))
            {
                button = Instantiate(pawnButtonPrefab, pieceMenuPanel.transform);
                button.GetComponent<Button>().onClick.AddListener(() => GetComponent<SelectPiece>().PieceSelected(pawnPrefab, button.GetComponent<Button>()));
            }
            else if (piece.CompareTag("knight"))
            {
                button = Instantiate(knightButtonPrefab, pieceMenuPanel.transform);
                button.GetComponent<Button>().onClick.AddListener(() => GetComponent<SelectPiece>().PieceSelected(knightPrefab, button.GetComponent<Button>()));
            }

            pieceMenuButtonList.Add(button);
        }
    }

    public void ResetPieceMenu()
    {
        foreach (GameObject button in pieceMenuButtonList)
        {
            button.GetComponent<Button>().interactable = true;
        }

        GetComponent<SelectPiece>().ResetBoard();
    }
}
