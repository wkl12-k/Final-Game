using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragPieces : MonoBehaviour
{
    [Header("Piece Prefabs")]
    public GameObject rookPrefab;
    public GameObject bishopPrefab;
    public GameObject kingPrefab;
    public GameObject knightPrefab;

    [Header("UI Buttons")]
    public Button rookButton;
    public Button bishopButton;
    public Button kingButton;
    public Button knightButton;
    public GameObject pieceButton;


    [Header("Chess Board Reference")]
    public ChessBoard chessBoard;

    private GameObject selectedPiecePrefab;
    private GameObject lastPlacedPiece;
    private List<GameObject> randomPieces = new List<GameObject>();

    void Start()
    {
        
        rookButton.onClick.AddListener(() => SelectPiece(rookPrefab, rookButton));
        bishopButton.onClick.AddListener(() => SelectPiece(bishopPrefab, bishopButton));
        kingButton.onClick.AddListener(() => SelectPiece(kingPrefab, kingButton));
        knightButton.onClick.AddListener(() => SelectPiece(knightPrefab, knightButton));
    }



    void SelectPiece(GameObject piecePrefab, Button pieceButton)
    {
        selectedPiecePrefab = piecePrefab;

        Vector3 position = lastPlacedPiece != null ? lastPlacedPiece.transform.position : chessBoard.GetStartTilePosition();

        
        if (lastPlacedPiece != null)
        {
            Destroy(lastPlacedPiece);
            lastPlacedPiece = null;  
        }

       
        lastPlacedPiece = InstantiatePieceOnBoard(position, piecePrefab);

        
        pieceButton.interactable = false;
    }

    GameObject InstantiatePieceOnBoard(Vector3 position, GameObject piecePrefab)
    {
        Quaternion uprightRotation = Quaternion.Euler(-90, 90, 0);
        GameObject piece = Instantiate(piecePrefab, position, uprightRotation);

        
        ChessPieceMovement pieceMovement = piece.GetComponent<ChessPieceMovement>();
        chessBoard.SetSelectedPiece(pieceMovement);

        return piece;  
    }
}
