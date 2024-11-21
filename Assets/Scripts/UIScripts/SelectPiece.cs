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

    [Header("Other Scripts")]
    [SerializeField] PieceStatus pieceStatus;

    private GameObject lastPlacedPiece;

    // This method handles piece selection and placement
    public void PieceSelected(GameObject piecePrefab, Button pieceButton)
    {
        if (!pieceStatus.GetPieceStatus())  // Check if piece hasn't been placed yet
        {
            Vector3 position = lastPlacedPiece != null ? lastPlacedPiece.transform.position : chessBoard.GetStartTilePosition();

            if (lastPlacedPiece != null)
            {
                Destroy(lastPlacedPiece);
                lastPlacedPiece = null;
            }

            lastPlacedPiece = InstantiatePieceOnBoard(position, piecePrefab);
            pieceStatus.SetPieceStatus(true);  // Mark this piece as placed
            pieceStatus.IncrementPieceCount(); // Increment placed piece count

            pieceButton.interactable = false;  // Disable button for this piece

            // After placing the piece, check if all pieces are placed
            if (pieceStatus.AreAllPiecesUsed())
            {
                pieceStatus.allowEndGoal = true;  // Enable the end goal when all pieces are placed
                Debug.Log("All pieces are placed. End goal is now allowed.");
            }
        }

       
    }

    public GameObject InstantiatePieceOnBoard(Vector3 position, GameObject piecePrefab)
    {
        Quaternion uprightRotation = Quaternion.Euler(-90, 90, 0);
        GameObject piece = Instantiate(piecePrefab, position, uprightRotation);

        ChessPieceMovement pieceMovement = piece.GetComponent<ChessPieceMovement>();
        chessBoard.SetSelectedPiece(pieceMovement);

        return piece;
    }

    public void ResetBoard()
    {
        if (lastPlacedPiece != null)
        {
            Destroy(lastPlacedPiece); // Destroy the last placed piece
        }

        lastPlacedPiece.GetComponent<ShowAvailableTiles>().DestroyTileLights();

        pieceStatus.ResetPieceCount(); // Reset piece status count
    }
}
