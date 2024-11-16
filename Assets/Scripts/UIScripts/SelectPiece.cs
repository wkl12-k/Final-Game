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

public class SelectPiece : MonoBehaviour
{

    [Header("Chess Board Reference")]
    [SerializeField] ChessBoard chessBoard;

    //private GameObject selectedPiecePrefab;
    private GameObject lastPlacedPiece;
    //private List<GameObject> randomPieces = new List<GameObject>();


    public void PieceSelected(GameObject piecePrefab, Button pieceButton)
    {
        //selectedPiecePrefab = piecePrefab;

        Vector3 position = lastPlacedPiece != null ? lastPlacedPiece.transform.position : chessBoard.GetStartTilePosition();


        if (lastPlacedPiece != null)
        {
            Destroy(lastPlacedPiece);
            lastPlacedPiece = null;
        }


        lastPlacedPiece = InstantiatePieceOnBoard(position, piecePrefab);


        pieceButton.interactable = false;
    }

    public GameObject InstantiatePieceOnBoard(Vector3 position, GameObject piecePrefab)
    {
        Quaternion uprightRotation = Quaternion.Euler(-90, 90, 0);
        GameObject piece = Instantiate(piecePrefab, position, uprightRotation);


        ChessPieceMovement pieceMovement = piece.GetComponent<ChessPieceMovement>();
        chessBoard.SetSelectedPiece(pieceMovement);

        return piece;
    }
}
