using UnityEngine;

public class PieceStatus : MonoBehaviour
{
    private chessPuzzleSpawner chessPuzzleSpawner;
    private int piecesPlaced = 0;  // Track how many pieces have been placed
    private int totalPieces;       // Total number of pieces to place
    public bool pieceOnBoard = false; // Flag if the piece is placed
    public bool allowEndGoal = false; // Flag to check if end goal can be reached

    void Start()
    {
        // Initialize total pieces when the game starts or when the puzzle spawner is ready
        chessPuzzleSpawner = FindObjectOfType<chessPuzzleSpawner>();  // Ensure the reference is set
        SetTotalPieces();
    }

    public void SetPieceStatus(bool status)
    {
        pieceOnBoard = status;
    }

    public bool GetPieceStatus()
    {
        return pieceOnBoard;
    }

    public void SetTotalPieces()
    {
        // Ensure that total pieces are correctly set from the chess puzzle spawner
        if (chessPuzzleSpawner != null)
        {
            totalPieces = chessPuzzleSpawner.GetTotalPieces();
        }
    }

    public void IncrementPieceCount()
    {
        piecesPlaced++;
        CheckAllowEndGoal();
    }

    public bool AreAllPiecesUsed()
    {
        return piecesPlaced == totalPieces;
    }

    public void ResetPieceCount()
    {
        piecesPlaced = 0;
        allowEndGoal = false;
    }

    private void CheckAllowEndGoal()
    {
        if (piecesPlaced == totalPieces)
        {
            allowEndGoal = true;  // Set flag to true when all pieces are placed
        }
    }
}
