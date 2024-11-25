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
    [SerializeField] chessPuzzleSpawner chessPuzzleSpawner;

    private GameObject lastPlacedPiece;
    private int counter;
    private bool lastPiece = false;

    private void Start()
    {
        chessPuzzleSpawner = FindAnyObjectByType<chessPuzzleSpawner>();
    }

    public void PieceSelected(GameObject piecePrefab, Button pieceButton)
    {
        if (!pieceStatus.GetPieceStatus())  
        {
            Vector3 position = lastPlacedPiece != null ? lastPlacedPiece.transform.position : chessBoard.GetStartTilePosition();

            if (lastPlacedPiece != null)
            {
                Destroy(lastPlacedPiece);
                lastPlacedPiece = null;
            }

            lastPlacedPiece = InstantiatePieceOnBoard(position, piecePrefab);
            pieceStatus.SetPieceStatus(true);   

            pieceButton.interactable = false;

            counter++;    

            if (counter == chessPuzzleSpawner.GetPieceMenu().ToArray().Length)
            {
                lastPiece = true;
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
        counter = 0;

        if (lastPlacedPiece != null)
        {
            Destroy(lastPlacedPiece);  
        }

        lastPlacedPiece.GetComponent<ShowAvailableTiles>().DestroyTileLights();

    }

    public bool IsLastPiece()
    {
        return lastPiece;
    }
}