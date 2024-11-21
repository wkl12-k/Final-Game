using UnityEngine;

public class PieceStatus : MonoBehaviour
{
    private chessPuzzleSpawner chessPuzzleSpawner;
    private int piecesPlaced = 0;
    private int totalPieces;
    public bool pieceOnBoard = false;
    public bool allowEndGoal = false;

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
        totalPieces = chessPuzzleSpawner.GetTotalPieces();
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
            allowEndGoal = true;  
        }
    }

}