using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//public enum PieceType
//{
//    Rook,
//    Bishop,
//    Knight,
//    Pawn,
//    King
//}

public class DragPieces : MonoBehaviour
{
    [Header("Piece Prefabs")]
    [SerializeField] GameObject rookPrefab;
    [SerializeField] GameObject bishopPrefab;
    [SerializeField] GameObject kingPrefab;
    [SerializeField] GameObject knightPrefab;
    [SerializeField] GameObject pawnPrefab;

    [Header("UI Buttons")]
    [SerializeField] Button rookButton;
    [SerializeField] Button bishopButton;
    [SerializeField] Button kingButton;
    [SerializeField] Button knightButton;
    [SerializeField] Button pawnButton;
    //[SerializeField] GameObject pieceButton;

    [Header("Chess Board Reference")]
    [SerializeField] ChessBoard chessBoard;

    private GameObject selectedPiecePrefab;
    private GameObject lastPlacedPiece;
    private List<GameObject> randomPieces = new List<GameObject>();

    void Start()
    {
        rookButton.onClick.AddListener(() => SelectPiece(rookPrefab, rookButton));
        bishopButton.onClick.AddListener(() => SelectPiece(bishopPrefab, bishopButton));
        kingButton.onClick.AddListener(() => SelectPiece(kingPrefab, kingButton));
        knightButton.onClick.AddListener(() => SelectPiece(knightPrefab, knightButton));
        pawnButton.onClick.AddListener(() => SelectPiece(pawnPrefab, pawnButton));
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
